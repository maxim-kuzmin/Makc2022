// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Query.Handlers
{
    /// <summary>
    /// Интерфейс обработчика запроса без входных и выходных данных.
    /// </summary>
    public interface IQueryWithoutInputAndOutputHandler : IQueryHandler
    {
        #region Properties

        /// <summary>
        /// Результат выполнения запроса.
        /// </summary>
        QueryResult? QueryResult { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Обработать начало.
        /// </summary>
        /// <param name="queryCode">Код запроса.</param>
        void OnStart(string? queryCode = null);

        /// <summary>
        /// Обработать успех.
        /// </summary>
        public void OnSuccess();

        /// <summary>
        /// Обработать успех с результатом.
        /// </summary>
        /// <param name="queryResult">Результат запроса.</param>
        void OnSuccessWithResult(QueryResult queryResult);

        #endregion Methods
    }
}
