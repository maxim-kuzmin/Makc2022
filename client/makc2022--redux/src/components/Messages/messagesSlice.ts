import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '../../app/store';

export interface MessagesState {
  messages: string[];
}

const initialState = {
  messages: [],
} as MessagesState;

export const messagesSlice = createSlice({
  name: 'components/messages',
  initialState,
  reducers: {
    clear: () => initialState,
    setMessages: (state, action: PayloadAction<string[]>) => {
      state.messages = action.payload;
    },
  },
});

export const { clear, setMessages } = messagesSlice.actions;

export const selectMessages = (state: RootState): string[] =>
  state.componentMessages.messages;

export default messagesSlice.reducer;
