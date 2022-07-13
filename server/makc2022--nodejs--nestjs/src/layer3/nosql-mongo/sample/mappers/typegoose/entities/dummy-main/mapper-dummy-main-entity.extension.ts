/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { DummyMainEntityLoader } from 'src/layer3/nosql-mongo/sample/entities/dummy-main/dummy-main-entity.loader';
import { DummyMainEntityObject } from 'src/layer3/nosql-mongo/sample/entities/dummy-main/dummy-main-entity.object';
import { MapperDummyMainEntityObject } from './mapper-dummy-main-entity.object';

/** Расширение сущности "DummyMain" сопоставителя. */
export class MapperDummyMainEntityExtension {
  private constructor(
    private self: {
      entityObject?: DummyMainEntityObject;
      mapperObject?: MapperDummyMainEntityObject;
    }
  ) {}

  /** Расширить объект сущности.
   * @param entityObject Объект сущности.
   */
  static extEntityObject(entityObject: DummyMainEntityObject) {
    return new MapperDummyMainEntityExtension({ entityObject });
  }

  /** Расширить объект сопоставителя.
   * @param mapperObject Объект сопоставителя.
   */
  static extMapperObject(mapperObject: MapperDummyMainEntityObject) {
    return new MapperDummyMainEntityExtension({ mapperObject });
  }

  /** Преобразовать из объекта сущности в объект сопоставителя.
   * @returns Объект сопоставителя.
   */
  fromEntityToMapperObject(): MapperDummyMainEntityObject {
    const result = new MapperDummyMainEntityObject();

    new DummyMainEntityLoader(result).load(this.self.entityObject);

    return result;
  }

  /** Преобразовать из объекта сопоставителя в объект сущности.
   * @returns Объект сущности.
   */
  fromMapperToEntityObject(): DummyMainEntityObject {
    const loader = new DummyMainEntityLoader();

    loader.load(this.self.mapperObject);

    return loader.entityObject;
  }
}
