export interface MessagesState {
  messages: string[];
}

export function createInitialState(): MessagesState {
  return {
    messages: [],
  } as MessagesState;
}

export default createInitialState();
