import {
  componentHeroSearchKey,
  componentMessagesKey,
  viewDashboardKey,
  viewHeroDetailKey,
  viewHeroesKey,
} from './keys';
import { DashboardState } from '@/views/Dashboard/store';
import { HeroDetailState } from '@/views/HeroDetail/store';
import { HeroesState } from '@/views/Heroes/store';
import { HeroSearchState } from '@/components/HeroSearch/store';
import { MessagesState } from '@/components/Messages/store';

export type RootState = {
  [componentHeroSearchKey]: HeroSearchState;
  [componentMessagesKey]: MessagesState;
  [viewDashboardKey]: DashboardState;
  [viewHeroDetailKey]: HeroDetailState;
  [viewHeroesKey]: HeroesState;
};
