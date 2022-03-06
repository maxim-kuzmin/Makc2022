import { Injectable } from '@angular/core';
import {
  createAction,
  createFeatureSelector,
  createReducer,
  createSelector,
  on,
  props,
} from '@ngrx/store';
import { map, switchMap } from 'rxjs';
import { Hero } from '../../models/hero';
import { componentHeroSearchKey } from '../../app.keys';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { HeroService } from '../../services/hero.service';

export interface HeroSearchState {
  heroes: Hero[];
}

const initialState = {
  heroes: [],
} as HeroSearchState;

export const clear = createAction('[components/HeroSearch] Clear');

export const getHeroes = createAction(
  '[components/HeroSearch] Get Heroes',
  props<{ term: string }>()
);

export const getHeroesSuccess = createAction(
  '[components/HeroSearch] Get Heroes Success',
  props<{ heroes: Hero[] }>()
);

@Injectable()
export class HeroSearchEffects {
  constructor(private actions$: Actions, private heroService: HeroService) {}

  getHeroes$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(getHeroes),
      switchMap((input) =>
        this.heroService
          .searchHeroes(input.term)
          .pipe(map((heroes) => getHeroesSuccess({ heroes })))
      )
    );
  });
}
export default createReducer(
  initialState,
  on(clear, (): HeroSearchState => {
    return initialState;
  }),
  on(getHeroesSuccess, (state, { heroes }): HeroSearchState => {
    return { ...state, heroes };
  })
);

export const selectHeroSearchState = createFeatureSelector<HeroSearchState>(
  componentHeroSearchKey
);

export const selectHeroes = createSelector(
  selectHeroSearchState,
  (state) => state.heroes
);
