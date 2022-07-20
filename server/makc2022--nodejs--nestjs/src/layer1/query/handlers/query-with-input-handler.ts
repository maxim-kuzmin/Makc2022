/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { QueryHandler } from '../query-handler';
import { QueryResult } from '../query-result';

/** Обработчик запроса с входными данными.
 * @template TQueryInput Тип входных данных запроса.
 * @template TQueryOutput Тип выходных данных запроса.
 */
export interface QueryWithInputHandler<TQueryInput> extends QueryHandler {
  /** Входные данные запроса. */
  queryInput: TQueryInput;

  /** Результат выполнения запроса. */
  queryResult: QueryResult;

  /** Обработать начало.
   * @param queryInput Входные данные запроса.
   * @param queryCode Код запроса.
   */
  onStart(queryInput: TQueryInput, queryCode?: string): void;

  /** Обработать успех. */
  onSuccess(): void;

  /** Обработать успех с результатом.
   * @param queryResult Результат запроса.
   */
  onSuccessWithResult(queryResult: QueryResult): void;
}
