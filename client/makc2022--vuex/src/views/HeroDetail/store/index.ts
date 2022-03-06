import { RootState } from '@/store/root-state';
import {
  Store as BaseStore,
  CommitOptions,
  DispatchOptions,
  Module,
} from 'vuex';
import actions, { HeroDetailActions } from './actions';
import getters, { HeroDetailGetters } from './getters';
import mutations, { HeroDetailMutations } from './mutations';
import state, { HeroDetailState } from './state';

export { HeroDetailState };

export interface HeroDetailStore<S = HeroDetailState>
  extends Omit<BaseStore<S>, 'getters' | 'commit' | 'dispatch'> {
  commit<
    K extends keyof HeroDetailMutations,
    P extends Parameters<HeroDetailMutations[K]>[1]
  >(
    key: K,
    payload?: P,
    options?: CommitOptions
  ): ReturnType<HeroDetailMutations[K]>;
  dispatch<K extends keyof HeroDetailActions>(
    key: K,
    payload?: Parameters<HeroDetailActions[K]>[1],
    options?: DispatchOptions
  ): ReturnType<HeroDetailActions[K]>;
  getters: {
    [K in keyof HeroDetailGetters]: ReturnType<HeroDetailGetters[K]>;
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
} as Module<HeroDetailState, RootState>;
