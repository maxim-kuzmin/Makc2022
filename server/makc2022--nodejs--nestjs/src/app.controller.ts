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
    const objectOfDummyOneToManyEntity = await this.appService.getDummyOneToManyEntityByName(
      'Name-2'
    );

    const inputObject = {
      idOfDummyOneToManyEntity: objectOfDummyOneToManyEntity.id,
      name: 'Name-5',
      propBoolean: true,
      propDate: new Date(),
      propDecimal: 1.123,
      propInt32: 1,
      propInt64: 2,
      propString: 'mncxanajlk',
    } as DummyMainEntityObject;

    const outputObject = await this.appService.createDummyMainEntity(inputObject);

    return JSON.stringify(outputObject);
  }

  @Get('dummy-one-to-many/create')
  async createDummyOneToMany(): Promise<string> {
    const inputObject = { name: 'Name-7' } as DummyOneToManyEntityObject;

    const outputObject = await this.appService.createDummyOneToManyEntity(inputObject);

    return JSON.stringify(outputObject);
  }

  @Get('dummy-one-to-many/get-by-name')
  async getDummyOneToManyByName(): Promise<string> {
    const outputObject = await this.appService.getDummyOneToManyEntityByName('Name-2');

    return JSON.stringify(outputObject);
  }
}
