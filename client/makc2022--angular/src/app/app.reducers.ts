import {
  componentHeroSearchKey,
  componentMessagesKey,
  viewDashboardKey,
  viewHeroDetailKey,
  viewHeroesKey,
} from './app.keys';
import componentHeroSearch from './components/hero-search/hero-search.slice';
import componentMessages from './components/messages/messages.slice';
import viewDashboard from './views/dashboard/dashboard.slice';
import viewHeroDetail from './views/hero-detail/hero-detail.slice';
import viewHeroes from './views/heroes/heroes.slice';

export default {
  [componentHeroSearchKey]: componentHeroSearch,
  [componentMessagesKey]: componentMessages,
  [viewDashboardKey]: viewDashboard,
  [viewHeroesKey]: viewHeroes,
  [viewHeroDetailKey]: viewHeroDetail,
};
