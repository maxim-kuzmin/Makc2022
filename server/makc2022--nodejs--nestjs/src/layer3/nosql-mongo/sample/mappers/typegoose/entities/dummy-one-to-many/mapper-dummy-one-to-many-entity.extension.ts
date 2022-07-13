/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { DummyOneToManyEntityLoader } from 'src/layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.loader';
import { DummyOneToManyEntityObject } from 'src/layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.object';
import { MapperDummyOneToManyEntityObject } from './mapper-dummy-one-to-many-entity.object';

/** Расширение сущности "DummyOneToMany" сопоставителя. */
export class MapperDummyOneToManyEntityExtension {
  private constructor(
    private self: {
      entityObject?: DummyOneToManyEntityObject;
      mapperObject?: MapperDummyOneToManyEntityObject;
    }
  ) {}

  /** Расширить объект сущности.
   * @param entityObject Объект сущности.
   */
  static extEntityObject(entityObject: DummyOneToManyEntityObject) {
    return new MapperDummyOneToManyEntityExtension({ entityObject });
  }

  /** Расширить объект сопоставителя.
   * @param mapperObject Объект сопоставителя.
   */
  static extMapperObject(mapperObject: MapperDummyOneToManyEntityObject) {
    return new MapperDummyOneToManyEntityExtension({ mapperObject });
  }

  /** Преобразовать из объекта сущности в объект сопоставителя.
   * @returns Объект сопоставителя.
   */
  fromEntityToMapperObject(): MapperDummyOneToManyEntityObject {
    const result = new MapperDummyOneToManyEntityObject();

    new DummyOneToManyEntityLoader(result).load(this.self.entityObject);

    return result;
  }

  /** Преобразовать из объекта сопоставителя в объект сущности.
   * @returns Объект сущности.
   */
  fromMapperToEntityObject(): DummyOneToManyEntityObject {
    const loader = new DummyOneToManyEntityLoader();

    loader.load(this.self.mapperObject);

    return loader.entityObject;
  }
}
