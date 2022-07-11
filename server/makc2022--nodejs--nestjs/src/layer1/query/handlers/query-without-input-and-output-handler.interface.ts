/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { IQueryHandler } from '../query-handler.interface';
import { QueryResult } from '../query-result';

/** Интерфейс обработчика запроса с входными и выходными данными. */
export interface IQueryWithoutInputAndOutputHandler extends IQueryHandler {
  /** Результат выполнения запроса. */
  queryResult: QueryResult;

  /** Обработать начало запроса.
   * @param queryCode Код запроса.
   */
  onStart(queryCode?: string): void;

  /** Обработать успешное выполнение запроса. */
  onSuccess(): void;

  /** Обработать успешное выполнение запроса.
   * @param queryResult Результат запроса.
   */
  onSuccess(queryResult: QueryResult): void;
}
