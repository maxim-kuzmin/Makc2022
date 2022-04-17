import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { createHero, Hero } from '../../models/Hero';
import { useModuleContext } from '../../contexts';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import styles from './Heroes.module.css';
import {
  addHeroAsync,
  clear,
  deleteHeroAsync,
  getHeroesAsync,
  selectHeroes,
} from './heroesSlice';

export function Heroes(): React.ReactElement {
  const { heroService } = useModuleContext();

  const { t } = useTranslation(['views/Heroes']);

  const heroes = useAppSelector(selectHeroes);

  const [newHero, setNewHero] = useState(createHero());

  const dispatch = useAppDispatch();

  const inputs = {
    newHeroName: {
      id: 'new-hero',
      name: 'new-hero',
    },
  };

  useEffect(() => {
    dispatch(getHeroesAsync({ heroService }));
    return () => {
      dispatch(clear());
    };
  }, [dispatch, heroService]);

  function handleInputChange(event: React.ChangeEvent<HTMLInputElement>): void {
    const { target } = event;

    if (target.name === inputs.newHeroName.name) {
      setNewHero({ ...newHero, name: target.value });
    }
  }

  function addNewHero(): void {
    if (newHero.name) {
      newHero.name = newHero.name.trim();
    }
    if (!newHero.name) {
      return;
    }
    dispatch(addHeroAsync({ heroService, hero: newHero })).then(() => {
      setNewHero(createHero());
    });
  }

  function deleteHero(hero: Hero): void {
    dispatch(deleteHeroAsync({ heroService, hero }));
  }

  return (
    <div className={styles.heroes}>
      <h2>{t('@@title')}</h2>
      <div>
        <label htmlFor={inputs.newHeroName.id}>{t('@@hero-name')}: </label>
        <input
          id={inputs.newHeroName.id}
          name={inputs.newHeroName.name}
          value={newHero.name}
          onChange={handleInputChange}
        />
        <button
          className={styles['add-button']}
          type='button'
          onClick={addNewHero}
        >
          {t('@@action-add-hero')}
        </button>
      </div>
      <ul>
        {heroes.map((hero) => (
          <li key={hero.id}>
            <Link to={`/detail/${hero.id}`}>
              <span className={styles.badge}>{hero.id}</span> {hero.name}
            </Link>
            <button
              className={styles.delete}
              type='button'
              title={t('@@action-delete-hero')}
              onClick={() => deleteHero(hero)}
            >
              x
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
