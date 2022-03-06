<template>
  <div v-if="messages.length" :class="styles.messages">
    <h2>Messages</h2>
    <button :class="styles.clear" @click="messageService.clear()">
      Clear messages
    </button>
    <div v-for="(message, index) of messages" :key="index">
      {{ message }}
    </div>
  </div>
</template>

<script lang="ts" setup>
import { computed, onMounted, onUnmounted } from 'vue';
import { injectModule } from '@/injectors';
import { useStore } from '@/store';
import { MessagesMutationType } from './store/mutations';

const { messageService } = injectModule();

const store = useStore();

const messages = computed(() => store.getters.componentMessagesMessages);

let subscriptionId = '';

onMounted(() => {
  subscriptionId = messageService.subscribe((messagesValue) => {
    store.commit(MessagesMutationType.GetMessagesSuccess, messagesValue);
  });
});

onUnmounted(() => {
  messageService.unsubscribe(subscriptionId);
});
</script>

<style module="styles">
/* MessagesComponent's private CSS styles */
.messages {
  display: block;
}
.messages h2 {
  color: #a80000;
  font-family: Arial, Helvetica, sans-serif;
  font-weight: lighter;
}
.messages .clear {
  color: #333;
  background-color: #eee;
  margin-bottom: 12px;
  padding: 1rem;
  border-radius: 4px;
  font-size: 1rem;
}
.messages .clear:hover {
  color: #fff;
  background-color: #42545c;
}

/*
Copyright Google LLC. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at https://angular.io/license
*/
</style>
