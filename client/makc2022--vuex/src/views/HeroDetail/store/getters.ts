import { Hero } from '@/models/Hero';
import { RootState } from '@/store/root-state';
import { GetterTree } from 'vuex';
import { HeroDetailState } from './state';

export type HeroDetailGetters = {
  viewHeroDetailHero(state: HeroDetailState): Hero;
};

export default {
  viewHeroDetailHero(state) {
    return state.hero;
  },
} as GetterTree<HeroDetailState, RootState> & HeroDetailGetters;
