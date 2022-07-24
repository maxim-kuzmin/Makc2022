/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { LoggerService } from '@nestjs/common';
import { QueryHandlerImpl } from '../query-handler.impl';
import { QueryResource } from '../query-resource';
import { QueryResult } from '../query-result';
import { QueryResultWithOutput } from '../query-result-with-output';
import { QueryWithOutputHandler } from './query-with-output-handler';

/** Реализация обработчика запроса с выходными данными.
 * @template TQueryOutput Тип выходных данных запроса.
 */
export class QueryWithOutputHandlerImpl<TQueryOutput>
  extends QueryHandlerImpl
  implements QueryWithOutputHandler<TQueryOutput>
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
  constructor(queryName: string, queryResource: QueryResource, logger: LoggerService) {
    super(queryName, queryResource, logger);
  }

  /** @inheritdoc */
  onStart(queryCode?: string): void {
    this.doOnStart(queryCode);
  }

  /** @inheritdoc */
  onSuccess(queryOutput: TQueryOutput): void {
    this.initQueryResult(true);

    if (this.functionToTransformQueryOutput && queryOutput) {
      queryOutput = this.functionToTransformQueryOutput(queryOutput);
    }

    if (this.queryResult && queryOutput) {
      this.queryResult.output = queryOutput;
    }

    let functionToGetSuccessMessages: () => string[];

    if (this.functionToGetSuccessMessages && queryOutput) {
      functionToGetSuccessMessages = () => this.functionToGetSuccessMessages(queryOutput);
    }

    let functionToGetWarningMessages: () => string[];

    if (this.functionToGetWarningMessages && queryOutput) {
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

    if (this.queryCode) {
      this.queryResult.queryCode = this.queryCode;
    }
  }
}
