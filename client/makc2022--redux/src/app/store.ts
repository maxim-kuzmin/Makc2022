import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import componentHeroSearch from '../components/HeroSearch/heroSearchSlice';
import componentMessages from '../components/Messages/messagesSlice';
import viewDashboard from '../views/Dashboard/dashboardSlice';
import viewHeroDetail from '../views/HeroDetail/heroDetailSlice';
import viewHeroes from '../views/Heroes/heroesSlice';

export const store = configureStore({
  reducer: {
    componentHeroSearch,
    componentMessages,
    viewDashboard,
    viewHeroDetail,
    viewHeroes,
  },
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
