<template>
  <div :class="styles.dashboard">
    <h2>{{ t('@@title') }}</h2>
    <div :class="styles['heroes-menu']">
      <router-link
        v-for="hero of heroes"
        :to="{ name: 'Detail', params: { heroId: hero.id } }"
        :key="hero.id"
      >
        {{ hero.name }}
      </router-link>
    </div>
  </div>
  <HeroSearch />
</template>

<script lang="ts" setup>
import { computed, onMounted, onUnmounted } from 'vue';
import HeroSearch from '@/components/HeroSearch/index.vue';
import { injectModule } from '@/injectors';
import { useStore } from '@/store';
import { DashboardActionType } from './store/actions';
import { DashboardMutationType } from './store/mutations';
import { useI18n } from 'vue-i18n';

const { t } = useI18n({
  inheritLocale: true,
  useScope: 'local',
});

const { heroService } = injectModule();

const store = useStore();

const heroes = computed(() => store.getters.viewDashboardHeroes);

onMounted(() => {
  store.dispatch(DashboardActionType.GetHeroes, { heroService });
});

onUnmounted(() => {
  store.commit(DashboardMutationType.Clear);
});
</script>

<style module="styles">
/* DashboardComponent's private CSS styles */
.dashboard {
  display: block;
}

.dashboard h2 {
  text-align: center;
}

.dashboard .heroes-menu {
  padding: 0;
  margin: auto;
  max-width: 1000px;

  /* flexbox */
  display: -webkit-box;
  display: -moz-box;
  display: -ms-flexbox;
  display: -webkit-flex;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: space-around;
  align-content: flex-start;
  align-items: flex-start;
}

.dashboard a {
  background-color: #3f525c;
  border-radius: 2px;
  padding: 1rem;
  font-size: 1.2rem;
  text-decoration: none;
  display: inline-block;
  color: #fff;
  text-align: center;
  width: 100%;
  min-width: 70px;
  margin: 0.5rem auto;
  box-sizing: border-box;

  /* flexbox */
  order: 0;
  flex: 0 1 auto;
  align-self: auto;
}

@media (min-width: 600px) {
  .dashboard a {
    width: 18%;
    box-sizing: content-box;
  }
}

.dashboard a:hover {
  background-color: black;
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
</style>

<i18n>
{
  "en": {
    "@@title": "Top Heroes"
  },
  "ru": {
    "@@title": "Лучшие герои"
  }
}
</i18n>
