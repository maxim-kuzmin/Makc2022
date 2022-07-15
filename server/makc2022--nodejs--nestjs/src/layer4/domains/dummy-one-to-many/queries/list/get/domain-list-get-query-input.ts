/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from 'src/layer1/common/common-functions';
import { ConvertingExtension } from 'src/layer1/converting/converting.extension';
import { QuerySettings } from 'src/layer1/query/query-settings';
import { ListGetQueryInput } from 'src/layer2/nosql-mongo/queries/list/get/item-list-query-input';
import { MapperDummyMainEntityObject } from 'src/layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-main/mapper-dummy-main-entity.object';

/** Входные данные запроса на получение элемента в домене. */
export class DomainListGetQueryInput extends ListGetQueryInput {
  /** Идентификаторы сущности. */
  entityIds: string[];

  /** Строка идентификаторов сущности. */
  entityIdsString: string;

  /** Имя сущности. */
  entityName: string;

  /** @inheritdoc */
  override normalize(): void {
    super.normalize();

    if (!this.sortField) {
      this.sortField = nameof<MapperDummyMainEntityObject>('id');
    }

    if (!this.sortDirection) {
      this.sortDirection = QuerySettings.SORT_DIRECTION_DESC;
    }

    if (!this.entityIdsString && (!this.entityIds || this.entityIds.length === 0)) {
      const idsExt = ConvertingExtension.extString(this.entityIdsString);

      this.entityIds = idsExt.fromStringToStringArray();
    }
  }
}
