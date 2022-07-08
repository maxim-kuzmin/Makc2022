/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { ItemGetQueryInput } from './../../../../../../layer2/queries/item/get/item-get-query-input';

export class DomainItemGetQueryInput extends ItemGetQueryInput {
  /** Имя сущности. */
  entityName: string;

  /**@inheritdoc */
  override normalize(): void {
    super.normalize();

    if (this.entityId > 0) {
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
        result.push('entityName');
      }

      return result;
    }
  }
}
