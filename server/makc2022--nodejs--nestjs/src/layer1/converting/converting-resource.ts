/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Ресурс преобразования. */
export interface ConvertingResource {
  /** Получить формат для даты.
   * @returns Формат.
   */
  getFormatForDate(): string;
}
