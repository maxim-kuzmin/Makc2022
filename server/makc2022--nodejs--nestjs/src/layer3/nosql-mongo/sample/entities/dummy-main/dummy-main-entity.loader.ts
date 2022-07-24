/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from '../../../../../layer1/common/common-functions';
import { EntityLoader } from '../../../../../layer1/entity/entity-loader';
import { DummyMainEntityObject } from './dummy-main-entity.object';

/** Загрузчик сущности "Dummy". */
export class DummyMainEntityLoader extends EntityLoader<DummyMainEntityObject> {
  /** @inheritdoc */
  constructor(entityObject?: DummyMainEntityObject) {
    super(entityObject ?? ({} as DummyMainEntityObject));
  }

  /** @inheritdoc */
  override load(
    entityObject: DummyMainEntityObject,
    loadableProperties?: Set<string>
  ): Set<string> {
    const result = super.load(entityObject, loadableProperties);

    if (result.has(nameof<DummyMainEntityObject>('id'))) {
      this.entityObject.id = entityObject.id;
    }

    if (result.has(nameof<DummyMainEntityObject>('idOfDummyOneToManyEntity'))) {
      this.entityObject.idOfDummyOneToManyEntity = entityObject.idOfDummyOneToManyEntity;
    }

    if (result.has(nameof<DummyMainEntityObject>('name'))) {
      this.entityObject.name = entityObject.name;
    }

    if (result.has(nameof<DummyMainEntityObject>('propBoolean'))) {
      this.entityObject.propBoolean = entityObject.propBoolean;
    }

    if (result.has(nameof<DummyMainEntityObject>('propBooleanNullable'))) {
      this.entityObject.propBooleanNullable = entityObject.propBooleanNullable;
    }

    if (result.has(nameof<DummyMainEntityObject>('propDate'))) {
      this.entityObject.propDate = entityObject.propDate;
    }

    if (result.has(nameof<DummyMainEntityObject>('propDateNullable'))) {
      this.entityObject.propDateNullable = entityObject.propDateNullable;
    }

    if (result.has(nameof<DummyMainEntityObject>('propDecimal'))) {
      this.entityObject.propDecimal = entityObject.propDecimal;
    }

    if (result.has(nameof<DummyMainEntityObject>('propDecimalNullable'))) {
      this.entityObject.propDecimalNullable = entityObject.propDecimalNullable;
    }

    if (result.has(nameof<DummyMainEntityObject>('propInt32'))) {
      this.entityObject.propInt32 = entityObject.propInt32;
    }

    if (result.has(nameof<DummyMainEntityObject>('propInt32Nullable'))) {
      this.entityObject.propInt32Nullable = entityObject.propInt32Nullable;
    }

    if (result.has(nameof<DummyMainEntityObject>('propInt64'))) {
      this.entityObject.propInt64 = entityObject.propInt64;
    }

    if (result.has(nameof<DummyMainEntityObject>('propInt64Nullable'))) {
      this.entityObject.propInt64Nullable = entityObject.propInt64Nullable;
    }

    if (result.has(nameof<DummyMainEntityObject>('propString'))) {
      this.entityObject.propString = entityObject.propString;
    }

    if (result.has(nameof<DummyMainEntityObject>('propStringNullable'))) {
      this.entityObject.propStringNullable = entityObject.propStringNullable;
    }

    return result;
  }

  /** @inheritdoc */
  protected override createAllPropertiesToLoad(): Set<string> {
    return new Set<string>([
      nameof<DummyMainEntityObject>('id'),
      nameof<DummyMainEntityObject>('idOfDummyOneToManyEntity'),
      nameof<DummyMainEntityObject>('name'),
      nameof<DummyMainEntityObject>('propBoolean'),
      nameof<DummyMainEntityObject>('propBooleanNullable'),
      nameof<DummyMainEntityObject>('propDate'),
      nameof<DummyMainEntityObject>('propDateNullable'),
      nameof<DummyMainEntityObject>('propDecimal'),
      nameof<DummyMainEntityObject>('propDecimalNullable'),
      nameof<DummyMainEntityObject>('propInt32'),
      nameof<DummyMainEntityObject>('propInt32Nullable'),
      nameof<DummyMainEntityObject>('propInt64'),
      nameof<DummyMainEntityObject>('propInt64Nullable'),
      nameof<DummyMainEntityObject>('propString'),
      nameof<DummyMainEntityObject>('propStringNullable'),
    ]);
  }
}
