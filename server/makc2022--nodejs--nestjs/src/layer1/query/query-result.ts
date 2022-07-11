/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { QueryHelper } from './query-helper';

/** Результат запроса. */
export class QueryResult {
  /** Признак успешности выполнения. */
  isOk: boolean;

  /** Сообщения об ошибках. */
  errorMessages = new Set<string>();

  /** Код запроса. */
  queryCode = QueryHelper.createQueryCode();

  /** Сообщения об успехах. */
  successMessages = new Set<string>();

  /** Сообщения о предупреждениях. */
  warningMessages = new Set<string>();
}
