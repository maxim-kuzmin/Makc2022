import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '../../app/store';
import { createHero, Hero } from '../../models/Hero';
import { HeroService } from '../../services/HeroService';

export interface HeroDetailState {
  hero: Hero;
  status: 'idle' | 'loading' | 'failed';
}

const initialState = {
  hero: createHero(),
  status: 'idle',
} as HeroDetailState;

export const getHeroAsync = createAsyncThunk(
  'views/heroDetail/getHero',
  async (thunkArg: { heroService: HeroService; id: number }) =>
    thunkArg.heroService.getHero(thunkArg.id)
);

export const updateHeroAsync = createAsyncThunk(
  'views/heroDetail/updateHero',
  async (thunkArg: { heroService: HeroService; hero: Hero }) => {
    await thunkArg.heroService.updateHero(thunkArg.hero);
    return thunkArg.hero;
  }
);

export const heroDetailSlice = createSlice({
  name: 'views/heroDetail',
  initialState,
  reducers: {
    clear: () => initialState,
    setHero: (state, action: PayloadAction<Hero>) => {
      state.hero = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getHeroAsync.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(getHeroAsync.fulfilled, (state, action) => {
        state.status = 'idle';
        state.hero = action.payload;
      })
      .addCase(updateHeroAsync.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(updateHeroAsync.fulfilled, (state, action) => {
        state.status = 'idle';
        state.hero = action.payload;
      });
  },
});

export const { clear, setHero } = heroDetailSlice.actions;

export const selectHero = (state: RootState): Hero => state.viewHeroDetail.hero;

export default heroDetailSlice.reducer;
