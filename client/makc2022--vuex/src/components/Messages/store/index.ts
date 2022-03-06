import { RootState } from '@/store/root-state';
import { Store as BaseStore, CommitOptions, Module } from 'vuex';
import getters, { MessagesGetters } from './getters';
import mutations, { MessagesMutations } from './mutations';
import state, { MessagesState } from './state';

export { MessagesState };

export interface MessagesStore<S = MessagesState>
  extends Omit<BaseStore<S>, 'getters' | 'commit'> {
  commit<
    K extends keyof MessagesMutations,
    P extends Parameters<MessagesMutations[K]>[1]
  >(
    key: K,
    payload?: P,
    options?: CommitOptions
  ): ReturnType<MessagesMutations[K]>;
  getters: {
    [K in keyof MessagesGetters]: ReturnType<MessagesGetters[K]>;
  };
}

export default {
  state,
  mutations,
  getters,
  // TODO: With namespaced option turned on, having problem how to use dispatch with action types...
  // But without it, a bigger store might have clashes in namings
  // namespaced: true,
} as Module<MessagesState, RootState>;
