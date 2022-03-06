import { HeroService } from '@/services/HeroService';
import { Hero } from '@/models/Hero';
import { RootState } from '@/store/root-state';
import { ActionContext as BaseActionContext, ActionTree } from 'vuex';
import { DashboardMutations, DashboardMutationType } from './mutations';
import { DashboardState } from './state';

export enum DashboardActionType {
  GetHeroes = '[views/Dashboard] Get Heroes',
}

interface ActionContext
  extends Omit<BaseActionContext<DashboardState, RootState>, 'commit'> {
  commit<K extends keyof DashboardMutations>(
    key: K,
    payload: Parameters<DashboardMutations[K]>[1]
  ): ReturnType<DashboardMutations[K]>;
}

export interface GetHeroesPayload {
  heroService: HeroService;
}

export type DashboardActions = {
  [DashboardActionType.GetHeroes](
    context: ActionContext,
    payload: GetHeroesPayload
  ): Promise<Hero[]>;
};

export default {
  async [DashboardActionType.GetHeroes]({ commit }, { heroService }) {
    const heroes = await heroService.getHeroes();
    const result = heroes.slice(1, 5);
    commit(DashboardMutationType.GetHeroesSuccess, result);
    return result;
  },
} as ActionTree<DashboardState, RootState> & DashboardActions;
