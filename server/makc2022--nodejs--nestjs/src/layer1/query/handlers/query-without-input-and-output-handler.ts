/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { LoggerService } from '@nestjs/common';
import { CommonEnvironment } from 'src/layer1/common/common-environment';
import { QueryHandler } from '../query-handler';
import { IQueryResource } from '../query-resource.interface';
import { QueryResult } from '../query-result';
import { IQueryWithoutInputAndOutputHandler } from './query-without-input-and-output-handler.interface';

/** Обработчик запроса без входных и выходных данных. */
export class QueryWithoutInputAndOutputHandler
  extends QueryHandler
  implements IQueryWithoutInputAndOutputHandler
{
  /** Функция получения сообщений об успехах. */
  protected functionToGetSuccessMessages: () => string[];

  /** Функция получения сообщений о предупреждениях. */
  protected functionToGetWarningMessages: () => string[];

  /** Результат выполнения запроса. */
  queryResult: QueryResult;

  /** @inheritdoc */
  constructor(
    queryName: string,
    queryResource: IQueryResource,
    logger: LoggerService,
    environment: CommonEnvironment
  ) {
    super(queryName, queryResource, logger, environment);
  }

  /** @inheritdoc */
  onStart(queryCode?: string): void {
    this.doOnStart(queryCode);
  }

  /** @inheritdoc */
  onSuccess(queryResult?: QueryResult): void {
    if (queryResult) {
      this.queryResult = queryResult;

      this.doOnSuccess();
    } else {
      this.initQueryResult(true);

      this.doOnSuccess(this.functionToGetSuccessMessages, this.functionToGetWarningMessages);
    }
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
