import { map, switchMap } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import {
  createAction,
  createFeatureSelector,
  createReducer,
  createSelector,
  on,
  props,
} from '@ngrx/store';
import { HeroService } from '../../services/hero.service';
import { viewHeroesKey } from '../../app.keys';
import { createHero, Hero } from '../../models/hero';

export interface HeroesState {
  heroes: Hero[];
  addedHero: Hero;
  deletedHero: Hero;
}

const initialState = {
  heroes: [],
  addedHero: createHero(),
  deletedHero: createHero(),
} as HeroesState;

export const addHero = createAction(
  '[views/Heroes] Add Hero',
  props<{ addedHero: Hero }>()
);

export const addHeroSuccess = createAction(
  '[views/Heroes] Add Hero Success',
  props<{ addedHero: Hero }>()
);

export const clear = createAction('[views/Heroes] Clear');

export const deleteHero = createAction(
  '[views/Heroes] Delete Hero',
  props<{ id: number }>()
);

export const deleteHeroSuccess = createAction(
  '[views/Heroes] Delete Hero Success',
  props<{ deletedHero: Hero }>()
);

export const getHeroes = createAction('[views/Heroes] Get Heroes');

export const getHeroesSuccess = createAction(
  '[views/Heroes] Get Heroes Success',
  props<{ heroes: Hero[] }>()
);

@Injectable()
export class HeroesEffects {
  constructor(private actions$: Actions, private heroService: HeroService) {}

  addHero$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(addHero),
      switchMap((input) =>
        this.heroService
          .addHero(input.addedHero)
          .pipe(map((addedHero) => addHeroSuccess({ addedHero })))
      )
    );
  });

  deleteHero$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(deleteHero),
      switchMap((input) =>
        this.heroService
          .deleteHero(input.id)
          .pipe(map((deletedHero) => deleteHeroSuccess({ deletedHero })))
      )
    );
  });

  getHeroes$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(getHeroes),
      switchMap(() =>
        this.heroService
          .getHeroes()
          .pipe(map((heroes) => getHeroesSuccess({ heroes })))
      )
    );
  });
}

export default createReducer(
  initialState,
  on(addHeroSuccess, (state, { addedHero }): HeroesState => {
    return { ...state, addedHero };
  }),
  on(clear, (): HeroesState => {
    return initialState;
  }),
  on(getHeroesSuccess, (state, { heroes }): HeroesState => {
    return { ...state, heroes };
  }),
  on(deleteHeroSuccess, (state, { deletedHero }): HeroesState => {
    return { ...state, deletedHero };
  })
);

export const selectHeroesState =
  createFeatureSelector<HeroesState>(viewHeroesKey);

export const selectAddedHero = createSelector(
  selectHeroesState,
  (state) => state.addedHero
);

export const selectDeletedHero = createSelector(
  selectHeroesState,
  (state) => state.deletedHero
);

export const selectHeroes = createSelector(
  selectHeroesState,
  (state) => state.heroes
);
