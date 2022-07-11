/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Guid } from 'guid-typescript';

/** Помощник запроса. */
export class QueryHelper {
  /** Создать код запроса.
   * @returns Код запроса.
   */
  static createQueryCode(): string {
    return Guid.create().toString().replace(/-/g, '').toUpperCase();
  }
}
