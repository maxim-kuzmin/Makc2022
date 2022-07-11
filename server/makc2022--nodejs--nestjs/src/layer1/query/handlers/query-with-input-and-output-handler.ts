/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { LoggerService } from '@nestjs/common';
import { CommonEnvironment } from 'src/layer1/common/common-environment';
import { QueryHandler } from '../query-handler';
import { IQueryResource } from '../query-resource.interface';
import { QueryResult } from '../query-result';
import { QueryResultWithOutput } from '../query-result-with-output';
import { IQueryWithInputAndOutputHandler } from './query-with-input-and-output-handler.interface';

/** Интерфейс обработчика запроса с входными данными.
 * @template TQueryInput Тип входных данных запроса.
 * @template TQueryOutput Тип выходных данных запроса.
 */
export class QueryWithInputAndOutputHandler<TQueryInput, TQueryOutput>
  extends QueryHandler
  implements IQueryWithInputAndOutputHandler<TQueryInput, TQueryOutput>
{
  /** Функция преобразования ввода запроса. */
  protected functionToTransformQueryInput: (queryInput: TQueryInput) => TQueryInput;

  /** Функция преобразования вывода запроса. */
  protected functionToTransformQueryOutput: (queryOutput: TQueryOutput) => TQueryOutput;

  /** Функция получения сообщений об успехах. */
  protected functionToGetSuccessMessages: (
    queryInput: TQueryInput,
    queryOutput: TQueryOutput
  ) => string[];

  /** Функция получения сообщений о предупреждениях. */
  protected functionToGetWarningMessages: (
    queryInput: TQueryInput,
    queryOutput: TQueryOutput
  ) => string[];

  /** @inheritdoc */
  queryInput: TQueryInput;

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
  onStart(queryInput: TQueryInput, queryCode?: string): void {
    this.queryInput = this.functionToTransformQueryInput
      ? this.functionToTransformQueryInput(queryInput)
      : queryInput;

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
      functionToGetSuccessMessages = () =>
        this.functionToGetSuccessMessages(this.queryInput, queryOutput);
    }

    let functionToGetWarningMessages: () => string[];

    if (this.functionToGetWarningMessages) {
      functionToGetWarningMessages = () =>
        this.functionToGetWarningMessages(this.queryInput, queryOutput);
    }

    this.doOnSuccess(functionToGetSuccessMessages, functionToGetWarningMessages);
  }

  /** @inheritdoc */
  onSuccessWithResult(queryResult: QueryResultWithOutput<TQueryOutput>): void {
    this.queryResult = queryResult;

    this.doOnSuccess();
  }

  /** @inheritdoc */
  protected override getQueryInput(): unknown {
    return this.queryInput;
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
