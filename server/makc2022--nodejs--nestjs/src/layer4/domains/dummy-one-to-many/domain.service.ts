/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { DummyOneToManyEntityObject } from 'src/layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.object';
import { MapperDummyOneToManyEntityExtension } from 'src/layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.extension';
import { MapperDummyOneToManyEntityObject } from 'src/layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.object';
import { MapperDummyOneToManyEntityRepository } from 'src/layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.repository';
import { DomainItemGetQueryInput } from './queries/item/get/domain-item-get-query-input';
import { DomainItemGetQueryOutput } from './queries/item/get/domain-item-get-query-output';
import { DomainListGetQueryInput } from './queries/list/get/domain-list-get-query-input';
import { DomainListGetQueryOutput } from './queries/list/get/domain-list-get-query-output';

@Injectable()
export class DomainService {
  constructor(
    private readonly repositioryOfDummyOneToManyEntity: MapperDummyOneToManyEntityRepository
  ) {}

  /** Получить элемент.
   * @param input Входные данные.
   * @returns Обещание выполнения запроса с выходными данными.
   */
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

  /** Получить список.
   * @param input Входные данные.
   * @returns Обещание выполнения запроса с выходными данными.
   */
  async getList(input: DomainListGetQueryInput): Promise<DomainListGetQueryOutput> {
    const result = new DomainListGetQueryOutput();

    return result;
  }

  /** Сохранить.
   * @param entityObject Объект сущности.
   * @returns Обещание выполнения запроса с выходными данными.
   */
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
