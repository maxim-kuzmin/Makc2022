/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { modelOptions, prop } from '@typegoose/typegoose';
import { Base } from '@typegoose/typegoose/lib/defaultClasses';
import { DummyOneToManyEntityObject } from '../../../../entities/dummy-one-to-many/dummy-one-to-many-entity.object';

export interface MapperDummyOneToManyEntityObject extends Base<string> {}

/** Объект сущности "DummyManyToMany" сопоставителя. */
@modelOptions({ schemaOptions: { collection: 'dummy-one-to-many' } })
export class MapperDummyOneToManyEntityObject implements DummyOneToManyEntityObject {
  /** @inheritdoc */
  @prop({ unique: true, required: true })
  name!: string;
}
