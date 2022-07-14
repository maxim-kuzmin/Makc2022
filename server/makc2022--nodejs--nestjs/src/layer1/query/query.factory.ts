/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { I18nContext } from 'nestjs-i18n';
import { QueryResource } from './query-resource';
import { QueryResourceImpl } from './query-resource.impl';

/** Фабрика запроса. */
@Injectable()
export class QueryFactory {
  /** Создать ресурс.
   * @param i18n Контекст интернационализации.
   * @returns Ресурс.
   */
  createResource(i18n: I18nContext): QueryResource {
    return new QueryResourceImpl(i18n);
  }
}
