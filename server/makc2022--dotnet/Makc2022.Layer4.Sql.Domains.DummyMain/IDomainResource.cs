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
        /// Получить имя запроса на получение элемента.
        /// </summary>
        /// <returns>Имя запроса.</returns>
        string GetItemGetQueryName();

        /// <summary>
        /// Получить имя запроса на получение списка.
        /// </summary>
        /// <returns>Имя запроса.</returns>
        string GetListGetQueryName();

        #endregion Methods
    }
}
