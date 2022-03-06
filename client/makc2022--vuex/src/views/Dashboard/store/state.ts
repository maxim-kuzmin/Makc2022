import { Hero } from '@/models/Hero';

export interface DashboardState {
  heroes: Hero[];
}

export function createInitialState(): DashboardState {
  return {
    heroes: [],
  } as DashboardState;
}

export default createInitialState();
