/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Controller, Get } from '@nestjs/common';
import { I18n, I18nContext } from 'nestjs-i18n';
import { AppService } from './app.service';
import { QueryFactory } from './layer1/query/query-factory';
import { DummyMainEntityObject } from './layer3/nosql-mongo/sample/entities/dummy-main/dummy-main-entity.object';
import { DummyOneToManyEntityObject } from './layer3/nosql-mongo/sample/entities/dummy-one-to-many/dummy-one-to-many-entity.object';

@Controller()
export class AppController {
  constructor(
    private readonly appService: AppService,
    private readonly queryFactory: QueryFactory
  ) {}

  @Get('query-resource')
  async getQueryResource(@I18n() i18n: I18nContext): Promise<string> {
    const queryResource = this.queryFactory.createResource(i18n);

    return queryResource.getErrorMessageForDefault();
  }

  @Get('dummy-main/create')
  async createDummyMain(): Promise<string> {
    const outputOfDummyOneToMany = await this.appService.getDummyOneToManyEntityByName('Name-1');

    const entityObject = {
      idOfDummyOneToManyEntity: outputOfDummyOneToMany.objectOfDummyOneToManyEntity.id,
      name: 'Name-1',
      propBoolean: true,
      propDate: new Date(),
      propDecimal: 1.123,
      propInt32: 1,
      propInt64: 2,
      propString: 'mncxanajlk',
    } as DummyMainEntityObject;

    const output = await this.appService.createDummyMainEntity(entityObject);

    return JSON.stringify(output);
  }

  @Get('dummy-main/get-by-name')
  async getDummyMainByName(): Promise<string> {
    const output = await this.appService.getDummyMainEntityByName('Name-1');

    return JSON.stringify(output);
  }

  @Get('dummy-one-to-many/create')
  async createDummyOneToMany(): Promise<string> {
    const entityObject = { name: 'Name-1' } as DummyOneToManyEntityObject;

    const output = await this.appService.createDummyOneToManyEntity(entityObject);

    return JSON.stringify(output);
  }

  @Get('dummy-one-to-many/get-by-name')
  async getDummyOneToManyByName(): Promise<string> {
    const output = await this.appService.getDummyOneToManyEntityByName('Name-1');

    return JSON.stringify(output);
  }
}
