import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { RootState } from '../../app/store';
import { Hero } from '../../models/Hero';
import { HeroService } from '../../services/HeroService';

export interface HeroesState {
  heroes: Hero[];
  status: 'idle' | 'loading' | 'failed';
}

const initialState = {
  heroes: [],
  status: 'idle',
} as HeroesState;

export const getHeroesAsync = createAsyncThunk(
  'views/heroes/getHeroes',
  async (thunkArg: { heroService: HeroService }) =>
    thunkArg.heroService.getHeroes()
);

export const addHeroAsync = createAsyncThunk(
  'views/heroes/addHero',
  async (thunkArg: { heroService: HeroService; hero: Hero }) =>
    thunkArg.heroService.addHero(thunkArg.hero)
);

export const deleteHeroAsync = createAsyncThunk(
  'views/heroes/deleteHero',
  async (thunkArg: { heroService: HeroService; hero: Hero }) => {
    await thunkArg.heroService.deleteHero(thunkArg.hero.id);
    return thunkArg.hero;
  }
);

export const heroesSlice = createSlice({
  name: 'views/heroes',
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
      })
      .addCase(addHeroAsync.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(addHeroAsync.fulfilled, (state, action) => {
        state.status = 'idle';
        state.heroes.push(action.payload);
      })
      .addCase(deleteHeroAsync.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(deleteHeroAsync.fulfilled, (state, action) => {
        state.status = 'idle';
        state.heroes = state.heroes.filter((h) => h.id !== action.payload.id);
      });
  },
});

export const { clear } = heroesSlice.actions;

export const selectHeroes = (state: RootState): Hero[] =>
  state.viewHeroes.heroes;

export default heroesSlice.reducer;
