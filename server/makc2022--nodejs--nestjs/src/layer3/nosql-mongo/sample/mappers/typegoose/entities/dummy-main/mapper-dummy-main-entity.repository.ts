/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { ReturnModelType } from '@typegoose/typegoose';
import { InjectModel } from 'nestjs-typegoose';
import { nameof } from '../../../../../../../layer1/common/common-functions';
import { DummyMainEntityObject } from '../../../../entities/dummy-main/dummy-main-entity.object';
import { MapperDummyMainEntityExtension } from './mapper-dummy-main-entity.extension';
import { MapperDummyMainEntityObject } from './mapper-dummy-main-entity.object';

/** Репозиторий сущности "DummyMain" сопоставителя. */
@Injectable()
export class MapperDummyMainEntityRepository {
  constructor(
    @InjectModel(MapperDummyMainEntityObject)
    private readonly mapperDummyMainEntityModel: ReturnModelType<typeof MapperDummyMainEntityObject>
  ) {}

  async findOneById(id: string): Promise<MapperDummyMainEntityObject> {
    return await this.mapperDummyMainEntityModel
      .findById(id)
      .populate(this.getPathsToPopulate())
      .exec();
  }

  async findOneByName(name: string): Promise<MapperDummyMainEntityObject> {
    return await this.mapperDummyMainEntityModel
      .findOne({ name })
      .populate(this.getPathsToPopulate())
      .exec();
  }

  async save(entityObject: DummyMainEntityObject): Promise<MapperDummyMainEntityObject> {
    let result: MapperDummyMainEntityObject;

    const entityObjectExt = MapperDummyMainEntityExtension.extEntityObject(entityObject);

    result = entityObjectExt.fromEntityToMapperObject();

    const model = new this.mapperDummyMainEntityModel(result);

    result = await model.save();

    result = await this.findOneById(result.id);

    return result;
  }

  private getPathsToPopulate() {
    return [nameof<MapperDummyMainEntityObject>('refToDummyOneToManyEntity')];
  }
}
