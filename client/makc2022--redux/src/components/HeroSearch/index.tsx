import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import { DebounceInput } from 'react-debounce-input';
import { useTranslation } from 'react-i18next';
import { useModuleContext } from '../../contexts';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import styles from './HeroSearch.module.css';
import { clear, getHeroesAsync, selectHeroes } from './heroSearchSlice';

export function HeroSearch(): React.ReactElement {
  const { heroService } = useModuleContext();

  const { t } = useTranslation(['components/HeroSearch']);

  const heroes = useAppSelector(selectHeroes);

  const dispatch = useAppDispatch();

  const inputs = {
    term: {
      id: 'search-box',
      name: 'search-box',
    },
  };

  useEffect(() => {
    return () => {
      dispatch(clear());
    };
  }, [dispatch, heroService]);

  function handleInputChange(event: React.ChangeEvent<HTMLInputElement>): void {
    const { target } = event;

    if (target.name === inputs.term.name) {
      dispatch(getHeroesAsync({ heroService, term: target.value }));
    }
  }

  return (
    <div id='search-component' className={styles['hero-search']}>
      <label htmlFor={inputs.term.id}>{t('@@title')}</label>
      <DebounceInput
        id={inputs.term.id}
        name={inputs.term.name}
        minLength={2}
        debounceTimeout={300}
        onChange={(event) => handleInputChange(event)}
      />
      <ul className={styles['search-result']}>
        {heroes.map((hero) => (
          <li key={hero.id}>
            <Link to={`/detail/${hero.id}`}>{hero.name}</Link>
          </li>
        ))}
      </ul>
    </div>
  );
}
