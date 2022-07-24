/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { DummyMainDummyManyToManyEntityObject } from '../../../../../../layer3/nosql-mongo/sample/entities/dummy-main-dummy-many-to-many/dummy-main-dummy-many-to-many-entity.object';
import { DummyMainEntityObject } from '../../../../../../layer3/nosql-mongo/sample/entities/dummy-main/dummy-main-entity.object';
import { DummyManyToManyEntityObject } from '../../../../../../layer3/nosql-mongo/sample/entities/dummy-many-to-many/dummy-many-to-many-entity.object';
import { DummyOneToManyEntityObject } from '../../../../../../layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.object';

/** Выходные данные запроса на получение элемента в домене. */
export class DomainItemGetQueryOutput {
  /** Объект сущности "DummyMain". */
  objectOfDummyMainEntity: DummyMainEntityObject;

  /** Объекты сущности "DummyManyToMany". */
  objectsOfDummyManyToManyEntity: DummyManyToManyEntityObject[];

  /** Объекты сущности "DummyMainDummyManyToMany". */
  objectsOfDummyMainDummyManyToManyEntity: DummyMainDummyManyToManyEntityObject[];

  /** Объект сущности "DummyOneToMany". */
  objectOfDummyOneToManyEntity: DummyOneToManyEntityObject;
}
