/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { IDummyMainEntityObject } from 'src/layer3/sample/entities/dummy-main/dummy-main-entity-object.interface';

/** Интерфейс объекта сущности "DummyMain" сопоставителя. */
export interface IMapperDummyMainEntityObject extends IDummyMainEntityObject<string> {
  /** Дата создания. */
  createdAt?: Date;

  /** Дата изменения. */
  updatedAt?: Date;
}
