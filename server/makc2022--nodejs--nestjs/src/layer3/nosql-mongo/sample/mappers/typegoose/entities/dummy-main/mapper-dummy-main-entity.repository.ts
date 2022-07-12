/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { ReturnModelType } from '@typegoose/typegoose';
import { InjectModel } from 'nestjs-typegoose';
import { DummyMainEntityLoader } from 'src/layer3/nosql-mongo/sample/entities/dummy-main/dummy-main-entity.loader';
import { DummyMainEntityObject } from 'src/layer3/nosql-mongo/sample/entities/dummy-main/dummy-main-entity.object';
import { MapperDummyMainEntityObject } from './mapper-dummy-main-entity.object';

@Injectable()
export class MapperDummyMainEntityRepository {
  constructor(
    @InjectModel(MapperDummyMainEntityObject)
    private readonly mapperDummyMainEntityModel: ReturnModelType<typeof MapperDummyMainEntityObject>
  ) {}

  async create(entityObject: DummyMainEntityObject): Promise<DummyMainEntityObject> {
    let mapperObject = this.convertFromEntityToMapperObject(entityObject);

    const model = new this.mapperDummyMainEntityModel(mapperObject);

    mapperObject = await model.save();

    return this.convertFromMapperToEntityObject(mapperObject);
  }

  async getByName(name: string): Promise<DummyMainEntityObject | null> {
    const mapperObject = await this.mapperDummyMainEntityModel.findOne({ name }).exec();

    return mapperObject && this.convertFromMapperToEntityObject(mapperObject);
  }

  private convertFromEntityToMapperObject(
    entityObject: DummyMainEntityObject
  ): MapperDummyMainEntityObject {
    const result = new MapperDummyMainEntityObject();

    const loader = new DummyMainEntityLoader(result);

    loader.load(entityObject);

    return result;
  }

  private convertFromMapperToEntityObject(
    mapperObject: MapperDummyMainEntityObject
  ): DummyMainEntityObject {
    const loader = new DummyMainEntityLoader();

    loader.load(mapperObject);

    return loader.entityObject;
  }
}
