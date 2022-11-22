// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1
{
    /// <summary>
    /// Загрузчик типа.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public abstract class TypeLoader<TEntity>
    {
        #region Properties

        /// <summary>
        /// Сущность.
        /// </summary>
        public TEntity Entity { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="entity">Cущность.</param>
        public TypeLoader(TEntity entity)
        {
            Entity = entity;
        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// Загрузить.
        /// </summary>
        /// <param name="entity">Cущность.</param>
        /// <param name="loadableProperties">Загружаемые свойства.</param>
        /// <returns>Загруженные свойства.</returns>
        public virtual HashSet<string> Load(TEntity entity, HashSet<string>? loadableProperties = null)
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