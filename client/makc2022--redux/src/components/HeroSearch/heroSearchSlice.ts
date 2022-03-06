import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { RootState } from '../../app/store';
import { Hero } from '../../models/Hero';
import { HeroService } from '../../services/HeroService';

export interface HeroSearchState {
  heroes: Hero[];
  status: 'idle' | 'loading' | 'failed';
}

const initialState = {
  heroes: [],
  status: 'idle',
} as HeroSearchState;

export const getHeroesAsync = createAsyncThunk(
  'components/heroSearch/getHeroes',
  async (thunkArg: { heroService: HeroService; term: string }) =>
    thunkArg.heroService.searchHeroes(thunkArg.term)
);

export const heroSearchSlice = createSlice({
  name: 'components/heroSearch',
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

export const { clear } = heroSearchSlice.actions;

export const selectHeroes = (state: RootState): Hero[] =>
  state.componentHeroSearch.heroes;

export default heroSearchSlice.reducer;
