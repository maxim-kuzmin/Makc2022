/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from 'src/layer1/common/common-functions';
import { EntityLoader } from 'src/layer1/entity/entity-loader';
import { DummyTreeLinkEntityObject } from './dummy-tree-link-entity.object';

export class DummyTreeLinkEntityLoader extends EntityLoader<DummyTreeLinkEntityObject> {
  /** @inheritdoc */
  constructor(entityObject?: DummyTreeLinkEntityObject) {
    super(entityObject ?? ({} as DummyTreeLinkEntityObject));
  }

  /** @inheritdoc */
  override load(
    entityObject: DummyTreeLinkEntityObject,
    loadableProperties?: Set<string>
  ): Set<string> {
    const result = super.load(entityObject, loadableProperties);

    if (result.has(nameof<DummyTreeLinkEntityObject>('id'))) {
      this.entityObject.id = entityObject.id;
    }

    if (result.has(nameof<DummyTreeLinkEntityObject>('parentId'))) {
      this.entityObject.parentId = entityObject.parentId;
    }

    return result;
  }

  /** @inheritdoc */
  protected override createAllPropertiesToLoad(): Set<string> {
    return new Set<string>([
      nameof<DummyTreeLinkEntityObject>('id'),
      nameof<DummyTreeLinkEntityObject>('parentId'),
    ]);
  }
}
