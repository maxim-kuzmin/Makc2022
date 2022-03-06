import { MutationTree } from 'vuex';
import { createInitialState, MessagesState } from './state';

export enum MessagesMutationType {
  Clear = '[components/Messages] Clear',
  GetMessagesSuccess = '[components/Messages] Get Messages Success',
}

export type MessagesMutations = {
  [MessagesMutationType.Clear](state: MessagesState): void;
  [MessagesMutationType.GetMessagesSuccess](
    state: MessagesState,
    messages: string[]
  ): void;
};

export default {
  [MessagesMutationType.Clear](state) {
    Object.assign(state, createInitialState());
  },
  [MessagesMutationType.GetMessagesSuccess](state, messages: string[]) {
    state.messages = messages;
  },
} as MutationTree<MessagesState> & MessagesMutations;
