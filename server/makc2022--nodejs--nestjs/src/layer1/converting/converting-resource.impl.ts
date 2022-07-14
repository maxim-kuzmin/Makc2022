/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { I18nContext } from 'nestjs-i18n';
import { ConvertingResource } from './converting-resource';

/** Реализация ресурса преобразования. */
export class ConvertingResourceImpl implements ConvertingResource {
  private path = 'layer1--convering';

  /** Конструктор.
   * @param i18n Контекст интернационализации.
   */
  constructor(private readonly i18n: I18nContext) {}

  /** @inheritdoc */
  getFormatForDate(): string {
    return this.i18n.t(`${this.path}.@@FormatForDate`);
  }
}
