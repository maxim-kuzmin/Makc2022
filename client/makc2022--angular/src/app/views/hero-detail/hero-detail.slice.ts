import { Location } from '@angular/common';
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
import { map, switchMap } from 'rxjs';
import { HeroService } from '../../services/hero.service';
import { viewHeroDetailKey } from '../../app.keys';
import { createHero, Hero } from '../../models/hero';

export interface HeroDetailState {
  hero: Hero;
}

const initialState = {
  hero: createHero(),
} as HeroDetailState;

export const clear = createAction('[views/HeroDetail] Clear');

export const getHero = createAction(
  '[views/HeroDetail] Get Hero',
  props<{ id: number }>()
);

export const getHeroSuccess = createAction(
  '[views/HeroDetail] Get Hero Success',
  props<{ hero: Hero }>()
);

export const updateHero = createAction(
  '[views/HeroDetail] Update Hero',
  props<{ hero: Hero }>()
);

@Injectable()
export class HeroDetailEffects {
  constructor(
    private actions$: Actions,
    private heroService: HeroService,
    private location: Location
  ) {}

  getHero$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(getHero),
      switchMap((input) =>
        this.heroService
          .getHero(input.id)
          .pipe(map((hero) => getHeroSuccess({ hero })))
      )
    );
  });

  updateHero$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(updateHero),
      switchMap((input) =>
        this.heroService
          .updateHero(input.hero)
          .pipe(map((hero) => getHeroSuccess({ hero })))
      )
    );
  });
}

export default createReducer(
  initialState,
  on(clear, (): HeroDetailState => {
    return initialState;
  }),
  on(getHeroSuccess, (state, { hero }): HeroDetailState => {
    return { ...state, hero };
  })
);

export const selectHeroDetailState =
  createFeatureSelector<HeroDetailState>(viewHeroDetailKey);

export const selectHero = createSelector(
  selectHeroDetailState,
  (state) => state.hero
);
