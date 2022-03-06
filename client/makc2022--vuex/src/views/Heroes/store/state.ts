import { createHero, Hero } from '@/models/Hero';

export interface HeroesState {
  heroes: Hero[];
  addedHero: Hero;
  deletedHero: Hero;
}

export function createInitialState(): HeroesState {
  return {
    heroes: [],
    addedHero: createHero(),
    deletedHero: createHero(),
  } as HeroesState;
}

export default createInitialState();
