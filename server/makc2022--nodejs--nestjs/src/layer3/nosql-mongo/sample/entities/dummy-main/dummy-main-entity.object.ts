/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

/** Объект сущности "DummyMain". */
export interface DummyMainEntityObject {
  /** Идентификатор. */
  id: string;

  /** Имя. */
  name: string;

  /** Идентификатор сущности "DummyOneToMany". */
  idOfDummyOneToManyEntity: string;

  /** Свойство, содержащее логическое значение. */
  propBoolean: boolean;

  /** Свойство, содержащее логическое значение или NULL. */
  propBooleanNullable?: boolean;

  /** Свойство, содержащее дату. */
  propDate: Date;

  /** Свойство, содержащее дату или NULL. */
  propDateNullable?: Date;

  /** Свойство, содержащее десятичную дробь. */
  propDecimal: number;

  /** Свойство, содержащее десятичную дробь или NULL. */
  propDecimalNullable?: number;

  /** Свойство, содержащее целое 32-разрядное число. */
  propInt32: number;

  /** Свойство, содержащее целое 32-разрядное число или NULL. */
  propInt32Nullable?: number;

  /** Свойство, содержащее целое 64-разрядное число. */
  propInt64: number;

  /** Свойство, содержащее целое 64-разрядное число или NULL. */
  propInt64Nullable?: number;

  /** Свойство, содержащее строку. */
  propString: string;

  /** Свойство, содержащее строку или NULL. */
  propStringNullable?: string;
}
