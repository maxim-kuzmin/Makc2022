import { Hero } from '@/models/Hero';
import { MutationTree } from 'vuex';
import { createInitialState, HeroSearchState } from './state';

export enum HeroSearchMutationType {
  Clear = '[components/HeroSearch] Clear',
  GetHeroesSuccess = '[components/HeroSearch] Get Heroes Success',
}

export type HeroSearchMutations = {
  [HeroSearchMutationType.Clear](state: HeroSearchState): void;
  [HeroSearchMutationType.GetHeroesSuccess](
    state: HeroSearchState,
    heroes: Hero[]
  ): void;
};

export default {
  [HeroSearchMutationType.Clear](state) {
    Object.assign(state, createInitialState());
  },
  [HeroSearchMutationType.GetHeroesSuccess](state, heroes: Hero[]) {
    state.heroes = heroes;
  },
} as MutationTree<HeroSearchState> & HeroSearchMutations;
