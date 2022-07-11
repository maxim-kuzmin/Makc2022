/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { LoggerService } from '@nestjs/common';
import { CommonEnvironment } from '../common/common-environment';
import { CommonError } from '../common/common-error';
import { IQueryHandler } from './query-handler.interface';
import { QueryHelper } from './query-helper';
import { IQueryResource } from './query-resource.interface';
import { QueryResult } from './query-result';

/** Обработчик запроса. */
export abstract class QueryHandler implements IQueryHandler {
  private title: string;

  /** Функция получения сообщений об ошибках. */
  protected functionToGetErrorMessages: (error: Error) => string[];

  /** Код запроса. */
  protected queryCode: string;

  /** Конструктор.
   * @param queryName Имя запроса.
   * @param queryResource Ресурс запроса.
   * @param logger Регистратор.
   * @param environment Окружение.
   */
  constructor(
    private readonly queryName: string,
    protected readonly queryResource: IQueryResource,
    protected readonly logger: LoggerService,
    protected readonly environment: CommonEnvironment
  ) {}

  /** @inheritdoc */
  onError(error?: Error): void {
    if (error) {
      this.initQueryResult(false);
    }

    const queryResult = this.getQueryResult();

    let errorMessage: string;

    const errorMessages = this.getErrorMessages(error);

    if (errorMessages && errorMessages.length > 0) {
      queryResult.errorMessages = new Set([...queryResult.errorMessages, ...errorMessages]);

      errorMessage = errorMessages.join('. ').replace('!.', '!').replace('?.', '?');
    } else {
      errorMessage = this.queryResource.getErrorMessageForDefault();

      queryResult.errorMessages.add(errorMessage);
    }

    if (this.logger) {
      const titleForError = this.queryResource.getTitleForError();

      this.logger.error(`${this.title}${titleForError}. ${errorMessage}`, error);
    }
  }

  /** Сделать в начале запроса.
   * @param queryCode Код запроса.
   */
  protected doOnStart(queryCode: string): void {
    this.queryCode = queryCode ?? QueryHelper.createQueryCode();

    const titleForQueryCode = this.queryResource.getTitleForQueryCode();

    if (queryCode) {
      this.queryCode = queryCode;
    }

    this.title = `${this.queryName}. ${titleForQueryCode}: ${this.queryCode}. `;

    if (this.environment.isTest() || this.environment.isDevelopment()) {
      this.logStartIfTestOrDebugEnabled();
    }
  }

  /** Сделать в случае успешного выполнения запроса.
   * @param functionToGetSuccessMessages Функция получения сообщений об успехах.
   * @param functionToGetWarningMessages Функция получения сообщений о предупреждениях.
   */
  protected doOnSuccess(
    functionToGetSuccessMessages?: () => string[],
    functionToGetWarningMessages?: () => string[]
  ): void {
    const queryResult = this.getQueryResult();

    if (queryResult.isOk) {
      if (functionToGetSuccessMessages != null) {
        const messages = functionToGetSuccessMessages();

        if (messages && messages.length > 0) {
          queryResult.successMessages = new Set([...queryResult.successMessages, ...messages]);
        }
      }

      if (functionToGetWarningMessages != null) {
        const messages = functionToGetWarningMessages();

        if (messages && messages.length > 0) {
          queryResult.warningMessages = new Set([...queryResult.warningMessages, ...messages]);
        }
      }

      if (this.environment.isTest() || this.environment.isDevelopment()) {
        this.logSuccessIfTestOrDebugEnabled();
      }
    } else {
      this.onError();
    }
  }

  /** Получить входные данные запроса.
   * @returns Входные данные запроса.
   */
  protected abstract getQueryInput(): unknown;

  /** Получить результат выполнения запроса.
   * @returns Результат выполнения запроса.
   */
  protected abstract getQueryResult(): QueryResult;

  /** Инициализировать результат запроса.
   * @param isOk Признак успешности выполнения.
   */
  protected abstract initQueryResult(isOk: boolean): void;

  private getErrorMessages(error: Error): string[] {
    let result: string[];

    if (this.functionToGetErrorMessages) {
      result = this.functionToGetErrorMessages(error);
    }

    if (result == null || result.length === 0) {
      let errorMessage: string;

      if (error instanceof CommonError) {
        errorMessage = error.message;
      }

      if (errorMessage) {
        result = [errorMessage];
      }
    }
    return result;
  }

  private logStartIfTestOrDebugEnabled(): void {
    if (this.logger?.debug) {
      const queryInput = this.getQueryInput();

      const titleForStart = this.queryResource.getTitleForStart();
      const titleForInput = this.queryResource.getTitleForInput();
      let valueForInput = queryInput && JSON.stringify(queryInput);

      valueForInput = !valueForInput ? `. ${titleForInput}: ${valueForInput}` : '';

      this.logger.debug(`${this.title}${titleForStart}${valueForInput}`);
    }
  }

  private logSuccessIfTestOrDebugEnabled(): void {
    if (this.logger?.debug) {
      const queryResult = this.getQueryResult();

      const titleForSuccess = this.queryResource.getTitleForSuccess();
      const titleForResult = this.queryResource.getTitleForResult();
      const valueForResult = JSON.stringify(queryResult);

      this.logger.debug(`${this.title}${titleForSuccess}. ${titleForResult}: ${valueForResult}`);
    }
  }
}
