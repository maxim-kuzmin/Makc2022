import { HeroService } from '@/services/HeroService';
import { Hero } from '@/models/Hero';
import { RootState } from '@/store/root-state';
import { ActionContext as BaseActionContext, ActionTree } from 'vuex';
import { HeroesMutations, HeroesMutationType } from './mutations';
import { HeroesState } from './state';

export enum HeroesActionType {
  AddHero = '[views/Heroes] Add Hero',
  DeleteHero = '[views/Heroes] Delete Hero',
  GetHeroes = '[views/Heroes] Get Heroes',
}

interface ActionContext
  extends Omit<BaseActionContext<HeroesState, RootState>, 'commit'> {
  commit<K extends keyof HeroesMutations>(
    key: K,
    payload: Parameters<HeroesMutations[K]>[1]
  ): ReturnType<HeroesMutations[K]>;
}

export interface AddHeroPayload {
  heroService: HeroService;
  hero: Hero;
}

export interface DeleteHeroPayload {
  heroService: HeroService;
  hero: Hero;
}

export interface GetHeroesPayload {
  heroService: HeroService;
}

export type HeroesActions = {
  [HeroesActionType.AddHero](
    context: ActionContext,
    payload: AddHeroPayload
  ): Promise<Hero>;
  [HeroesActionType.DeleteHero](
    context: ActionContext,
    payload: DeleteHeroPayload
  ): Promise<Hero>;
  [HeroesActionType.GetHeroes](
    context: ActionContext,
    payload: GetHeroesPayload
  ): Promise<Hero[]>;
};

export default {
  async [HeroesActionType.AddHero]({ commit }, { heroService, hero }) {
    const result = await heroService.addHero(hero);
    commit(HeroesMutationType.AddHeroSuccess, result);
    return result;
  },
  async [HeroesActionType.DeleteHero]({ commit }, { heroService, hero }) {
    const result = await heroService.deleteHero(hero.id);
    commit(HeroesMutationType.DeleteHeroSuccess, result);
    return result;
  },
  async [HeroesActionType.GetHeroes]({ commit }, { heroService }) {
    const result = await heroService.getHeroes();
    commit(HeroesMutationType.GetHeroesSuccess, result);
    return result;
  },
} as ActionTree<HeroesState, RootState> & HeroesActions;
