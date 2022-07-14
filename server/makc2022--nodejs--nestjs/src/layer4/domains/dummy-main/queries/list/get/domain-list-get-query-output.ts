/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { ListGetQueryOutput } from 'src/layer2/nosql-mongo/queries/list/get/item-list-query-output';
import { DomainItemGetQueryOutput } from '../../item/get/domain-item-get-query-output';

/** Выходные данные запроса на получение списка в домене. */
export class DomainListGetQueryOutput extends ListGetQueryOutput<DomainItemGetQueryOutput> {}
