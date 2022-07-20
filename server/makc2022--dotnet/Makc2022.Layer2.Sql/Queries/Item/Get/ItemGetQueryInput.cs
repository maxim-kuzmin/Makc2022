// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Query;

namespace Makc2022.Layer2.Sql.Queries.Item.Get
{
    /// <summary>
    /// Входные данные запроса на получение элемента.
    /// </summary>
    public class ItemGetQueryInput : QueryInput
    {
        #region Properties

        /// <summary>
        /// Идентификатор сущности.
        /// </summary>
        public long EntityId { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public virtual void Normalize()
        {
            if (EntityId < 0)
            {
                EntityId = 0;
            }
        }

        /// <inheritdoc/>
        public override List<string> GetInvalidProperties()
        {
            var result = base.GetInvalidProperties();

            if (EntityId < 1)
            {
                result.Add(nameof(EntityId));
            }

            return result;
        }

        #endregion Public methods
    }
}
