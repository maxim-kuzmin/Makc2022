import { Hero } from '@/models/Hero';
import { RootState } from '@/store/root-state';
import { GetterTree } from 'vuex';
import { DashboardState } from './state';

export type DashboardGetters = {
  viewDashboardHeroes(state: DashboardState): Hero[];
};

export default {
  viewDashboardHeroes(state) {
    return state.heroes;
  },
} as GetterTree<DashboardState, RootState> & DashboardGetters;
