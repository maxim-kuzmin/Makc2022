/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { LoggerService } from '@nestjs/common';
import { CommonError } from '../../../../../../layer1/common/common-error';
import { QueryWithInputAndOutputHandlerImpl } from '../../../../../../layer1/query/handlers/query-with-input-and-output-handler.impl';
import { QueryResource } from '../../../../../../layer1/query/query-resource';
import { DomainResource } from '../../../domain-resource';
import { DomainListGetQueryHandler } from './domain-list-get-query-handler';
import { DomainListGetQueryInput } from './domain-list-get-query-input';
import { DomainListGetQueryOutput } from './domain-list-get-query-output';

/** Обработчик запроса на получение списка в домене. */
export class DomainListGetQueryHandlerImpl
  extends QueryWithInputAndOutputHandlerImpl<DomainListGetQueryInput, DomainListGetQueryOutput>
  implements DomainListGetQueryHandler
{
  /** @inheritdoc */
  constructor(domainResource: DomainResource, queryResource: QueryResource, logger: LoggerService) {
    super(domainResource.getListGetQueryName(), queryResource, logger);

    this.functionToTransformQueryInput = this.transformQueryInput;
  }

  private transformQueryInput(input: DomainListGetQueryInput): DomainListGetQueryInput {
    if (input == null) {
      input = new DomainListGetQueryInput();
    }

    input.normalize();

    const invalidProperties = input.getInvalidProperties();

    if (invalidProperties.length > 0) {
      throw new CommonError(this.queryResource.getErrorMessageForInvalidInput(invalidProperties));
    }

    return input;
  }
}
