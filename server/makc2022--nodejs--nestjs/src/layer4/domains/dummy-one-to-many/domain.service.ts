/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { DummyOneToManyEntityObject } from 'src/layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.object';
import { MapperDummyOneToManyEntityExtension } from 'src/layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.extension';
import { MapperDummyOneToManyEntityObject } from 'src/layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.object';
import { MapperDummyOneToManyEntityRepository } from 'src/layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.repository';
import { DomainItemGetQueryInput } from './queries/item/get/domain-item-get-query-input';
import { DomainItemGetQueryOutput } from './queries/item/get/domain-item-get-query-output';

@Injectable()
export class DomainService {
  constructor(
    private readonly repositioryOfDummyOneToManyEntity: MapperDummyOneToManyEntityRepository
  ) {}

  async getItem(input: DomainItemGetQueryInput): Promise<DomainItemGetQueryOutput> {
    const result = new DomainItemGetQueryOutput();

    let mapperObject: MapperDummyOneToManyEntityObject;

    if (input.entityId) {
      mapperObject = await this.repositioryOfDummyOneToManyEntity.findOneById(input.entityId);
    } else if (input.entityName) {
      mapperObject = await this.repositioryOfDummyOneToManyEntity.findOneByName(input.entityName);
    }

    if (mapperObject) {
      this.initItemGetQueryOutput(result, mapperObject);
    }

    return result;
  }

  async getList() {
    return null;
  }

  async save(entityObject: DummyOneToManyEntityObject): Promise<DomainItemGetQueryOutput> {
    const result = new DomainItemGetQueryOutput();

    const mapperObject = await this.repositioryOfDummyOneToManyEntity.save(entityObject);

    if (mapperObject) {
      this.initItemGetQueryOutput(result, mapperObject);
    }

    return result;
  }

  private initItemGetQueryOutput(
    output: DomainItemGetQueryOutput,
    mapperObject: MapperDummyOneToManyEntityObject
  ) {
    const mapperObjectExtOfDummyOneToManyEntity =
      MapperDummyOneToManyEntityExtension.extMapperObject(mapperObject);

    output.objectOfDummyOneToManyEntity =
      mapperObjectExtOfDummyOneToManyEntity.fromMapperToEntityObject();
  }
}
