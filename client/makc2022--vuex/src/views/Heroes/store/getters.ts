import { Hero } from '@/models/Hero';
import { RootState } from '@/store/root-state';
import { GetterTree } from 'vuex';
import { HeroesState } from './state';

export type HeroesGetters = {
  viewHeroesAddedHero(state: HeroesState): Hero;
  viewHeroesDeletedHero(state: HeroesState): Hero;
  viewHeroesHeroes(state: HeroesState): Hero[];
};

export default {
  viewHeroesAddedHero(state) {
    return state.addedHero;
  },
  viewHeroesDeletedHero(state) {
    return state.deletedHero;
  },
  viewHeroesHeroes(state) {
    return state.heroes;
  },
} as GetterTree<HeroesState, RootState> & HeroesGetters;
