// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Query.Handlers
{
    /// <summary>
    /// Интерфейс обработчика запроса с выходными данными.
    /// </summary>
    /// <typeparam name="TQueryOutput">Тип выходных данных запроса.</typeparam>    
    public interface IQueryWithOutputHandler<TQueryOutput> : IQueryHandler
    {
        #region Properties

        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        QueryResultWithOutput<TQueryOutput>? QueryResult { get; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Обработать начало.
        /// </summary>
        /// <param name="queryCode">Код запроса.</param>
        void OnStart(string? queryCode = null);

        /// <summary>
        /// Обработать успех.
        /// </summary>
        /// <param name="queryOutput">Выходные данные запроса.</param>
        void OnSuccess(TQueryOutput queryOutput);

        /// <summary>
        /// Обработать успех с результатом.
        /// </summary>
        /// <param name="queryResult">Результат запроса.</param>
        void OnSuccessWithResult(QueryResultWithOutput<TQueryOutput> queryResult);

        #endregion Public methods
    }
}
