/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from 'src/layer1/common/common-functions';
import { EntityLoader } from 'src/layer1/entity/entity-loader';
import { DummyManyToManyEntityObject } from './dummy-many-to-many-entity.object';

export class DummyManyToManyEntityLoader extends EntityLoader<DummyManyToManyEntityObject> {
  /** @inheritdoc */
  constructor(entityObject?: DummyManyToManyEntityObject) {
    super(entityObject ?? ({} as DummyManyToManyEntityObject));
  }

  /** @inheritdoc */
  override load(
    entityObject: DummyManyToManyEntityObject,
    loadableProperties?: Set<string>
  ): Set<string> {
    const result = super.load(entityObject, loadableProperties);

    if (result.has(nameof<DummyManyToManyEntityObject>('id'))) {
      this.entityObject.id = entityObject.id;
    }

    if (result.has(nameof<DummyManyToManyEntityObject>('name'))) {
      this.entityObject.name = entityObject.name;
    }

    return result;
  }

  /** @inheritdoc */
  protected override createAllPropertiesToLoad(): Set<string> {
    return new Set<string>([
      nameof<DummyManyToManyEntityObject>('id'),
      nameof<DummyManyToManyEntityObject>('name'),
    ]);
  }
}
