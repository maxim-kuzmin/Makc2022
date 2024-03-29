import React, { useEffect } from 'react';
import { Link } from 'react-router-dom';
import { useTranslation } from 'react-i18next';
import { useModuleContext } from '../../contexts';
import { HeroSearch } from '../../components/HeroSearch';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import styles from './Dashboard.module.css';
import { clear, getHeroesAsync, selectHeroes } from './dashboardSlice';

export function Dashboard(): React.ReactElement {
  const { heroService } = useModuleContext();

  const { t } = useTranslation(['views/Dashboard']);

  const heroes = useAppSelector(selectHeroes);

  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(getHeroesAsync({ heroService }));
    return () => {
      dispatch(clear());
    };
  }, [dispatch, heroService]);

  return (
    <>
      <div className={styles.dashboard}>
        <h2>{t('@@title')}</h2>
        <div className={styles['heroes-menu']}>
          {heroes.map((hero) => (
            <Link to={`/detail/${hero.id}`} key={hero.id}>
              {hero.name}
            </Link>
          ))}
        </div>
      </div>
      <HeroSearch />
    </>
  );
}
