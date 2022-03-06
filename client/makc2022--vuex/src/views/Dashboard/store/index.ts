import { RootState } from '@/store/root-state';
import {
  Store as BaseStore,
  CommitOptions,
  DispatchOptions,
  Module,
} from 'vuex';
import actions, { DashboardActions } from './actions';
import getters, { DashboardGetters } from './getters';
import mutations, { DashboardMutations } from './mutations';
import state, { DashboardState } from './state';

export { DashboardState };

export interface DashboardStore<S = DashboardState>
  extends Omit<BaseStore<S>, 'getters' | 'commit' | 'dispatch'> {
  commit<
    K extends keyof DashboardMutations,
    P extends Parameters<DashboardMutations[K]>[1]
  >(
    key: K,
    payload?: P,
    options?: CommitOptions
  ): ReturnType<DashboardMutations[K]>;
  dispatch<K extends keyof DashboardActions>(
    key: K,
    payload?: Parameters<DashboardActions[K]>[1],
    options?: DispatchOptions
  ): ReturnType<DashboardActions[K]>;
  getters: {
    [K in keyof DashboardGetters]: ReturnType<DashboardGetters[K]>;
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
} as Module<DashboardState, RootState>;
