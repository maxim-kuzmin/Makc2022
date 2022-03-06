import { Hero } from '@/models/Hero';
import { MutationTree } from 'vuex';
import { createInitialState, HeroesState } from './state';

export enum HeroesMutationType {
  AddHeroSuccess = '[views/Heroes] Add Hero Success',
  Clear = '[views/Heroes] Clear',
  DeleteHeroSuccess = '[views/Heroes] Delete Hero Success',
  GetHeroesSuccess = '[views/Heroes] Get Hero Success',
}

export type HeroesMutations = {
  [HeroesMutationType.AddHeroSuccess](state: HeroesState, hero: Hero): void;
  [HeroesMutationType.Clear](state: HeroesState): void;
  [HeroesMutationType.DeleteHeroSuccess](state: HeroesState, hero: Hero): void;
  [HeroesMutationType.GetHeroesSuccess](
    state: HeroesState,
    heroes: Hero[]
  ): void;
};

export default {
  [HeroesMutationType.AddHeroSuccess](state, hero: Hero) {
    state.addedHero = hero;
  },
  [HeroesMutationType.Clear](state) {
    Object.assign(state, createInitialState());
  },
  [HeroesMutationType.DeleteHeroSuccess](state, hero: Hero) {
    state.deletedHero = hero;
  },
  [HeroesMutationType.GetHeroesSuccess](state, heroes: Hero[]) {
    state.heroes = heroes;
  },
} as MutationTree<HeroesState> & HeroesMutations;
