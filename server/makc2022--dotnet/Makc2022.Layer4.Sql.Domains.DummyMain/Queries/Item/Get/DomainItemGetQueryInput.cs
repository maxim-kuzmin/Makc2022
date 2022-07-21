// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Queries.Item.Get;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Queries.Item.Get
{
    /// <summary>
    /// Входные данные запроса на получение элемента в домене.
    /// </summary>
    public class DomainItemGetQueryInput : ItemGetQueryInput
    {
        #region Properties

        /// <summary>
        /// Имя сущности.
        /// </summary>
        public string? EntityName { get; set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Normalize()
        {
            base.Normalize();

            if (EntityId > 0)
            {
                EntityName = null;
            }
        }

        /// <inheritdoc/>
        public sealed override List<string> GetInvalidProperties()
        {
            var result = base.GetInvalidProperties();

            if (result.Any())
            {
                if (EntityName != null)
                {
                    result.Clear();
                }
                else
                {
                    result.Add(nameof(EntityName));
                }
            }

            return result;
        }

        #endregion Public methods
    }
}
