/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { ReturnModelType } from '@typegoose/typegoose';
import { InjectModel } from 'nestjs-typegoose';
import { DummyOneToManyEntityObject } from 'src/layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.object';
import { MapperDummyOneToManyEntityObject } from './mapper-dummy-one-to-many-entity.object';

@Injectable()
export class MapperDummyOneToManyEntityRepository {
  constructor(
    @InjectModel(MapperDummyOneToManyEntityObject)
    private readonly mapperDummyOneToManyEntityModel: ReturnModelType<
      typeof MapperDummyOneToManyEntityObject
    >
  ) {}

  async create(inputObject: DummyOneToManyEntityObject): Promise<DummyOneToManyEntityObject> {
    const model = new this.mapperDummyOneToManyEntityModel(inputObject);

    const mapperObject = await model.save();

    return this.convertToObject(mapperObject);
  }

  async getByName(name: string): Promise<DummyOneToManyEntityObject | null> {
    const mapperObject = await this.mapperDummyOneToManyEntityModel.findOne({ name }).exec();

    return mapperObject && this.convertToObject(mapperObject);
  }

  private convertToObject(
    mapperObject: MapperDummyOneToManyEntityObject
  ): DummyOneToManyEntityObject {
    const { id, name } = mapperObject;

    return {
      id,
      name,
    } as DummyOneToManyEntityObject;
  }
}
