import { createHero, Hero } from '@/models/Hero';

export interface HeroDetailState {
  hero: Hero;
}

export function createInitialState(): HeroDetailState {
  return {
    hero: createHero(),
  } as HeroDetailState;
}

export default createInitialState();
