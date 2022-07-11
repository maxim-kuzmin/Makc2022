/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { I18nContext } from 'nestjs-i18n';
import { IQueryResource } from './query-resource.interface';

/** Ресурс запроса. */
export class QueryResource implements IQueryResource {
  private path = 'layer1--query';

  /** Конструктор.
   * @param i18n Контекст интернационализации.
   */
  constructor(private readonly i18n: I18nContext) {}

  /** @inheritdoc */
  getErrorMessageForDefault(): string {
    return this.i18n.t(`${this.path}.@@ErrorMessageForDefault`);
  }

  /** @inheritdoc */
  getErrorMessageForInvalidInput(invalidProperties: string[]): string {
    return this.i18n.t(`${this.path}.@@ErrorMessageForInvalidInput`, {
      args: { properties: invalidProperties.join(', ') },
    });
  }

  /** @inheritdoc */
  getTitleForError(): string {
    return this.i18n.t(`${this.path}.@@TitleForError`);
  }

  /** @inheritdoc */
  getTitleForInput(): string {
    return this.i18n.t(`${this.path}.@@TitleForInput`);
  }

  /** @inheritdoc */
  getTitleForQueryCode(): string {
    return this.i18n.t(`${this.path}.@@TitleForQueryCode`);
  }

  /** @inheritdoc */
  getTitleForResult(): string {
    return this.i18n.t(`${this.path}.@@TitleForResult`);
  }

  /** @inheritdoc */
  getTitleForStart(): string {
    return this.i18n.t(`${this.path}.@@TitleForStart`);
  }

  /** @inheritdoc */
  getTitleForSuccess(): string {
    return this.i18n.t(`${this.path}.@@TitleForSuccess`);
  }
}
