import React, { useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { useModuleContext } from '../../contexts';
import styles from './HeroDetail.module.css';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import {
  getHeroAsync,
  selectHero,
  setHero,
  updateHeroAsync,
} from './heroDetailSlice';

export function HeroDetail(): React.ReactElement {
  const { heroService } = useModuleContext();

  const hero = useAppSelector(selectHero);

  const dispatch = useAppDispatch();

  const navigate = useNavigate();
  const urlParams = useParams();

  const inputs = {
    heroName: {
      id: 'hero-name',
      name: 'hero-name',
    },
  };

  useEffect(() => {
    dispatch(getHeroAsync({ heroService, id: Number(urlParams.id) }));
  }, [dispatch, heroService, urlParams.id]);

  function goBack(): void {
    navigate(-1);
  }

  function save(): void {
    if (hero) {
      dispatch(updateHeroAsync({ heroService, hero })).then(() => {
        goBack();
      });
    }
  }

  function handleInputChange(event: React.ChangeEvent<HTMLInputElement>): void {
    const { target } = event;

    if (target.name === inputs.heroName.name) {
      dispatch(setHero({ ...hero, name: target.value }));
    }
  }

  return (
    <div className={styles['hero-detail']}>
      {hero.id > 0 && (
        <div>
          <h2>{hero.name.toUpperCase()} Details</h2>
          <div>
            <span>id: </span>
            {hero.id}
          </div>
          <div>
            <label htmlFor={inputs.heroName.id}>Hero name: </label>
            <input
              id={inputs.heroName.id}
              name={inputs.heroName.name}
              value={hero.name}
              onChange={handleInputChange}
              placeholder='name'
            />
          </div>
        </div>
      )}
      <button type='button' onClick={goBack}>
        go back
      </button>
      <button type='button' onClick={save}>
        save
      </button>
    </div>
  );
}
