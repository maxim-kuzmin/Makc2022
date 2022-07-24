/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { ReturnModelType } from '@typegoose/typegoose';
import { InjectModel } from 'nestjs-typegoose';
import { DummyOneToManyEntityObject } from '../../../../entities/dummy-one-to-many/dummy-one-to-many-entity.object';
import { MapperDummyOneToManyEntityExtension } from './mapper-dummy-one-to-many-entity.extension';
import { MapperDummyOneToManyEntityObject } from './mapper-dummy-one-to-many-entity.object';

/** Репозиторий сущности "DummyOneToMany" сопоставителя. */
@Injectable()
export class MapperDummyOneToManyEntityRepository {
  constructor(
    @InjectModel(MapperDummyOneToManyEntityObject)
    private readonly mapperDummyOneToManyEntityModel: ReturnModelType<
      typeof MapperDummyOneToManyEntityObject
    >
  ) {}

  async findOneById(id: string): Promise<MapperDummyOneToManyEntityObject> {
    return await this.mapperDummyOneToManyEntityModel.findById(id).exec();
  }

  async findOneByName(name: string): Promise<MapperDummyOneToManyEntityObject> {
    return await this.mapperDummyOneToManyEntityModel.findOne({ name }).exec();
  }

  async save(entityObject: DummyOneToManyEntityObject): Promise<MapperDummyOneToManyEntityObject> {
    let result: MapperDummyOneToManyEntityObject;

    const entityObjectExt = MapperDummyOneToManyEntityExtension.extEntityObject(entityObject);

    result = entityObjectExt.fromEntityToMapperObject();

    const model = new this.mapperDummyOneToManyEntityModel(result);

    result = await model.save();

    result = await this.findOneById(result.id);

    return result;
  }
}
