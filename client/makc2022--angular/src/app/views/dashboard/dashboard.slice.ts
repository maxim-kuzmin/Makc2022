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
import { viewDashboardKey } from '../../app.keys';
import { Hero } from '../../models/hero';
import { map, switchMap } from 'rxjs';

export interface DasboardState {
  heroes: Hero[];
}

const initialState = {
  heroes: [],
} as DasboardState;

export const clear = createAction('[views/Dasboard] Clear');

export const getHeroes = createAction('[views/Dasboard] Get Heroes');

export const getHeroesSuccess = createAction(
  '[views/Dasboard] Get Heroes Success',
  props<{ heroes: Hero[] }>()
);

@Injectable()
export class DasboardEffects {
  constructor(private actions$: Actions, private heroService: HeroService) {}

  getHeroes$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(getHeroes),
      switchMap(() =>
        this.heroService
          .getHeroes()
          .pipe(
            map((heroes) => getHeroesSuccess({ heroes: heroes.slice(1, 5) }))
          )
      )
    );
  });
}

export default createReducer(
  initialState,
  on(clear, (): DasboardState => {
    return initialState;
  }),
  on(getHeroesSuccess, (state, { heroes }): DasboardState => {
    return { ...state, heroes };
  })
);

export const selectDasboardState =
  createFeatureSelector<DasboardState>(viewDashboardKey);

export const selectHeroes = createSelector(
  selectDasboardState,
  (state) => state.heroes
);
