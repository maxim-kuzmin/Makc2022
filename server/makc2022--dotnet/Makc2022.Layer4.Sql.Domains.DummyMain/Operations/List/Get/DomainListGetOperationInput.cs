// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Converting;
using Makc2022.Layer1.Operation;
using Makc2022.Layer2.Sql.Operations.List.Get;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get
{
    /// <summary>
    /// Входные данные операции получения списка в домене.
    /// </summary>
    public class DomainListGetOperationInput : ListGetOperationInput
    {
        #region Properties

        /// <summary>
        /// Идентификаторы сущности.
        /// </summary>
        public long[]? EntityIds { get; set; }

        /// <summary>
        /// Строка идентификаторов сущности.
        /// </summary>
        public string? EntityIdsString { get; set; }

        /// <summary>
        /// Имя сущности.
        /// </summary>
        public string? EntityName { get; set; }

        /// <summary>
        /// Идентификатор сущности "DummyOneToMany".
        /// </summary>
        public long IdOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Идентификаторы сущности "DummyOneToMany".
        /// </summary>
        public long[]? IdsOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Строка идентификаторов сущности "DummyOneToMany".
        /// </summary>
        public string? IdsStringOfDummyOneToManyEntity { get; set; }

        /// <summary>
        /// Имя сущности "DummyOneToMany".
        /// </summary>
        public string? NameOfDummyOneToManyEntity { get; set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Normalize()
        {
            base.Normalize();

            if (string.IsNullOrWhiteSpace(SortField))
            {
                SortField = nameof(MapperDummyMainEntityObject.Id);
            }

            if (string.IsNullOrWhiteSpace(SortDirection))
            {
                SortDirection = OperationOptions.SORT_DIRECTION_DESC;
            }

            if (!string.IsNullOrWhiteSpace(EntityIdsString) && (EntityIds == null || !EntityIds.Any()))
            {
                EntityIds = EntityIdsString.FromStringToNumericInt64Array();
            }

            if (!string.IsNullOrWhiteSpace(IdsStringOfDummyOneToManyEntity)
                &&
                (
                    IdsOfDummyOneToManyEntity == null
                    ||
                    !IdsOfDummyOneToManyEntity.Any()
                ))
            {
                IdsOfDummyOneToManyEntity = IdsStringOfDummyOneToManyEntity.FromStringToNumericInt64Array();
            }
        }

        #endregion Public methods
    }
}
