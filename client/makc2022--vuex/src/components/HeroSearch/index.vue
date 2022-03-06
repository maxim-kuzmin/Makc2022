<template>
  <div id="search-component" :class="styles['hero-search']">
    <label :for="inputs.term.id">Hero Search</label>
    <input :id="inputs.term.id" v-debounce="handleSearchInput" />
    <ul :class="styles['search-result']">
      <li v-for="hero in heroes" :key="hero.id">
        <router-link :to="{ name: 'Detail', params: { heroId: hero.id } }">
          {{ hero.name }}
        </router-link>
      </li>
    </ul>
  </div>
</template>

<script lang="ts" setup>
import { injectModule } from '@/injectors';
import { computed, onUnmounted } from 'vue';
import { getDirective } from 'vue-debounce';
import { useStore } from '@/store';
import { HeroSearchActionType } from './store/actions';
import { HeroSearchMutationType } from './store/mutations';

const { heroService } = injectModule();

const vDebounce = getDirective('3');

const store = useStore();

const heroes = computed(() => store.getters.componentHeroSearchHeroes);

onUnmounted(() => {
  store.commit(HeroSearchMutationType.Clear);
});

const inputs = {
  term: {
    id: 'search-box',
  },
};

function handleSearchInput(term: string): void {
  store.dispatch(HeroSearchActionType.GetHeroes, { heroService, term });
}
</script>

<style module="styles">
/* HeroSearch private styles */
.hero-search {
  display: block;
}
.hero-search label {
  display: block;
  font-weight: bold;
  font-size: 1.2rem;
  margin-top: 1rem;
  margin-bottom: 0.5rem;
}
.hero-search input {
  padding: 0.5rem;
  width: 100%;
  max-width: 600px;
  box-sizing: border-box;
  display: block;
}
.hero-search input:focus {
  outline: #336699 auto 1px;
}
.hero-search li {
  list-style-type: none;
}
.hero-search .search-result li a {
  border-bottom: 1px solid gray;
  border-left: 1px solid gray;
  border-right: 1px solid gray;
  display: inline-block;
  width: 100%;
  max-width: 600px;
  padding: 0.5rem;
  box-sizing: border-box;
  text-decoration: none;
  color: black;
}
.hero-search .search-result li a:hover {
  background-color: #435a60;
  color: white;
}
.hero-search ul.search-result {
  margin-top: 0;
  padding-left: 0;
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
</style>
