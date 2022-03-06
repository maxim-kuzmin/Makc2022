import {
  createAction,
  createFeatureSelector,
  createReducer,
  createSelector,
  on,
  props,
} from '@ngrx/store';
import { componentMessagesKey } from '../../app.keys';

export interface MessagesState {
  messages: string[];
}

const initialState = {
  messages: [],
} as MessagesState;

export const clear = createAction('[components/Messages] Clear');

export const getMessagesSuccess = createAction(
  '[components/Messages] Get Messages Success',
  props<{ messages: string[] }>()
);

export default createReducer(
  initialState,
  on(clear, (): MessagesState => {
    return initialState;
  }),
  on(getMessagesSuccess, (state, { messages }): MessagesState => {
    return { ...state, messages };
  })
);

export const selectMessagesState =
  createFeatureSelector<MessagesState>(componentMessagesKey);

export const selectMessages = createSelector(
  selectMessagesState,
  (state) => state.messages
);
