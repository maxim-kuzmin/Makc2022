import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { RootState } from '../../app/store';
import { Hero } from '../../models/Hero';
import { HeroService } from '../../services/HeroService';

export interface DashboardState {
  heroes: Hero[];
  status: 'idle' | 'loading' | 'failed';
}

const initialState = {
  heroes: [],
  status: 'idle',
} as DashboardState;

export const getHeroesAsync = createAsyncThunk(
  'views/dashboard/getHeroes',
  async (thunkArg: { heroService: HeroService }) => {
    const heroesValue = await thunkArg.heroService.getHeroes();
    return heroesValue.slice(1, 5);
  }
);

export const dashboardSlice = createSlice({
  name: 'views/dashboard',
  initialState,
  reducers: {
    clear: () => initialState,
  },
  extraReducers: (builder) => {
    builder
      .addCase(getHeroesAsync.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(getHeroesAsync.fulfilled, (state, action) => {
        state.status = 'idle';
        state.heroes = action.payload;
      });
  },
});

export const { clear } = dashboardSlice.actions;

export const selectHeroes = (state: RootState): Hero[] =>
  state.viewDashboard.heroes;

export default dashboardSlice.reducer;
