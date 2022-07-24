/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { Injectable } from '@nestjs/common';
import { DomainService as DummyMainDomainService } from '../../../../../layer4/domains/dummy-main/domain.service';
import { DomainItemGetQueryHandler as DummyMainDomainItemGetQueryHandler } from '../../../../../layer4/domains/dummy-main/queries/item/get/domain-item-get-query-handler';
import { QueryResultWithOutput } from '../../../../../layer1/query/query-result-with-output';
import { DummyMainItemPageGetQueryInput } from './queries/get/dummy-main-item-page-get-query-input';
import { DummyMainItemPageGetQueryOutput } from './queries/get/dummy-main-item-page-get-query-output';

@Injectable()
export class DummyMainItemPageService {
  constructor(private readonly serviceOfDummyMainDomain: DummyMainDomainService) {}

  async Get(
    input: DummyMainItemPageGetQueryInput,
    handlerOfDummyMainDomainItemGetQuery: DummyMainDomainItemGetQueryHandler,
    queryCode?: string
  ): Promise<QueryResultWithOutput<DummyMainItemPageGetQueryOutput>> {
    const result = new QueryResultWithOutput<DummyMainItemPageGetQueryOutput>();

    return result;
  }
}
