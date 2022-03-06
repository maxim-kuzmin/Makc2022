<template>
  <div :class="styles['hero-detail']">
    <div v-if="hero.id > 0">
      <h2>{{ heroName }} Details</h2>
      <div><span>id: </span>{{ hero.id }}</div>
      <div>
        <label :for="inputs.heroName.id">Hero name: </label>
        <input
          :id="inputs.heroName.id"
          v-model="hero.name"
          placeholder="name"
        />
      </div>
    </div>
    <button @click="goBack">go back</button>
    <button @click="save">save</button>
  </div>
</template>

<script lang="ts" setup>
import router from '@/router';
import { computed, onMounted, onUnmounted } from 'vue';
import { injectModule } from '@/injectors';
import { useStore } from '@/store';
import { HeroDetailActionType } from './store/actions';
import { HeroDetailMutationType } from './store/mutations';

const { heroService } = injectModule();

const store = useStore();

const hero = computed(() => store.getters.viewHeroDetailHero);

const inputs = {
  heroName: {
    id: 'hero-name',
  },
};

const heroName = computed(() => hero.value.name.toUpperCase());

const id = Number(router.currentRoute.value.params.heroId);

onMounted(() => {
  store.dispatch(HeroDetailActionType.GetHero, { heroService, id });
});

onUnmounted(() => {
  store.commit(HeroDetailMutationType.Clear);
});

function goBack(): void {
  router.go(-1);
}

async function save(): Promise<unknown> {
  if (hero.value) {
    await store.dispatch(HeroDetailActionType.UpdateHero, {
      heroService,
      hero: hero.value,
    });

    goBack();
  }

  return;
}
</script>

<style module="styles">
/* HeroDetailComponent's private CSS styles */
.hero-detail {
  display: block;
}

.hero-detail label {
  color: #435960;
  font-weight: bold;
}
.hero-detail input {
  font-size: 1em;
  padding: 0.5rem;
}
.hero-detail button {
  margin-top: 20px;
  margin-right: 0.5rem;
  background-color: #eee;
  padding: 1rem;
  border-radius: 4px;
  font-size: 1rem;
}
.hero-detail button:hover {
  background-color: #cfd8dc;
}
.hero-detail button:disabled {
  background-color: #eee;
  color: #ccc;
  cursor: auto;
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
</style>
