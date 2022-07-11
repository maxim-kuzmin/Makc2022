/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { LoggerService } from '@nestjs/common';
import { CommonEnvironment } from 'src/layer1/common/common-environment';
import { QueryHandler } from '../query-handler';
import { IQueryResource } from '../query-resource.interface';
import { QueryResult } from '../query-result';
import { QueryResultWithOutput } from '../query-result-with-output';
import { IQueryWithOutputHandler } from './query-with-output-handler.interface';

/** Интерфейс обработчика запроса с выходными данными.
 * @template TQueryOutput Тип выходных данных запроса.
 */
export class QueryWithOutputHandler<TQueryOutput>
  extends QueryHandler
  implements IQueryWithOutputHandler<TQueryOutput>
{
  /** Функция преобразования вывода запроса. */
  protected functionToTransformQueryOutput: (queryOutput: TQueryOutput) => TQueryOutput;

  /** Функция получения сообщений об успехах. */
  protected functionToGetSuccessMessages: (queryOutput: TQueryOutput) => string[];

  /** Функция получения сообщений о предупреждениях. */
  protected functionToGetWarningMessages: (queryOutput: TQueryOutput) => string[];

  /** @inheritdoc */
  queryResult: QueryResultWithOutput<TQueryOutput>;

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
  onSuccess(queryOutput: TQueryOutput): void {
    this.initQueryResult(true);

    if (this.functionToTransformQueryOutput) {
      queryOutput = this.functionToTransformQueryOutput(queryOutput);
    }

    this.queryResult.output = queryOutput;

    let functionToGetSuccessMessages: () => string[];

    if (this.functionToGetSuccessMessages) {
      functionToGetSuccessMessages = () => this.functionToGetSuccessMessages(queryOutput);
    }

    let functionToGetWarningMessages: () => string[];

    if (this.functionToGetWarningMessages) {
      functionToGetWarningMessages = () => this.functionToGetWarningMessages(queryOutput);
    }

    this.doOnSuccess(functionToGetSuccessMessages, functionToGetWarningMessages);
  }

  /** @inheritdoc */
  onSuccessWithResult(queryResult: QueryResultWithOutput<TQueryOutput>) {
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
    this.queryResult = new QueryResultWithOutput<TQueryOutput>();
    this.queryResult.isOk = isOk;
    this.queryCode = this.queryCode;
  }
}
