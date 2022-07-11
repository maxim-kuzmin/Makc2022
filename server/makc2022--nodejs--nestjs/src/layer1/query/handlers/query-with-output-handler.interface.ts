/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { IQueryHandler } from '../query-handler.interface';
import { QueryResultWithOutput } from '../query-result-with-output';

/** Интерфейс обработчика запроса с выходными данными.
 * @template TQueryOutput Тип выходных данных запроса.
 */
export interface IQueryWithOutputHandler<TQueryOutput> extends IQueryHandler {
  /** Результат выполнения запроса. */
  queryResult: QueryResultWithOutput<TQueryOutput>;
}
