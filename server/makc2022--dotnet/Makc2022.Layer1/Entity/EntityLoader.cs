// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Entity
{
    /// <summary>
    /// Загрузчик сущности.
    /// </summary>
    /// <typeparam name="TEntityObject">Тип объекта сущности.</typeparam>
    public abstract class EntityLoader<TEntityObject>
    {
        #region Properties

        /// <summary>
        /// Объект сущности.
        /// </summary>
        public TEntityObject EntityObject { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        public EntityLoader(TEntityObject entityObject)
        {
            EntityObject = entityObject;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить.
        /// </summary>
        /// <param name="entityObject">Объект сущности.</param>
        /// <param name="loadableProperties">Загружаемые свойства.</param>
        /// <returns>Загруженные свойства.</returns>
        public virtual HashSet<string> Load(TEntityObject entityObject, HashSet<string>? loadableProperties = null)
        {
            return loadableProperties ?? CreateAllPropertiesToLoad();
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать все свойства для загрузки.
        /// </summary>
        /// <returns>Все свойства для загрузки.</returns>
        protected abstract HashSet<string> CreateAllPropertiesToLoad();

        #endregion Protected methods
    }
}