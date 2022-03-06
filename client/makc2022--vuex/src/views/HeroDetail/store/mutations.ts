import { Hero } from '@/models/Hero';
import { MutationTree } from 'vuex';
import { createInitialState, HeroDetailState } from './state';

export enum HeroDetailMutationType {
  Clear = '[views/HeroDetail] Clear',
  GetHeroSuccess = '[views/HeroDetail] Get Hero Success',
}

export type HeroDetailMutations = {
  [HeroDetailMutationType.Clear](state: HeroDetailState): void;
  [HeroDetailMutationType.GetHeroSuccess](
    state: HeroDetailState,
    hero: Hero
  ): void;
};

export default {
  [HeroDetailMutationType.Clear](state) {
    Object.assign(state, createInitialState());
  },
  [HeroDetailMutationType.GetHeroSuccess](state, hero: Hero) {
    state.hero = hero;
  },
} as MutationTree<HeroDetailState> & HeroDetailMutations;
