import { Hero } from '@/models/Hero';
import { MutationTree } from 'vuex';
import { createInitialState, DashboardState } from './state';

export enum DashboardMutationType {
  Clear = '[views/Dashboard] Clear',
  GetHeroesSuccess = '[views/Dashboard] Get Heroes Success',
}

export type DashboardMutations = {
  [DashboardMutationType.Clear](state: DashboardState): void;
  [DashboardMutationType.GetHeroesSuccess](
    state: DashboardState,
    heroes: Hero[]
  ): void;
};

export default {
  [DashboardMutationType.Clear](state) {
    Object.assign(state, createInitialState());
  },
  [DashboardMutationType.GetHeroesSuccess](state, heroes: Hero[]) {
    state.heroes = heroes;
  },
} as MutationTree<DashboardState> & DashboardMutations;
