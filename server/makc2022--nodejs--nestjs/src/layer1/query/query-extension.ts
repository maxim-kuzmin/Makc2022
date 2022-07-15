/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { QueryResult } from './query-result';
import { QueryResultWithOutput } from './query-result-with-output';

/** Расширение запроса. */
export class QueryExtension {
  private constructor(
    private self: {
      queryResult?: QueryResult;
      queryResults?: QueryResult[];
    }
  ) {}

  /** Расширить результат запроса.
   * @param queryResult Результат запроса.
   */
  static extQueryResult(queryResult: QueryResult): QueryExtension {
    return new QueryExtension({ queryResult });
  }

  /** Расширить результаты запроса.
   * @param queryResults Результаты запроса.
   */
  static extQueryResults(queryResults: QueryResult[]): QueryExtension {
    return new QueryExtension({ queryResults });
  }

  /** Добавить.
   * @param functionToGetQueryResult Функция для получения результата запроса.
   */
  add(functionToGetQueryResult: () => QueryResult): void {
    const queryResult = functionToGetQueryResult();

    this.self.queryResults.push(queryResult);
  }

  /** Добавить с выходными данными.
   * @template TOutput Тип выходных данных.
   * @param functionToGetQueryResult Функция для получения результата запроса.
   * @param actionToSetOutput Действие по установке выходных данных.
   * @returns Признак успешной установки выходных данных.
   */
  addWithOutput<TOutput>(
    functionToGetQueryResult: () => QueryResultWithOutput<TOutput>,
    actionToSetOutput: (output: TOutput) => void
  ): boolean {
    const queryResult = functionToGetQueryResult();

    this.self.queryResults.push(queryResult);

    if (queryResult.isOk && queryResult.output) {
      actionToSetOutput(queryResult.output);

      return true;
    }

    return false;
  }

  /** Добавить асинхронно.
   * @param functionToGetQueryResult Функция для получения результата запроса.
   */
  async addAsync(functionToGetQueryResult: () => Promise<QueryResult>): Promise<void> {
    const queryResult = await functionToGetQueryResult();

    this.self.queryResults.push(queryResult);
  }

  /** Добавить асинхронно с выходными данными.
   * @template TOutput Тип выходных данных.
   * @param functionToGetQueryResult Функция для получения результата запроса.
   * @param actionToSetOutput Действие по установке выходных данных.
   * @returns Признак успешной установки выходных данных.
   */
  async addWithOutputAsync<TOutput>(
    functionToGetQueryResult: () => Promise<QueryResultWithOutput<TOutput>>,
    actionToSetOutput: (output: TOutput) => void
  ): Promise<boolean> {
    const queryResult = await functionToGetQueryResult();

    this.self.queryResults.push(queryResult);

    if (queryResult.isOk && queryResult.output) {
      actionToSetOutput(queryResult.output);

      return true;
    }

    return false;
  }

  /** */
  /// Загрузить.
  /// </summary>
  /// <param name="queryResult">Результат запроса.</param>
  /// <param name="queryResultsToLoad">Результаты запроса для загрузки.</param>
  load(queryResultsToLoad: QueryResult[]): void {
    let isOk = true;

    queryResultsToLoad.forEach((queryResultToLoad) => {
      isOk = isOk && queryResultToLoad.isOk;

      this.self.queryResult.errorMessages = new Set([
        ...this.self.queryResult.errorMessages,
        ...queryResultToLoad.errorMessages,
      ]);

      this.self.queryResult.successMessages = new Set([
        ...this.self.queryResult.successMessages,
        ...queryResultToLoad.successMessages,
      ]);

      this.self.queryResult.warningMessages = new Set([
        ...this.self.queryResult.warningMessages,
        ...queryResultToLoad.warningMessages,
      ]);
    });

    this.self.queryResult.isOk = isOk;
  }
}
