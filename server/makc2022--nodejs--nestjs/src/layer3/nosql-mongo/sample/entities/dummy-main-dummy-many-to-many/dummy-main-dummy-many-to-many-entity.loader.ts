/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from '../../../../../layer1/common/common-functions';
import { EntityLoader } from '../../../../../layer1/entity/entity-loader';
import { DummyMainDummyManyToManyEntityObject } from './dummy-main-dummy-many-to-many-entity.object';

/** Загрузчик сущности "DummyMainDummyManyToMany". */
export class DummyMainDummyManyToManyEntityLoader extends EntityLoader<DummyMainDummyManyToManyEntityObject> {
  /** @inheritdoc */
  constructor(entityObject?: DummyMainDummyManyToManyEntityObject) {
    super(entityObject ?? ({} as DummyMainDummyManyToManyEntityObject));
  }

  /** @inheritdoc */
  override load(
    entityObject: DummyMainDummyManyToManyEntityObject,
    loadableProperties?: Set<string>
  ): Set<string> {
    const result = super.load(entityObject, loadableProperties);

    if (result.has(nameof<DummyMainDummyManyToManyEntityObject>('idOfDummyMainEntity'))) {
      this.entityObject.idOfDummyMainEntity = entityObject.idOfDummyMainEntity;
    }

    if (result.has(nameof<DummyMainDummyManyToManyEntityObject>('idOfDummyManyToManyEntity'))) {
      this.entityObject.idOfDummyManyToManyEntity = entityObject.idOfDummyManyToManyEntity;
    }

    return result;
  }

  /** @inheritdoc */
  protected override createAllPropertiesToLoad(): Set<string> {
    return new Set<string>([
      nameof<DummyMainDummyManyToManyEntityObject>('idOfDummyMainEntity'),
      nameof<DummyMainDummyManyToManyEntityObject>('idOfDummyManyToManyEntity'),
    ]);
  }
}
