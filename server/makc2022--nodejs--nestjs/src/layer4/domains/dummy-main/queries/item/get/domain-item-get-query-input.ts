/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { nameof } from 'src/layer1/common/common-functions';
import { MapperItemGetQueryInput } from 'src/layer3/sample/mappers/typegoose/queries/item/get/mapper-item-get-query-input';

export class DomainItemGetQueryInput extends MapperItemGetQueryInput {
  /** Имя сущности. */
  entityName: string;

  /**@inheritdoc */
  override normalize(): void {
    super.normalize();

    if (this.entityId) {
      this.entityName = null;
    }
  }

  /**@inheritdoc */
  override getInvalidProperties(): string[] {
    const result = super.getInvalidProperties();

    if (result.length > 0) {
      if (this.entityName !== null) {
        result.length = 0;
      } else {
        result.push(nameof<DomainItemGetQueryInput>('entityName'));
      }

      return result;
    }
  }
}
