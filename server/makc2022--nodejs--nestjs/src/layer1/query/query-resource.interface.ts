/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Интрефейс ресурса запроса. */
export interface IQueryResource {
  /** Получить сообщение об ошибке по умолчанию.
   * @returns Сообщение об ошибке.
   */
  getErrorMessageForDefault(): string;

  /** Получить сообщение об ошибке для недействительных входных данных.
   * @param invalidProperties Недействительные свойства.
   * @returns Сообщение об ошибке.
   */
  getErrorMessageForInvalidInput(invalidProperties: string[]): string;

  /** Получить заголовок для ошибки.
   * @returns Заголовок.
   */
  getTitleForError(): string;

  /** Получить заголовок для входных данных.
   * @returns Заголовок.
   */
  getTitleForInput(): string;

  /** Получить заголовок для кода запроса.
   * @returns Заголовок.
   */
  getTitleForQueryCode(): string;

  /** Получить заголовок для результата.
   * @returns Заголовок.
   */
  getTitleForResult(): string;

  /**  Получить заголовок для начала.
   * @returns Заголовок.
   */
  getTitleForStart(): string;

  /** Получить заголовок для успеха.
   * @returns Заголовок.
   */
  getTitleForSuccess(): string;
}
