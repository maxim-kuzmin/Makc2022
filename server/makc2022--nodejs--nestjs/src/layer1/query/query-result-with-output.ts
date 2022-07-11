/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { QueryResult } from './query-result';

/** Результат запроса с выходными данными.
 * @template TOutput Тип выходных данных.
 */
export class QueryResultWithOutput<TOutput> extends QueryResult {
  /** Выходные данные. */
  output: TOutput;
}
