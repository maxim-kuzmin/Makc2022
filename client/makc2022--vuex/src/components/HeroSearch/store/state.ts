import { Hero } from '@/models/Hero';

export interface HeroSearchState {
  heroes: Hero[];
}

export function createInitialState(): HeroSearchState {
  return {
    heroes: [],
  } as HeroSearchState;
}

export default createInitialState();
