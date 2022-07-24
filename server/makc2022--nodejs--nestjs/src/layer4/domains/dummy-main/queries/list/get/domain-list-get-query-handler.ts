/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { QueryWithInputAndOutputHandler } from '../../../../../../layer1/query/handlers/query-with-input-and-output-handler';
import { DomainListGetQueryInput } from './domain-list-get-query-input';
import { DomainListGetQueryOutput } from './domain-list-get-query-output';

/** Обработчик запроса на получение списка в домене. */
export interface DomainListGetQueryHandler
  extends QueryWithInputAndOutputHandler<DomainListGetQueryInput, DomainListGetQueryOutput> {}
