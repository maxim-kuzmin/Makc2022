/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { I18nContext } from 'nestjs-i18n';
import { ConvertingResource } from './converting-resource';
import { ConvertingResourceImpl } from './converting-resource.impl';

/** Фабрика преобразования. */
@Injectable()
export class ConvertingFactory {
  /** Создать ресурс.
   * @param i18n Контекст интернационализации.
   * @returns Ресурс.
   */
  createResource(i18n: I18nContext): ConvertingResource {
    return new ConvertingResourceImpl(i18n);
  }
}
