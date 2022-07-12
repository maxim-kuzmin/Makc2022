/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { ReturnModelType } from '@typegoose/typegoose';
import { InjectModel } from 'nestjs-typegoose';
import { DummyOneToManyEntityLoader } from 'src/layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.loader';
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

  async create(entityObject: DummyOneToManyEntityObject): Promise<DummyOneToManyEntityObject> {
    let mapperObject = this.convertFromEntityToMapperObject(entityObject);

    const model = new this.mapperDummyOneToManyEntityModel(mapperObject);

    mapperObject = await model.save();

    return this.convertFromMapperToEntityObject(mapperObject);
  }

  async getByName(name: string): Promise<DummyOneToManyEntityObject | null> {
    const mapperObject = await this.mapperDummyOneToManyEntityModel.findOne({ name }).exec();

    return mapperObject && this.convertFromMapperToEntityObject(mapperObject);
  }

  private convertFromEntityToMapperObject(
    entityObject: DummyOneToManyEntityObject
  ): MapperDummyOneToManyEntityObject {
    const result = new MapperDummyOneToManyEntityObject();

    const loader = new DummyOneToManyEntityLoader(result);

    loader.load(entityObject);

    return result;
  }

  private convertFromMapperToEntityObject(
    mapperObject: MapperDummyOneToManyEntityObject
  ): DummyOneToManyEntityObject {
    const loader = new DummyOneToManyEntityLoader();

    loader.load(mapperObject);

    return loader.entityObject;
  }
}
