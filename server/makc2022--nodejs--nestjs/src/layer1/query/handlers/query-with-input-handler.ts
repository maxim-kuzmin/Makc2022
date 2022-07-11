/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { LoggerService } from '@nestjs/common';
import { CommonEnvironment } from 'src/layer1/common/common-environment';
import { QueryHandler } from '../query-handler';
import { IQueryResource } from '../query-resource.interface';
import { QueryResult } from '../query-result';
import { IQueryWithInputHandler } from './query-with-input-handler.interface';

/** Интерфейс обработчика запроса с входными данными.
 * @template TQueryInput Тип входных данных запроса.
 */
export class QueryWithInputHandler<TQueryInput>
  extends QueryHandler
  implements IQueryWithInputHandler<TQueryInput>
{
  /** Функция преобразования ввода запроса. */
  protected functionToTransformQueryInput: (queryInput: TQueryInput) => TQueryInput;

  /** Функция получения сообщений об успехах. */
  protected functionToGetSuccessMessages: (queryInput: TQueryInput) => string[];

  /** Функция получения сообщений о предупреждениях. */
  protected functionToGetWarningMessages: (queryInput: TQueryInput) => string[];

  /** @inheritdoc */
  queryInput: TQueryInput;

  /** @inheritdoc */
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
  onStart(queryInput: TQueryInput, queryCode?: string): void {
    this.queryInput = this.functionToTransformQueryInput
      ? this.functionToTransformQueryInput(queryInput)
      : queryInput;

    this.doOnStart(queryCode);
  }

  /** @inheritdoc */
  onSuccess(): void {
    this.initQueryResult(true);

    let functionToGetSuccessMessages: () => string[];

    if (this.functionToGetSuccessMessages) {
      functionToGetSuccessMessages = () => this.functionToGetSuccessMessages(this.queryInput);
    }

    let functionToGetWarningMessages: () => string[];

    if (this.functionToGetWarningMessages) {
      functionToGetWarningMessages = () => this.functionToGetWarningMessages(this.queryInput);
    }

    this.doOnSuccess(functionToGetSuccessMessages, functionToGetWarningMessages);
  }

  /** @inheritdoc */
  onSuccessWithResult(queryResult: QueryResult): void {
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
    this.queryResult = new QueryResult();
    this.queryResult.isOk = isOk;
    this.queryCode = this.queryCode;
  }
}
