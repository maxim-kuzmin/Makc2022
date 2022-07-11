/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { IQueryHandler } from '../query-handler.interface';
import { QueryResultWithOutput } from '../query-result-with-output';

/** Интерфейс обработчика запроса с выходными данными.
 * @template TQueryOutput Тип выходных данных запроса.
 */
export interface IQueryWithOutputHandler<TQueryOutput> extends IQueryHandler {
  /** Результат выполнения запроса. */
  queryResult: QueryResultWithOutput<TQueryOutput>;

  /** Обработать начало запроса.
   * @param queryCode Код запроса.
   */
  onStart(queryCode?: string): void;

  /** Обработать успешное выполнение запроса.
   * @param queryOutput Выходные данные запроса.
   */
  onSuccess(queryOutput: TQueryOutput): void;

  /** Обработать успешное выполнение запроса с результатом.
   * @param queryResult Результат запроса.
   */
  onSuccessWithResult(queryResult: QueryResultWithOutput<TQueryOutput>);
}
