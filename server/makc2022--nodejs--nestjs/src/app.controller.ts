/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Controller, Get } from '@nestjs/common';
import { I18n, I18nContext } from 'nestjs-i18n';
import { AppService } from './app.service';
import { QueryFactory } from './layer1/query/query-factory';

@Controller()
export class AppController {
  constructor(
    private readonly appService: AppService,
    private readonly queryFactory: QueryFactory
  ) {}

  @Get()
  getHello(@I18n() i18n: I18nContext): string {
    const queryResource = this.queryFactory.createResource(i18n);
    return queryResource.getErrorMessageForDefault(); //this.appService.getHello();
  }
}
