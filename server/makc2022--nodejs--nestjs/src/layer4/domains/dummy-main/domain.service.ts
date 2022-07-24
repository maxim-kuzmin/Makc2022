/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { DummyMainEntityObject } from '../../../layer3/nosql-mongo/sample/entities/dummy-main/dummy-main-entity.object';
import { MapperDummyMainEntityExtension } from '../../../layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-main/mapper-dummy-main-entity.extension';
import { MapperDummyMainEntityObject } from '../../../layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-main/mapper-dummy-main-entity.object';
import { MapperDummyMainEntityRepository } from '../../../layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-main/mapper-dummy-main-entity.repository';
import { MapperDummyOneToManyEntityExtension } from '../../../layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.extension';
import { MapperDummyOneToManyEntityRepository } from '../../../layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-one-to-many/mapper-dummy-one-to-many-entity.repository';
import { DomainItemGetQueryInput } from './queries/item/get/domain-item-get-query-input';
import { DomainItemGetQueryOutput } from './queries/item/get/domain-item-get-query-output';
import { DomainListGetQueryInput } from './queries/list/get/domain-list-get-query-input';
import { DomainListGetQueryOutput } from './queries/list/get/domain-list-get-query-output';

/** Сервис домена. */
@Injectable()
export class DomainService {
  constructor(
    private readonly repositioryOfDummyMainEntity: MapperDummyMainEntityRepository,
    private readonly repositioryOfDummyOneToManyEntity: MapperDummyOneToManyEntityRepository
  ) {}

  /** Получить элемент.
   * @param input Входные данные.
   * @returns Обещание выполнения запроса с выходными данными.
   */
  async getItem(input: DomainItemGetQueryInput): Promise<DomainItemGetQueryOutput> {
    const result = new DomainItemGetQueryOutput();

    let mapperObject: MapperDummyMainEntityObject;

    if (input.entityId) {
      mapperObject = await this.repositioryOfDummyMainEntity.findOneById(input.entityId);
    } else if (input.entityName) {
      mapperObject = await this.repositioryOfDummyMainEntity.findOneByName(input.entityName);
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
  async save(entityObject: DummyMainEntityObject): Promise<DomainItemGetQueryOutput> {
    const result = new DomainItemGetQueryOutput();

    const mapperObject = await this.repositioryOfDummyMainEntity.save(entityObject);

    if (mapperObject) {
      this.initItemGetQueryOutput(result, mapperObject);
    }

    return result;
  }

  private initItemGetQueryOutput(
    output: DomainItemGetQueryOutput,
    mapperObject: MapperDummyMainEntityObject
  ) {
    const mapperObjectExtOfDummyMainEntity =
      MapperDummyMainEntityExtension.extMapperObject(mapperObject);

    output.objectOfDummyMainEntity = mapperObjectExtOfDummyMainEntity.fromMapperToEntityObject();

    const mapperObjectExtOfDummyOneToManyEntity =
      MapperDummyOneToManyEntityExtension.extMapperObject(
        mapperObject.objectOfDummyOneToManyEntity
      );

    output.objectOfDummyOneToManyEntity =
      mapperObjectExtOfDummyOneToManyEntity.fromMapperToEntityObject();
  }
}
