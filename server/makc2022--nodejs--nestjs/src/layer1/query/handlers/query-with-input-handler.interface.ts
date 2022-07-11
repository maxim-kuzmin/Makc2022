/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { IQueryHandler } from '../query-handler.interface';
import { QueryResult } from '../query-result';

/** Интерфейс обработчика запроса с входными данными.
 * @template TQueryInput Тип входных данных запроса.
 */
export interface IQueryWithInputAndOutputHandler<TQueryInput> extends IQueryHandler {
  /** Входные данные запроса. */
  queryInput: TQueryInput;

  /** Результат выполнения запроса. */
  queryResult: QueryResult;

  /** Обработать начало запроса.
   * @param queryInput Входные данные запроса.
   * @param queryCode Код запроса.
   */
  onStart(queryInput: TQueryInput, queryCode?: string): void;

  /** Обработать успешное выполнение запроса. */
  onSuccess(): void;

  /** Обработать успешное выполнение запроса.
   * @param queryResult Результат запроса.
   */
  onSuccess(queryResult: QueryResult): void;
}
