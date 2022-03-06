import { inject } from 'vue';
import { Module } from './Module';

export const moduleKey = 'module';

export function injectModule(): Module {
  const result = inject<Module>(moduleKey);
  if (!result) throw new Error('Module is undefined');
  return result;
}
