/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { QueryWithInputAndOutputHandler } from 'src/layer1/query/handlers/query-with-input-and-output-handler';
import { DomainItemGetQueryInput } from './domain-item-get-query-input';
import { DomainItemGetQueryOutput } from './domain-item-get-query-output';

/** Обработчик запроса на получение элемента в домене. */
export interface DomainItemGetQueryHandler
  extends QueryWithInputAndOutputHandler<DomainItemGetQueryInput, DomainItemGetQueryOutput> {}
