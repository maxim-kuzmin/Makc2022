// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Operations.Item.Get;

namespace Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get
{
    /// <summary>
    /// Входные данные операции получения элемента в домене.
    /// </summary>
    public class DomainItemGetOperationInput : ItemGetOperationInput
    {
        #region Properties

        /// <summary>
        /// Имя.
        /// </summary>
        public string? Name { get; set; }

        #endregion Properties

        #region Public methods

        /// <inheritdoc/>
        public sealed override void Normalize()
        {
            base.Normalize();

            if (Id > 0)
            {
                Name = null;
            }
        }

        /// <inheritdoc/>
        public sealed override List<string> GetInvalidProperties()
        {
            var result = base.GetInvalidProperties();

            if (result.Any())
            {
                if (Name != null)
                {
                    result.Clear();
                }
                else
                {
                    result.Add(nameof(Name));
                }
            }

            return result;
        }

        #endregion Public methods
    }
}
