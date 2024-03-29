/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { LoggerService } from '@nestjs/common';
import { QueryHandlerImpl } from '../query-handler.impl';
import { QueryResource } from '../query-resource';
import { QueryResult } from '../query-result';
import { QueryWithInputHandler } from './query-with-input-handler';

/** Реализация обработчика запроса с входными данными.
 * @template TQueryInput Тип входных данных запроса.
 */
export class QueryWithInputHandlerImpl<TQueryInput>
  extends QueryHandlerImpl
  implements QueryWithInputHandler<TQueryInput>
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
  constructor(queryName: string, queryResource: QueryResource, logger: LoggerService) {
    super(queryName, queryResource, logger);
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

    if (this.functionToGetSuccessMessages && this.queryInput) {
      functionToGetSuccessMessages = () => this.functionToGetSuccessMessages(this.queryInput);
    }

    let functionToGetWarningMessages: () => string[];

    if (this.functionToGetWarningMessages && this.queryInput) {
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

    if (this.queryCode) {
      this.queryResult.queryCode = this.queryCode;
    }
  }
}
