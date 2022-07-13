/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { DummyOneToManyEntityObject } from 'src/layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.object';

/** Выходные данные запроса на получение элемента в домене. */
export class DomainItemGetQueryOutput {
  /** Объект сущности "DummyOneToMany". */
  objectOfDummyOneToManyEntity: DummyOneToManyEntityObject;
}
