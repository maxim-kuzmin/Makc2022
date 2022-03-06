import { RootState } from '@/store/root-state';
import {
  Store as BaseStore,
  CommitOptions,
  DispatchOptions,
  Module,
} from 'vuex';
import actions, { HeroesActions } from './actions';
import getters, { HeroesGetters } from './getters';
import mutations, { HeroesMutations } from './mutations';
import state, { HeroesState } from './state';

export { HeroesState };

export interface HeroesStore<S = HeroesState>
  extends Omit<BaseStore<S>, 'getters' | 'commit' | 'dispatch'> {
  commit<
    K extends keyof HeroesMutations,
    P extends Parameters<HeroesMutations[K]>[1]
  >(
    key: K,
    payload?: P,
    options?: CommitOptions
  ): ReturnType<HeroesMutations[K]>;
  dispatch<K extends keyof HeroesActions>(
    key: K,
    payload?: Parameters<HeroesActions[K]>[1],
    options?: DispatchOptions
  ): ReturnType<HeroesActions[K]>;
  getters: {
    [K in keyof HeroesGetters]: ReturnType<HeroesGetters[K]>;
  };
}

export default {
  state,
  mutations,
  actions,
  getters,
  // TODO: With namespaced option turned on, having problem how to use dispatch with action types...
  // But without it, a bigger store might have clashes in namings
  // namespaced: true,
} as Module<HeroesState, RootState>;
