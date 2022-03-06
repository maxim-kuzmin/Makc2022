import React, { useContext } from 'react';
import { Module } from './Module';

export const defaultModule = new Module();

export const ModuleContext = React.createContext<Module>(defaultModule);

export function useModuleContext(): Module {
  return useContext(ModuleContext);
}
