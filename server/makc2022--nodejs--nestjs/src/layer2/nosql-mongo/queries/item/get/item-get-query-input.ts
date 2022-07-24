/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from '../../../../../layer1/common/common-functions';
import { QueryInput } from '../../../../../layer1/query/query-input';

/** Входные данные запроса на получение элемента.
 */
export abstract class ItemGetQueryInput extends QueryInput {
  /** Идентификатор сущности. */
  entityId: string;

  /** @inheritdoc */
  override getInvalidProperties(): string[] {
    const result = super.getInvalidProperties();

    if (this.entityId === '') {
      result.push(nameof<ItemGetQueryInput>('entityId'));
    }

    return result;
  }

  /** Нормализовать. */
  normalize(): void {
    if (!this.entityId) {
      this.entityId = '';
    }
  }
}
