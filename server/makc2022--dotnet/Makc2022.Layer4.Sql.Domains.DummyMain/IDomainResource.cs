// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer4.Sql.Domains.DummyMain
{
    /// <summary>
    /// Интерфейс ресурса домена.
    /// </summary>
    public interface IDomainResource
    {
        #region Methods

        /// <summary>
        /// Получить имя операции получения элемента.
        /// </summary>
        /// <returns>Имя операции.</returns>
        string GetItemGetOperationName();

        /// <summary>
        /// Получить имя операции получения списка.
        /// </summary>
        /// <returns>Имя операции.</returns>
        string GetListGetOperationName();

        #endregion Methods
    }
}
