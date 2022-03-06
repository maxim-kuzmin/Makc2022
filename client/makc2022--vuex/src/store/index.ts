import { InjectionKey } from 'vue';
import { createStore, useStore as baseUseStore } from 'vuex';
import componentHeroSearch, {
  HeroSearchStore,
} from '@/components/HeroSearch/store';
import componentMessages, { MessagesStore } from '@/components/Messages/store';
import viewDashboard, { DashboardStore } from '@/views/Dashboard/store';
import viewHeroDetail, { HeroDetailStore } from '@/views/HeroDetail/store';
import viewHeroes, { HeroesStore } from '@/views/Heroes/store';
import {
  componentHeroSearchKey,
  componentMessagesKey,
  viewDashboardKey,
  viewHeroDetailKey,
  viewHeroesKey,
} from './keys';
import { RootState } from './root-state';

export type Store = HeroSearchStore<
  Pick<RootState, typeof componentHeroSearchKey>
> &
  MessagesStore<Pick<RootState, typeof componentMessagesKey>> &
  DashboardStore<Pick<RootState, typeof viewDashboardKey>> &
  HeroDetailStore<Pick<RootState, typeof viewHeroDetailKey>> &
  HeroesStore<Pick<RootState, typeof viewHeroesKey>>;

export const key: InjectionKey<Store> = Symbol();

export const store = createStore({
  modules: {
    [componentHeroSearchKey]: componentHeroSearch,
    [componentMessagesKey]: componentMessages,
    [viewDashboardKey]: viewDashboard,
    [viewHeroDetailKey]: viewHeroDetail,
    [viewHeroesKey]: viewHeroes,
  },
});

export function useStore(): Store {
  return baseUseStore<RootState>(key);
}
