// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Operation;

namespace Makc2022.Layer2.Sql.Operations.Item.Get
{
    /// <summary>
    /// Входные данные операции получения элемента.
    /// </summary>
    public class ItemGetOperationInput : OperationInput
    {
        #region Properties

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Нормализовать.
        /// </summary>
        public virtual void Normalize()
        {
            if (Id < 0)
            {
                Id = 0;
            }
        }

        /// <inheritdoc/>
        public override List<string> GetInvalidProperties()
        {
            var result = base.GetInvalidProperties();

            if (Id < 1)
            {
                result.Add(nameof(Id));
            }

            return result;
        }

        #endregion Public methods
    }
}
