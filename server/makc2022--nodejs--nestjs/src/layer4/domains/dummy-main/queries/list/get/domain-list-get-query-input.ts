/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from '../../../../../../layer1/common/common-functions';
import { ConvertingExtension } from '../../../../../../layer1/converting/converting.extension';
import { QuerySettings } from '../../../../../../layer1/query/query-settings';
import { ListGetQueryInput } from '../../../../../../layer2/nosql-mongo/queries/list/get/item-list-query-input';
import { MapperDummyMainEntityObject } from '../../../../../../layer3/nosql-mongo/sample/mappers/typegoose/entities/dummy-main/mapper-dummy-main-entity.object';

/** Входные данные запроса на получение элемента в домене. */
export class DomainListGetQueryInput extends ListGetQueryInput {
  /** Идентификаторы сущности. */
  entityIds: string[];

  /** Строка идентификаторов сущности. */
  entityIdsString: string;

  /** Имя сущности. */
  entityName: string;

  /** Идентификатор сущности "DummyOneToMany". */
  idOfDummyOneToManyEntity: string;

  /** Идентификаторы сущности "DummyOneToMany". */
  idsOfDummyOneToManyEntity: string[];

  /** Строка идентификаторов сущности "DummyOneToMany". */
  idsStringOfDummyOneToManyEntity: string;

  /** Имя сущности "DummyOneToMany". */
  nameOfDummyOneToManyEntity: string;

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

    const isOk =
      this.idsStringOfDummyOneToManyEntity &&
      (!this.idsOfDummyOneToManyEntity || this.idsOfDummyOneToManyEntity.length === 0);

    if (isOk) {
      const idsExt = ConvertingExtension.extString(this.idsStringOfDummyOneToManyEntity);

      this.idsOfDummyOneToManyEntity = idsExt.fromStringToStringArray();
    }
  }
}
