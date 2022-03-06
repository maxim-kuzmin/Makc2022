import { HeroService } from '@/services/HeroService';
import { Hero } from '@/models/Hero';
import { RootState } from '@/store/root-state';
import { ActionContext as BaseActionContext, ActionTree } from 'vuex';
import { HeroDetailMutations, HeroDetailMutationType } from './mutations';
import { HeroDetailState } from './state';

export enum HeroDetailActionType {
  GetHero = '[views/HeroDetail] Get Hero',
  UpdateHero = '[views/HeroDetail] Update Hero',
}

interface ActionContext
  extends Omit<BaseActionContext<HeroDetailState, RootState>, 'commit'> {
  commit<K extends keyof HeroDetailMutations>(
    key: K,
    payload: Parameters<HeroDetailMutations[K]>[1]
  ): ReturnType<HeroDetailMutations[K]>;
}

export interface GetHeroPayload {
  heroService: HeroService;
  id: number;
}

export interface UpdateHeroPayload {
  heroService: HeroService;
  hero: Hero;
}

export type HeroDetailActions = {
  [HeroDetailActionType.GetHero](
    context: ActionContext,
    payload: GetHeroPayload
  ): Promise<Hero>;
  [HeroDetailActionType.UpdateHero](
    context: ActionContext,
    payload: UpdateHeroPayload
  ): Promise<Hero>;
};

export default {
  async [HeroDetailActionType.GetHero]({ commit }, { heroService, id }) {
    const result = await heroService.getHero(id);
    commit(HeroDetailMutationType.GetHeroSuccess, result);
    return result;
  },
  async [HeroDetailActionType.UpdateHero]({ commit }, { heroService, hero }) {
    const result = await heroService.updateHero(hero);
    commit(HeroDetailMutationType.GetHeroSuccess, result);
    return result;
  },
} as ActionTree<HeroDetailState, RootState> & HeroDetailActions;
