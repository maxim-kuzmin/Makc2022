/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { prop } from '@typegoose/typegoose';
import { Base, TimeStamps } from '@typegoose/typegoose/lib/defaultClasses';
import { IMapperDummyMainEntityObject } from './mapper-dummy-main-entity-object.interface';

export interface MapperDummyMainEntityObject extends Base<string> {}

export interface MapperDummyMainEntityObject extends TimeStamps {}

/** Объект сущности "DummyMain" сопоставителя. */
export class MapperDummyMainEntityObject implements IMapperDummyMainEntityObject {
  /**@inheritdoc */
  @prop({ unique: true, required: true })
  name: string;

  /**@inheritdoc */
  @prop({ required: true })
  idOfDummyOneToManyEntity: number;

  /**@inheritdoc */
  @prop({ required: true })
  propBoolean: boolean;

  /**@inheritdoc */
  @prop()
  propBooleanNullable?: boolean;

  /**@inheritdoc */
  @prop({ required: true })
  propDate: Date;

  /**@inheritdoc */
  @prop()
  propDateNullable?: Date;

  /**@inheritdoc */
  @prop({ required: true })
  propDateTimeOffset: Date;

  /**@inheritdoc */
  @prop()
  propDateTimeOffsetNullable?: Date;

  /**@inheritdoc */
  @prop({ required: true })
  propDecimal: number;

  /**@inheritdoc */
  @prop()
  propDecimalNullable?: number;

  /**@inheritdoc */
  @prop({ required: true })
  propInt32: number;

  /**@inheritdoc */
  @prop()
  propInt32Nullable?: number;

  /**@inheritdoc */
  @prop({ required: true })
  propInt64: number;

  /**@inheritdoc */
  @prop()
  propInt64Nullable?: number;

  /**@inheritdoc */
  @prop({ required: true })
  propString: string;

  /**@inheritdoc */
  @prop()
  propStringNullable?: string;
}
