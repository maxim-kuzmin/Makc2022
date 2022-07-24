/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable, LoggerService } from '@nestjs/common';
import { I18nContext } from 'nestjs-i18n';
import { QueryFactory } from '../../../layer1/query/query.factory';
import { DomainResource } from './domain-resource';
import { DomainResourceImpl } from './domain-resource.impl';
import { DomainItemGetQueryHandler } from './queries/item/get/domain-item-get-query-handler';
import { DomainItemGetQueryHandlerImpl } from './queries/item/get/domain-item-get-query-handler.impl';
import { DomainListGetQueryHandler } from './queries/list/get/domain-list-get-query-handler';
import { DomainListGetQueryHandlerImpl } from './queries/list/get/domain-list-get-query-handler.impl';

/** Фабрика домена. */
@Injectable()
export class DomainFactory {
  constructor(private readonly queryFactory: QueryFactory) {}

  /** Создать обработчик запроса на получение элемента.
   * @param i18n Контекст интернационализации.
   * @param logger Регистратор.
   * @returns Обработчик запроса.
   */
  createItemGetQueryHandler(i18n: I18nContext, logger: LoggerService): DomainItemGetQueryHandler {
    return new DomainItemGetQueryHandlerImpl(
      this.createResource(i18n),
      this.queryFactory.createResource(i18n),
      logger
    );
  }

  /** Создать обработчик запроса на получение списка.
   * @param i18n Контекст интернационализации.
   * @param logger Регистратор.
   * @returns Обработчик запроса.
   */
  createListGetQueryHandler(i18n: I18nContext, logger: LoggerService): DomainListGetQueryHandler {
    return new DomainListGetQueryHandlerImpl(
      this.createResource(i18n),
      this.queryFactory.createResource(i18n),
      logger
    );
  }

  /** Создать ресурс.
   * @param i18n Контекст интернационализации.
   * @returns Ресурс.
   */
  createResource(i18n: I18nContext): DomainResource {
    return new DomainResourceImpl(i18n);
  }
}
