/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { DomainItemGetQueryInput as DummyMainDomainItemGetQueryInput } from 'src/layer4/domains/dummy-main/queries/item/get/domain-item-get-query-input';

/** Входные данные запроса на получение страницы сущности "DummyMain". */
export class DummyMainItemPageGetQueryInput {
  /** Входные данные запроса на получение элемента в домене "DummyMain". */
  inputOfDummyMainDomainItemGetQuery = new DummyMainDomainItemGetQueryInput();
}
