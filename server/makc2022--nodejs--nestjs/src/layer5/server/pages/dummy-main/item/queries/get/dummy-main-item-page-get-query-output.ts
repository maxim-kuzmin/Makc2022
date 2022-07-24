/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { DomainItemGetQueryOutput as DummyMainDomainItemGetQueryOutput } from '../../../../../../../layer4/domains/dummy-main/queries/item/get/domain-item-get-query-output';

/** Выходные данные запроса на получение страницы сущности "DummyMain". */
export class DummyMainItemPageGetQueryOutput {
  /** Выходные данные запроса на получение элемента в домене "DummyMain". */
  outputOfDummyMainDomainItemGetQuery = new DummyMainDomainItemGetQueryOutput();
}
