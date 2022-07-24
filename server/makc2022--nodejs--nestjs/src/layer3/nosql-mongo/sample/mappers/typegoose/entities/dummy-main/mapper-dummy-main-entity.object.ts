/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { modelOptions, prop, Ref } from '@typegoose/typegoose';
import { Base } from '@typegoose/typegoose/lib/defaultClasses';
import { DummyMainEntityObject } from '../../../../entities/dummy-main/dummy-main-entity.object';
import { MapperDummyOneToManyEntityObject } from '../dummy-one-to-many/mapper-dummy-one-to-many-entity.object';

export interface MapperDummyMainEntityObject extends Base<string> {}

/** Объект сущности "DummyMain" сопоставителя. */
@modelOptions({ schemaOptions: { collection: 'dummy-main' } })
export class MapperDummyMainEntityObject implements DummyMainEntityObject {
  /** @inheritdoc */
  @prop({ unique: true, required: true })
  name!: string;

  /** @inheritdoc */
  @prop({ required: true })
  propBoolean!: boolean;

  /** @inheritdoc */
  @prop()
  propBooleanNullable?: boolean;

  /** @inheritdoc */
  @prop({ required: true })
  propDate!: Date;

  /** @inheritdoc */
  @prop()
  propDateNullable?: Date;

  /** @inheritdoc */
  @prop({ required: true })
  propDecimal: number;

  /** @inheritdoc */
  @prop()
  propDecimalNullable?: number;

  /** @inheritdoc */
  @prop({ required: true })
  propInt32!: number;

  /** @inheritdoc */
  @prop()
  propInt32Nullable?: number;

  /** @inheritdoc */
  @prop({ required: true })
  propInt64!: number;

  /** @inheritdoc */
  @prop()
  propInt64Nullable?: number;

  /** @inheritdoc */
  @prop({ required: true })
  propString!: string;

  /** @inheritdoc */
  @prop()
  propStringNullable?: string;

  /** Ссылка на объект сущности "DummyOneToMany". */
  @prop({ required: true, ref: () => MapperDummyOneToManyEntityObject, type: () => String })
  refToDummyOneToManyEntity!: Ref<MapperDummyOneToManyEntityObject, string>;

  /** @inheritdoc */
  get idOfDummyOneToManyEntity(): string {
    return this.objectOfDummyOneToManyEntity.id;
  }
  set idOfDummyOneToManyEntity(value: string) {
    this.refToDummyOneToManyEntity = value;
  }

  /** Объект сущности "DummyOneToMany". */
  get objectOfDummyOneToManyEntity() {
    return this.refToDummyOneToManyEntity as MapperDummyOneToManyEntityObject;
  }
  set objectOfDummyOneToManyEntity(value: MapperDummyOneToManyEntityObject) {
    this.refToDummyOneToManyEntity = value;
  }
}
