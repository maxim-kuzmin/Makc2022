// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.App
{
    /// <summary>
    /// Интерфейс ресурса приложения.
    /// </summary>
    public interface IAppResource
    {
        #region Methods

        /// <summary>
        /// Получить сообщение об ошибке для не импортированных типов.
        /// </summary>
        /// <param name="types">Типы.</param>
        /// <returns>Сообщение об ошибке.</returns>
        string GetErrorMessageForNotImportedTypes(IEnumerable<Type> types);

        #endregion Methods
    }
}
