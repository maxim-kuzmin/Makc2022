import { Hero } from '@/models/Hero';
import { RootState } from '@/store/root-state';
import { GetterTree } from 'vuex';
import { HeroSearchState } from './state';

export type HeroSearchGetters = {
  componentHeroSearchHeroes(state: HeroSearchState): Hero[];
};

export default {
  componentHeroSearchHeroes(state) {
    return state.heroes;
  },
} as GetterTree<HeroSearchState, RootState> & HeroSearchGetters;
