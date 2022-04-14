<template>
  <div :class="styles.app">
    <h1>{{ t('@@title') }}</h1>
    <div :class="styles['top-menu']">
      <nav>
        <router-link to="/dashboard">Dashboard</router-link>
        <router-link to="/heroes">Heroes</router-link>
      </nav>
      <select v-model="$i18n.locale">
        <option
          v-for="language in languages"
          :key="language.value"
          :value="language.value"
        >
          {{ language.text }}
        </option>
      </select>
    </div>
    <router-view />
    <Messages />
  </div>
</template>

<script lang="ts" setup>
import { provide } from 'vue';
import { moduleKey } from './injectors';
import { Module } from './Module';
import Messages from '@/components/Messages/index.vue';
import { useI18n } from 'vue-i18n';

const { t, availableLocales } = useI18n({
  inheritLocale: true,
  useScope: 'local',
});

provide(moduleKey, new Module());

const languages: { text: string; value: string }[] = [];

availableLocales.forEach((locale) => {
  let text = '';

  switch (locale) {
    case 'en':
      text = 'English';
      break;
    case 'ru':
      text = 'Русский';
      break;
    default:
      return;
  }

  languages.push({ text, value: locale });
});
</script>

<style>
* {
  font-family: Arial, Helvetica, sans-serif;
}
h1 {
  color: #264d73;
  font-size: 2.5rem;
}
h2,
h3 {
  color: #444;
  font-weight: lighter;
}
h3 {
  font-size: 1.3rem;
}
body {
  padding: 0.5rem;
  max-width: 1000px;
  margin: auto;
}
@media (min-width: 600px) {
  body {
    padding: 2rem;
  }
}
body,
input[text] {
  color: #333;
  font-family: Cambria, Georgia, serif;
}
a {
  cursor: pointer;
}
button {
  background-color: #eee;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  color: black;
  font-size: 1.2rem;
  padding: 1rem;
  margin-right: 1rem;
  margin-bottom: 1rem;
  margin-top: 1rem;
}
button:hover {
  background-color: black;
  color: white;
}
button:disabled {
  background-color: #eee;
  color: #aaa;
  cursor: auto;
}

/* Navigation link styles */
nav a {
  padding: 5px 10px;
  text-decoration: none;
  margin-right: 10px;
  margin-top: 10px;
  display: inline-block;
  background-color: #e8e8e8;
  color: #3d3d3d;
  border-radius: 4px;
}

nav a:hover {
  color: white;
  background-color: #42545c;
}
nav a.active {
  background-color: black;
  color: white;
}
hr {
  margin: 1.5rem 0;
}
input[type='text'] {
  box-sizing: border-box;
  width: 100%;
  padding: 0.5rem;
}
</style>

<style module="styles">
.app {
  display: block;
}
h1 {
  margin-bottom: 0;
}
nav {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  justify-content: flex-start;
}
nav a {
  padding: 1rem;
  text-decoration: none;
  margin: 10px 10px 0 0;
  display: inline-block;
  background-color: #e8e8e8;
  color: #3d3d3d;
  border-radius: 4px;
}
nav a:hover {
  color: white;
  background-color: #42545c;
}
nav a.active {
  background-color: black;
}

.top-menu {
  display: flex;
  justify-content: space-between;
}

.top-menu select {
  padding: 1rem;
  margin: 10px 0 0 0;
}
</style>

<i18n>
{
  "en": {
    "@@title": "Tour of Heroes"
  },
  "ru": {
    "@@title": "Тур героев"
  }
}
</i18n>
