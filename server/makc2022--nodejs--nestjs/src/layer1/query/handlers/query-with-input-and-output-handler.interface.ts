/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { IQueryHandler } from '../query-handler.interface';
import { QueryResultWithOutput } from '../query-result-with-output';

/** Интерфейс обработчика запроса с входными и выходными данными.
 * @template TQueryInput Тип входных данных запроса.
 * @template TQueryOutput Тип выходных данных запроса.
 */
export interface IQueryWithInputAndOutputHandler<TQueryInput, TQueryOutput> extends IQueryHandler {
  /** Входные данные запроса. */
  queryInput: TQueryInput;

  /** Результат выполнения запроса. */
  queryResult: QueryResultWithOutput<TQueryOutput>;

  /** Обработать начало запроса.
   * @param queryInput Входные данные запроса.
   * @param queryCode Код запроса.
   */
  onStart(queryInput: TQueryInput, queryCode?: string): void;

  /** Обработать успешное выполнение запроса.
   * @param queryOutput Выходные данные запроса.
   */
  onSuccess(queryOutput: TQueryOutput): void;

  /** Обработать успешное выполнение запроса.
   * @param queryResult Результат запроса.
   */
  onSuccess(queryResult: QueryResultWithOutput<TQueryOutput>): void;
}
