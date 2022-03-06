export interface Hero {
  id: number;
  name: string;
}

export function createHero(): Hero {
  return {
    id: 0,
    name: '',
  };
}
