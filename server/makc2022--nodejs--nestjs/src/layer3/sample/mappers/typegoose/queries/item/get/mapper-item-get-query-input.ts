/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { ItemGetQueryInput } from 'src/layer2/queries/item/get/item-get-query-input';

/** Входные данные запроса сопоставителя на получение элемента.
 * @template TID Тип идентификатора.
 */
export class MapperItemGetQueryInput extends ItemGetQueryInput<string> {
  /** Нормализовать. */
  override normalize(): void {
    if (!this.entityId) {
      this.entityId = '';
    }
  }

  /**@inheritdoc */
  override getInvalidProperties(): string[] {
    const result = super.getInvalidProperties();

    if (this.entityId === '') {
      result.push('entityId');
    }

    return result;
  }
}
