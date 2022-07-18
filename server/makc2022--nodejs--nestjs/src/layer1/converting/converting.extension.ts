/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { format } from 'date-fns';
import { ConvertingResource } from './converting-resource';

/** Расширение преобразования. */
export class ConvertingExtension {
  private constructor(
    private self: {
      dateValue?: Date;
      stringValue?: string;
    }
  ) {}

  /** Расширить дату.
   * @param dateValue Значение даты.
   */
  static extDate(dateValue: Date): ConvertingExtension {
    return new ConvertingExtension({ dateValue });
  }

  /** Расширить строку.
   * @param stringValue Значение строки.
   */
  static extString(stringValue: string): ConvertingExtension {
    return new ConvertingExtension({ stringValue });
  }

  /** Преобразовать из даты в строку.
   * @param resource Ресурс.
   * @returns Строковое представление даты.
   */
  fromDateToString(resource: ConvertingResource): string {
    return format(this.self.dateValue, resource.getFormatForDate());
  }

  /** Преобразовать из строки в массив целых чисел.
   * @returns Массив целых чисел.
   */
  fromStringToNumericIntArray(): number[] {
    return this.fromStringToNumericArray((stringValue: string) => parseInt(stringValue));
  }

  /** Преобразовать из строки в массив строк путём разбивки по пробельным символам.
   * @returns Массив строк.
   */
  fromStringToStringArray(): string[] {
    return this.self.stringValue ? this.self.stringValue.split(/\s+/gi) : [];
  }

  private fromStringToNumericArray(functionToParse: (stringValue: string) => number): number[] {
    return this.self.stringValue
      ? this.self.stringValue
          .replace(/[^\d\+\-]/gi, ' ')
          .split(' ')
          .filter((x) => x)
          .map((x) => functionToParse(x))
      : [];
  }
}
