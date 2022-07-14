/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { QueryHandler } from '../query-handler';
import { QueryResult } from '../query-result';

/** Обработчик запроса без входных и выходных данных. */
export interface QueryWithoutInputAndOutputHandler extends QueryHandler {
  /** Результат выполнения запроса. */
  queryResult: QueryResult;

  /** Обработать начало запроса.
   * @param queryCode Код запроса.
   */
  onStart(queryCode?: string): void;

  /** Обработать успешное выполнение запроса. */
  onSuccess(): void;

  /** Обработать успешное выполнение запроса с результатом.
   * @param queryResult Результат запроса.
   */
  onSuccessWithResult(queryResult?: QueryResult): void;
}
