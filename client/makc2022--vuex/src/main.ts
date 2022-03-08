import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import { store, key } from './store';
import i18n from './i18n';

createApp(App).use(i18n).use(store, key).use(router).mount('#app');
