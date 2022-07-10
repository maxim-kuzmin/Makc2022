/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { QueryInput } from './../../../query/query-input';

/** Входные данные запроса на получение элемента.
 * @template TID Тип идентификатора.
 */
export abstract class ItemGetQueryInput<TID> extends QueryInput {
  /** Идентификатор сущности. */
  entityId: TID;

  /** Нормализовать. */
  abstract normalize(): void;
}
