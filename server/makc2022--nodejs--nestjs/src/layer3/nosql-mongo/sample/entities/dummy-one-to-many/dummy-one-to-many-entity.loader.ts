/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from '../../../../../layer1/common/common-functions';
import { EntityLoader } from '../../../../../layer1/entity/entity-loader';
import { DummyOneToManyEntityObject } from './dummy-one-to-many-entity.object';

/** Загрузчик сущности "DummyOneToMany". */
export class DummyOneToManyEntityLoader extends EntityLoader<DummyOneToManyEntityObject> {
  /** @inheritdoc */
  constructor(entityObject?: DummyOneToManyEntityObject) {
    super(entityObject ?? ({} as DummyOneToManyEntityObject));
  }

  /** @inheritdoc */
  override load(
    entityObject: DummyOneToManyEntityObject,
    loadableProperties?: Set<string>
  ): Set<string> {
    const result = super.load(entityObject, loadableProperties);

    if (result.has(nameof<DummyOneToManyEntityObject>('id'))) {
      this.entityObject.id = entityObject.id;
    }

    if (result.has(nameof<DummyOneToManyEntityObject>('name'))) {
      this.entityObject.name = entityObject.name;
    }

    return result;
  }

  /** @inheritdoc */
  protected override createAllPropertiesToLoad(): Set<string> {
    return new Set<string>([
      nameof<DummyOneToManyEntityObject>('id'),
      nameof<DummyOneToManyEntityObject>('name'),
    ]);
  }
}
