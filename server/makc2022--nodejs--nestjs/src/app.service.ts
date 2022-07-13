/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { DummyMainEntityObject } from './layer3/nosql-mongo/sample/entities/dummy-main/dummy-main-entity.object';
import { DummyOneToManyEntityObject } from './layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.object';
import { DomainService as DummyMainDomainService } from './layer4/domains/dummy-main/domain.service';
import { DomainItemGetQueryInput as DummyMainDomainItemGetQueryInput } from './layer4/domains/dummy-main/queries/item/get/domain-item-get-query-input';
import { DomainItemGetQueryOutput as DummyMainDomainItemGetQueryOutput } from './layer4/domains/dummy-main/queries/item/get/domain-item-get-query-output';
import { DomainService as DummyOneToManyDomainService } from './layer4/domains/dummy-one-to-many/domain.service';
import { DomainItemGetQueryInput as DummyOneToManyDomainItemGetQueryInput } from './layer4/domains/dummy-one-to-many/queries/item/get/domain-item-get-query-input';
import { DomainItemGetQueryOutput as DummyOneToManyDomainItemGetQueryOutput } from './layer4/domains/dummy-one-to-many/queries/item/get/domain-item-get-query-output';

@Injectable()
export class AppService {
  constructor(
    private readonly serviceOfDummyMainDomain: DummyMainDomainService,
    private readonly serviceOfDummyOneToManyDomain: DummyOneToManyDomainService
  ) {}

  async createDummyMainEntity(
    entityObject: DummyMainEntityObject
  ): Promise<DummyMainDomainItemGetQueryOutput> {
    return await this.serviceOfDummyMainDomain.save(entityObject);
  }

  async getDummyMainEntityByName(name: string): Promise<DummyMainDomainItemGetQueryOutput> {
    const input = new DummyMainDomainItemGetQueryInput();

    input.entityName = name;

    return await this.serviceOfDummyMainDomain.getItem(input);
  }

  async createDummyOneToManyEntity(
    entityObject: DummyOneToManyEntityObject
  ): Promise<DummyOneToManyDomainItemGetQueryOutput> {
    return await this.serviceOfDummyOneToManyDomain.save(entityObject);
  }

  async getDummyOneToManyEntityByName(
    name: string
  ): Promise<DummyOneToManyDomainItemGetQueryOutput> {
    const input = new DummyOneToManyDomainItemGetQueryInput();

    input.entityName = name;

    return await this.serviceOfDummyOneToManyDomain.getItem(input);
  }
}
