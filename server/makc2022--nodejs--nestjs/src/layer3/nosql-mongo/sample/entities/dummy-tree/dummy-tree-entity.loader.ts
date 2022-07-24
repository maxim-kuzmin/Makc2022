/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from '../../../../../layer1/common/common-functions';
import { EntityLoader } from '../../../../../layer1/entity/entity-loader';
import { DummyTreeEntityObject } from './dummy-tree-entity.object';

/** Загрузчик сущности "DummyTree". */
export class DummyTreeEntityLoader extends EntityLoader<DummyTreeEntityObject> {
  /** @inheritdoc */
  constructor(entityObject?: DummyTreeEntityObject) {
    super(entityObject ?? ({} as DummyTreeEntityObject));
  }

  /** @inheritdoc */
  override load(
    entityObject: DummyTreeEntityObject,
    loadableProperties?: Set<string>
  ): Set<string> {
    const result = super.load(entityObject, loadableProperties);

    if (result.has(nameof<DummyTreeEntityObject>('id'))) {
      this.entityObject.id = entityObject.id;
    }

    if (result.has(nameof<DummyTreeEntityObject>('name'))) {
      this.entityObject.name = entityObject.name;
    }

    if (result.has(nameof<DummyTreeEntityObject>('parentId'))) {
      this.entityObject.parentId = entityObject.parentId;
    }

    if (result.has(nameof<DummyTreeEntityObject>('treeChildCount'))) {
      this.entityObject.treeChildCount = entityObject.treeChildCount;
    }

    if (result.has(nameof<DummyTreeEntityObject>('treeDescendantCount'))) {
      this.entityObject.treeDescendantCount = entityObject.treeDescendantCount;
    }

    if (result.has(nameof<DummyTreeEntityObject>('treeLevel'))) {
      this.entityObject.treeLevel = entityObject.treeLevel;
    }

    if (result.has(nameof<DummyTreeEntityObject>('treePath'))) {
      this.entityObject.treePath = entityObject.treePath;
    }

    if (result.has(nameof<DummyTreeEntityObject>('treePosition'))) {
      this.entityObject.treePosition = entityObject.treePosition;
    }

    if (result.has(nameof<DummyTreeEntityObject>('treeSort'))) {
      this.entityObject.treeSort = entityObject.treeSort;
    }

    return result;
  }

  /** @inheritdoc */
  protected override createAllPropertiesToLoad(): Set<string> {
    return new Set<string>([
      nameof<DummyTreeEntityObject>('id'),
      nameof<DummyTreeEntityObject>('name'),
      nameof<DummyTreeEntityObject>('parentId'),
      nameof<DummyTreeEntityObject>('treeChildCount'),
      nameof<DummyTreeEntityObject>('treeDescendantCount'),
      nameof<DummyTreeEntityObject>('treeLevel'),
      nameof<DummyTreeEntityObject>('treePath'),
      nameof<DummyTreeEntityObject>('treePosition'),
      nameof<DummyTreeEntityObject>('treeSort'),
    ]);
  }
}
