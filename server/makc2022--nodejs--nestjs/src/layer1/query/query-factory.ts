/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { I18nContext } from 'nestjs-i18n';
import { IQueryResource } from './query-resource.interface';
import { QueryResource } from './query-resource';

/** Фабрика запроса. */
@Injectable()
export class QueryFactory {
  /** Создать ресурс.
   * @param i18n Контекст интернационализации.
   * @returns Ресурс.
   */
  createResource(i18n: I18nContext): IQueryResource {
    return new QueryResource(i18n);
  }
}
