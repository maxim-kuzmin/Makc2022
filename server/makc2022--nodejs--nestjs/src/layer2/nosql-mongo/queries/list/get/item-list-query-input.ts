/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from '../../../../../layer1/common/common-functions';
import { QueryInput } from '../../../../../layer1/query/query-input';
import { QuerySettings } from '../../../../../layer1/query/query-settings';

/** Входные данные запроса на получение списка. */
export abstract class ListGetQueryInput extends QueryInput {
  /** Номер страницы. */
  pageNumber: number;

  /** Размер страницы. */
  pageSize: number;

  /** Поле сортировки. */
  sortField: string;

  /** Направление сортировки. */
  sortDirection: string;

  /** @inheritdoc */
  override getInvalidProperties(): string[] {
    const result = super.getInvalidProperties();

    const sortDirection = this.sortDirection.toLocaleLowerCase();

    if (
      this.sortDirection &&
      QuerySettings.SORT_DIRECTION_ASC.toLowerCase() !== sortDirection &&
      QuerySettings.SORT_DIRECTION_DESC.toLowerCase() !== sortDirection
    ) {
      result.push(nameof<ListGetQueryInput>('sortField'));
    }

    return result;
  }

  /** Нормализовать. */
  normalize(): void {
    if (!this.pageNumber || this.pageNumber < 1) {
      this.pageNumber = 1;
    }

    if (!this.pageSize || this.pageSize < 1) {
      this.pageSize = 0;
    }
  }
}
