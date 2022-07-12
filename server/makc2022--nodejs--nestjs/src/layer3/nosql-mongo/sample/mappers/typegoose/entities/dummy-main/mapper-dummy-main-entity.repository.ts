/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { ReturnModelType } from '@typegoose/typegoose';
import { InjectModel } from 'nestjs-typegoose';
import { DummyMainEntityObject } from 'src/layer3/nosql-mongo/sample/entities/dummy-main/dummy-main-entity.object';
import { MapperDummyMainEntityObject } from './mapper-dummy-main-entity.object';

@Injectable()
export class MapperDummyMainEntityRepository {
  constructor(
    @InjectModel(MapperDummyMainEntityObject)
    private readonly mapperDummyMainEntityModel: ReturnModelType<typeof MapperDummyMainEntityObject>
  ) {}

  async create(inputObject: DummyMainEntityObject): Promise<DummyMainEntityObject> {
    let mapperObject = this.convertToMapperObject(inputObject);

    console.log('MAKC: mapperObject: input', mapperObject);

    const model = new this.mapperDummyMainEntityModel(mapperObject);

    mapperObject = await model.save();

    console.log('MAKC: mapperObject: output', mapperObject);

    return this.convertToObject(mapperObject);
  }

  async getByName(name: string): Promise<DummyMainEntityObject | null> {
    const mapperObject = await this.mapperDummyMainEntityModel.findOne({ name }).exec();

    return mapperObject && this.convertToObject(mapperObject);
  }

  private convertToMapperObject(inputObject: DummyMainEntityObject): MapperDummyMainEntityObject {
    const result = new MapperDummyMainEntityObject();

    result.id = inputObject.id;
    result.idOfDummyOneToManyEntity = inputObject.idOfDummyOneToManyEntity;
    result.name = inputObject.name;
    result.propBoolean = inputObject.propBoolean;
    result.propBooleanNullable = inputObject.propBooleanNullable;
    result.propDate = inputObject.propDate;
    result.propDateNullable = inputObject.propDateNullable;
    result.propDecimal = inputObject.propDecimal;
    result.propDecimalNullable = inputObject.propDecimalNullable;
    result.propInt32 = inputObject.propInt32;
    result.propInt32Nullable = inputObject.propInt32Nullable;
    result.propInt64 = inputObject.propInt64;
    result.propInt64Nullable = inputObject.propInt64Nullable;
    result.propString = inputObject.propString;
    result.propStringNullable = inputObject.propStringNullable;

    return result;
  }

  private convertToObject(mapperObject: MapperDummyMainEntityObject): DummyMainEntityObject {
    const {
      id,
      idOfDummyOneToManyEntity,
      name,
      propBoolean,
      propBooleanNullable,
      propDate,
      propDateNullable,
      propDecimal,
      propDecimalNullable,
      propInt32,
      propInt32Nullable,
      propInt64,
      propInt64Nullable,
      propString,
      propStringNullable,
    } = mapperObject;

    return {
      id,
      idOfDummyOneToManyEntity,
      name,
      propBoolean,
      propBooleanNullable,
      propDate,
      propDateNullable,
      propDecimal,
      propDecimalNullable,
      propInt32,
      propInt32Nullable,
      propInt64,
      propInt64Nullable,
      propString,
      propStringNullable,
    } as DummyMainEntityObject;
  }
}
