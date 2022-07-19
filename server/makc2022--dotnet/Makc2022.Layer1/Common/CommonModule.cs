// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;

namespace Makc2022.Layer1.Common
{
    /// <summary>
    /// Общий модуль.
    /// Используется как базовый класс всех модулей - классов,
    /// предназначенных для подготовки к работе различных частей приложения.    
    /// </summary>
    public abstract class CommonModule
    {
        #region Public methods

        /// <summary>
        /// Настроить сервисы.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        public abstract void ConfigureServices(IServiceCollection services);

        /// <summary>
        /// Получить зависимости.
        /// </summary>
        /// <returns>Зависимости.</returns>
        public virtual IEnumerable<CommonModule> GetDependencies()
        {
            return Enumerable.Empty<CommonModule>();
        }

        /// <summary>
        /// Получить экспортированные типы.
        /// </summary>
        /// <returns>Экспортированные типы.</returns>
        public virtual IEnumerable<Type> GetExports()
        {
            return Enumerable.Empty<Type>();
        }

        /// <summary>
        /// Получить не импортированные типы.
        /// </summary>
        /// <param name="allExports">Все экспортированные типы.</param>
        /// <returns>Не импортированные типы.</returns>
        public IEnumerable<Type> GetNotImportedtTypes(HashSet<Type> allExports)
        {
            return GetImports().Where(x => !allExports.Contains(x));
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать зависимости.
        /// </summary>
        /// <returns>Зависимости.</returns>
        protected IEnumerable<CommonModule> CreateDepedensies(params CommonModule[] modules)
        {
            IEnumerable<CommonModule> result = modules;

            foreach (var module in modules)
            {
                result = result.Union(module.GetDependencies());
            }

            return result;
        }

        /// <summary>
        /// Получить импортированные типы.
        /// </summary>
        /// <returns>Импортированные типы.</returns>
        protected virtual IEnumerable<Type> GetImports()
        {
            return Enumerable.Empty<Type>();
        }

        #endregion Protected methods
    }
}
