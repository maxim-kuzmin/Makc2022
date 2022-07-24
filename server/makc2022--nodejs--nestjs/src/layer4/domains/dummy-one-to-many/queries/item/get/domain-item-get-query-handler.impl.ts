/** Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License. */

import { LoggerService } from '@nestjs/common';
import { CommonError } from '../../../../../../layer1/common/common-error';
import { QueryWithInputAndOutputHandlerImpl } from '../../../../../../layer1/query/handlers/query-with-input-and-output-handler.impl';
import { QueryResource } from '../../../../../../layer1/query/query-resource';
import { DomainResource } from '../../../domain-resource';
import { DomainItemGetQueryHandler } from './domain-item-get-query-handler';
import { DomainItemGetQueryInput } from './domain-item-get-query-input';
import { DomainItemGetQueryOutput } from './domain-item-get-query-output';

/** Обработчик запроса на получение элемента в домене. */
export class DomainItemGetQueryHandlerImpl
  extends QueryWithInputAndOutputHandlerImpl<DomainItemGetQueryInput, DomainItemGetQueryOutput>
  implements DomainItemGetQueryHandler
{
  /** @inheritdoc */
  constructor(domainResource: DomainResource, queryResource: QueryResource, logger: LoggerService) {
    super(domainResource.getItemGetQueryName(), queryResource, logger);

    this.functionToTransformQueryInput = this.transformQueryInput;
    this.functionToTransformQueryOutput = this.transformQueryOutput;
  }

  private transformQueryInput(input: DomainItemGetQueryInput): DomainItemGetQueryInput {
    if (input == null) {
      input = new DomainItemGetQueryInput();
    }

    input.normalize();

    const invalidProperties = input.getInvalidProperties();

    if (invalidProperties.length > 0) {
      throw new CommonError(this.queryResource.getErrorMessageForInvalidInput(invalidProperties));
    }

    return input;
  }

  private transformQueryOutput(output: DomainItemGetQueryOutput): DomainItemGetQueryOutput {
    return output.objectOfDummyOneToManyEntity ? output : null;
  }
}
