import { RootState } from '@/store/root-state';
import { GetterTree } from 'vuex';
import { MessagesState } from './state';

export type MessagesGetters = {
  componentMessagesMessages(state: MessagesState): string[];
};

export default {
  componentMessagesMessages(state) {
    return state.messages;
  },
} as GetterTree<MessagesState, RootState> & MessagesGetters;
