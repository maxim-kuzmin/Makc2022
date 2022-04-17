<template>
  <div :class="styles.heroes">
    <h2>{{ t('@@title') }}</h2>
    <div>
      <label :for="inputs.newHeroName.id">{{ t('@@hero-name') }}: </label>
      <input :id="inputs.newHeroName.id" v-model="newHero.name" />
      <button :class="styles['add-button']" @click="addNewHero">
        {{ t('@@action-add-hero') }}
      </button>
    </div>
    <ul>
      <li v-for="hero of heroes" :key="hero.id">
        <router-link :to="{ name: 'Detail', params: { heroId: hero.id } }">
          <span :class="styles.badge">{{ hero.id }}</span> {{ hero.name }}
        </router-link>
        <button
          :class="styles.delete"
          :title="t('@@action-delete-hero')"
          @click="() => deleteHero(hero)"
        >
          x
        </button>
      </li>
    </ul>
  </div>
</template>

<script lang="ts" setup>
import { computed, onMounted, onUnmounted, ref } from 'vue';
import { createHero, Hero } from '@/models/Hero';
import { injectModule } from '@/injectors';
import { HeroesActionType } from './store/actions';
import { useStore } from '@/store';
import { HeroesMutationType } from './store/mutations';
import { useI18n } from 'vue-i18n';

const { t } = useI18n({
  inheritLocale: true,
  useScope: 'local',
});

const { heroService } = injectModule();

const store = useStore();

const heroes = computed(() => store.getters.viewHeroesHeroes);

const initialNewHero = createHero();

const newHero = ref(initialNewHero);

const inputs = {
  newHeroName: {
    id: 'new-hero',
  },
};

onMounted(() => {
  store.dispatch(HeroesActionType.GetHeroes, { heroService });
});

onUnmounted(() => {
  store.commit(HeroesMutationType.Clear);
});

async function addNewHero(): Promise<unknown> {
  if (newHero.value.name) {
    newHero.value.name = newHero.value.name.trim();
  }

  if (!newHero.value.name) {
    return;
  }

  await store.dispatch(HeroesActionType.AddHero, {
    heroService,
    hero: newHero.value,
  });

  newHero.value = initialNewHero;

  await store.dispatch(HeroesActionType.GetHeroes, { heroService });

  return;
}

async function deleteHero(hero: Hero): Promise<unknown> {
  await store.dispatch(HeroesActionType.DeleteHero, {
    heroService,
    hero,
  });

  return await store.dispatch(HeroesActionType.GetHeroes, { heroService });
}
</script>

<style module="styles">
/* HeroesComponent's private CSS styles */
.heroes {
  display: block;
}

.heroes ul {
  margin: 0 0 2em 0;
  list-style-type: none;
  padding: 0;
  width: 15em;
}

.heroes input {
  display: block;
  width: 100%;
  padding: 0.5rem;
  margin: 1rem 0;
  box-sizing: border-box;
}

.heroes li {
  position: relative;
  cursor: pointer;
}

.heroes li:hover {
  left: 0.1em;
}

.heroes a {
  color: #333;
  text-decoration: none;
  background-color: #eee;
  margin: 0.5em;
  padding: 0.3em 0;
  height: 1.6em;
  border-radius: 4px;
  display: block;
  width: 100%;
}

.heroes a:hover {
  color: #2c3a41;
  background-color: #e6e6e6;
}

.heroes a:active {
  background-color: #525252;
  color: #fafafa;
}

.heroes .badge {
  display: inline-block;
  font-size: small;
  color: white;
  padding: 0.8em 0.7em 0 0.7em;
  background-color: #405061;
  line-height: 1em;
  position: relative;
  left: -1px;
  top: -4px;
  height: 1.8em;
  min-width: 16px;
  text-align: right;
  margin-right: 0.8em;
  border-radius: 4px 0 0 4px;
}

.heroes .add-button {
  padding: 0.5rem 1.5rem;
  font-size: 1rem;
  margin-bottom: 2rem;
}

.heroes .add-button:hover {
  color: white;
  background-color: #42545c;
}

.heroes button.delete {
  position: absolute;
  left: 210px;
  top: 5px;
  background-color: white;
  color: #525252;
  font-size: 1.1rem;
  padding: 1px 10px 3px 10px;
  margin-top: 0;
}

.heroes button.delete:hover {
  background-color: #525252;
  color: white;
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
    "@@action-add-hero": "Add hero",
    "@@action-delete-hero": "delete hero",
    "@@hero-name": "Hero name",
    "@@title": "My Heroes"
  },
  "ru": {
    "@@action-add-hero": "Добавить героя",
    "@@action-delete-hero": "удалить героя",
    "@@hero-name": "Имя героя",
    "@@title": "Мои герои"
  }
}
</i18n>
