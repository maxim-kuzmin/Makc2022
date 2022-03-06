import { HeroService } from '@/services/HeroService';
import { Hero } from '@/models/Hero';
import { RootState } from '@/store/root-state';
import { ActionContext as BaseActionContext, ActionTree } from 'vuex';
import { HeroSearchMutations, HeroSearchMutationType } from './mutations';
import { HeroSearchState } from './state';

export enum HeroSearchActionType {
  GetHeroes = '[components/HeroSearch] Get Heroes',
}

interface ActionContext
  extends Omit<BaseActionContext<HeroSearchState, RootState>, 'commit'> {
  commit<K extends keyof HeroSearchMutations>(
    key: K,
    payload: Parameters<HeroSearchMutations[K]>[1]
  ): ReturnType<HeroSearchMutations[K]>;
}

export interface GetHeroesPayload {
  heroService: HeroService;
  term: string;
}

export type HeroSearchActions = {
  [HeroSearchActionType.GetHeroes](
    context: ActionContext,
    payload: GetHeroesPayload
  ): Promise<Hero[]>;
};

export default {
  async [HeroSearchActionType.GetHeroes]({ commit }, { heroService, term }) {
    const result = await heroService.searchHeroes(term);
    commit(HeroSearchMutationType.GetHeroesSuccess, result);
    return result;
  },
} as ActionTree<HeroSearchState, RootState> & HeroSearchActions;
