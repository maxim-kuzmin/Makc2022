import { RootState } from '@/store/root-state';
import {
  Store as BaseStore,
  CommitOptions,
  DispatchOptions,
  Module,
} from 'vuex';
import actions, { HeroSearchActions } from './actions';
import getters, { HeroSearchGetters } from './getters';
import mutations, { HeroSearchMutations } from './mutations';
import state, { HeroSearchState } from './state';

export { HeroSearchState };

export interface HeroSearchStore<S = HeroSearchState>
  extends Omit<BaseStore<S>, 'getters' | 'commit' | 'dispatch'> {
  commit<
    K extends keyof HeroSearchMutations,
    P extends Parameters<HeroSearchMutations[K]>[1]
  >(
    key: K,
    payload?: P,
    options?: CommitOptions
  ): ReturnType<HeroSearchMutations[K]>;
  dispatch<K extends keyof HeroSearchActions>(
    key: K,
    payload?: Parameters<HeroSearchActions[K]>[1],
    options?: DispatchOptions
  ): ReturnType<HeroSearchActions[K]>;
  getters: {
    [K in keyof HeroSearchGetters]: ReturnType<HeroSearchGetters[K]>;
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
} as Module<HeroSearchState, RootState>;
