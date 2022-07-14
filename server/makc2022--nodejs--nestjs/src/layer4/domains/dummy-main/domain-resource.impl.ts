/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { I18nContext } from 'nestjs-i18n';
import { DomainResource } from './domain-resource';

/** Реализация ресурса домена. */
export class DomainResourceImpl implements DomainResource {
  private path = 'layer4--domains--dummy-main';

  /** Конструктор.
   * @param i18n Контекст интернационализации.
   */
  constructor(private readonly i18n: I18nContext) {}

  /** @inheritdoc */
  getItemGetQueryName(): string {
    return this.i18n.t(`${this.path}.@@ItemGetQueryName`);
  }

  /** @inheritdoc */
  getListGetQueryName(): string {
    return this.i18n.t(`${this.path}.@@ListGetQueryName`);
  }
}
