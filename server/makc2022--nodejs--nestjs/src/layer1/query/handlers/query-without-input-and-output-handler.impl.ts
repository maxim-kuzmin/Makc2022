/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { LoggerService } from '@nestjs/common';
import { QueryHandlerImpl } from '../query-handler.impl';
import { QueryResource } from '../query-resource';
import { QueryResult } from '../query-result';
import { QueryWithoutInputAndOutputHandler } from './query-without-input-and-output-handler';

/** Реализация обработчика запроса без входных и выходных данных. */
export class QueryWithoutInputAndOutputHandlerImpl
  extends QueryHandlerImpl
  implements QueryWithoutInputAndOutputHandler
{
  /** Функция получения сообщений об успехах. */
  protected functionToGetSuccessMessages: () => string[];

  /** Функция получения сообщений о предупреждениях. */
  protected functionToGetWarningMessages: () => string[];

  /** Результат выполнения запроса. */
  queryResult: QueryResult;

  /** @inheritdoc */
  constructor(queryName: string, queryResource: QueryResource, logger: LoggerService) {
    super(queryName, queryResource, logger);
  }

  /** @inheritdoc */
  onStart(queryCode?: string): void {
    this.doOnStart(queryCode);
  }

  /** @inheritdoc */
  onSuccess(): void {
    this.initQueryResult(true);

    this.doOnSuccess(this.functionToGetSuccessMessages, this.functionToGetWarningMessages);
  }

  /** @inheritdoc */
  onSuccessWithResult(queryResult: QueryResult): void {
    this.queryResult = queryResult;

    this.doOnSuccess();
  }

  /** @inheritdoc */
  protected override getQueryInput(): unknown {
    return null;
  }

  /** @inheritdoc */
  protected override getQueryResult(): QueryResult {
    return this.queryResult;
  }

  /** @inheritdoc */
  protected override initQueryResult(isOk: boolean): void {
    this.queryResult = new QueryResult();
    this.queryResult.isOk = isOk;
    this.queryCode = this.queryCode;
  }
}
