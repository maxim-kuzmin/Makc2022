/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { DummyMainEntityObject } from './layer3/nosql-mongo/sample/entities/dummy-main/dummy-main-entity.object';
import { DummyOneToManyEntityObject } from './layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.object';
import { MapperDummyMainEntityRepository } from './layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-main/mapper-dummy-main-entity.repository';
import { MapperDummyOneToManyEntityRepository } from './layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.repository';

@Injectable()
export class AppService {
  constructor(
    private readonly repositioryOfDummyMainEntity: MapperDummyMainEntityRepository,
    private readonly repositioryOfDummyOneToManyEntity: MapperDummyOneToManyEntityRepository
  ) {}

  async createDummyMainEntity(inputObject: DummyMainEntityObject): Promise<DummyMainEntityObject> {
    return await this.repositioryOfDummyMainEntity.create(inputObject);
  }

  async createDummyOneToManyEntity(
    inputObject: DummyOneToManyEntityObject
  ): Promise<DummyOneToManyEntityObject> {
    return await this.repositioryOfDummyOneToManyEntity.create(inputObject);
  }

  async getDummyOneToManyEntityByName(name: string): Promise<DummyOneToManyEntityObject | null> {
    return await this.repositioryOfDummyOneToManyEntity.getByName(name);
  }
}
