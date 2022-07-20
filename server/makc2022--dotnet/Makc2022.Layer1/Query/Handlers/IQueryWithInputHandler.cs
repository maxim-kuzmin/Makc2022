// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Query.Handlers
{
    /// <summary>
    /// Интерфейс обработчика запроса с входными данными.
    /// </summary>
    /// <typeparam name="TQueryInput">Тип входных данных запроса.</typeparam>
    public interface IQueryWithInputHandler<TQueryInput> : IQueryHandler
    {
        #region Properties

        /// <summary>
        /// Входные данные запроса.
        /// </summary>
        TQueryInput? QueryInput { get; }

        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        QueryResult? QueryResult { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Обработать начало.
        /// </summary>
        /// <param name="queryInput">Входные данные запроса.</param>
        /// <param name="queryCode">Код запроса.</param>
        void OnStart(TQueryInput queryInput, string? queryCode = null);

        /// <summary>
        /// Обработать успех.
        /// </summary>
        void OnSuccess();

        /// <summary>
        /// Обработать успех с результатом.
        /// </summary>
        /// <param name="queryResult">Результат запроса.</param>
        void OnSuccessWithResult(QueryResult queryResult);

        #endregion Methods
    }
}
