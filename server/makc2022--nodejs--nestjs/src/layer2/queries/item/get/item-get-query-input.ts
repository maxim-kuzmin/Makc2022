/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { QueryInput } from './../../../query/query-input';

/** Входные данные запроса на получение элемента. */
export class ItemGetQueryInput extends QueryInput {
  /** Идентификатор сущности. */
  entityId: number;

  /** Нормализовать. */
  normalize(): void {
    if (this.entityId < 0) {
      this.entityId = 0;
    }
  }

  /**@inheritdoc */
  override getInvalidProperties(): string[] {
    const result = super.getInvalidProperties();

    if (this.entityId < 1) {
      result.push('entityId');
    }

    return result;
  }
}
