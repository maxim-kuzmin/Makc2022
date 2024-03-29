﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Converting;
using Makc2022.Layer1.Operation;
using Makc2022.Layer2.Sql.Operations.List.Get;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMain;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get
{
    /// <summary>
    /// Входные данные операции получения списка в домене.
    /// </summary>
    public class DomainListGetOperationInput : ListGetOperationInput
    {
        #region Properties

        /// <summary>
        /// Идентификаторы.
        /// </summary>
        public long[]? Ids { get; set; }

        /// <summary>
        /// Строка идентификаторов.
        /// </summary>
        public string? IdsString { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Идентификатор экземпляра сущности "Фиктивное отношение один ко многим".
        /// </summary>
        public long DummyOneToManyId { get; set; }

        /// <summary>
        /// Идентификаторы экземпляров сущности "Фиктивное отношение один ко многим".
        /// </summary>
        public long[]? DummyOneToManyIds { get; set; }

        /// <summary>
        /// Строка идентификаторов экземпляров сущности "Фиктивное отношение один ко многим".
        /// </summary>
        public string? DummyOneToManyIdsString { get; set; }

        /// <summary>
        /// Имя экземпляра сущности "Фиктивное отношение один ко многим".
        /// </summary>
        public string? DummyOneToManyName { get; set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Normalize()
        {
            base.Normalize();

            if (string.IsNullOrWhiteSpace(SortField))
            {
                SortField = nameof(MapperDummyMainTypeEntity.Id);
            }

            if (string.IsNullOrWhiteSpace(SortDirection))
            {
                SortDirection = OperationOptions.SORT_DIRECTION_DESC;
            }

            if (!string.IsNullOrWhiteSpace(IdsString) && (Ids == null || !Ids.Any()))
            {
                Ids = IdsString.FromStringToNumericInt64Array();
            }

            if (!string.IsNullOrWhiteSpace(DummyOneToManyIdsString)
                &&
                (
                    DummyOneToManyIds == null
                    ||
                    !DummyOneToManyIds.Any()
                ))
            {
                DummyOneToManyIds = DummyOneToManyIdsString.FromStringToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}
