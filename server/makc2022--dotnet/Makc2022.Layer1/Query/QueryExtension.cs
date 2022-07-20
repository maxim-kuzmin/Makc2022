// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer1.Query
{
    /// <summary>
    /// Расширение запроса.
    /// </summary>
    public static class QueryExtension
    {
        #region Public methods

        /// <summary>
        /// Добавить.
        /// </summary>
        /// <param name="queryResults">Результаты запроса.</param>
        /// <param name="functionToGetQueryResult">Функция для получения результата запроса.</param>
        public static void Add(ICollection<QueryResult> queryResults, Func<QueryResult> functionToGetQueryResult)
        {
            var queryResult = functionToGetQueryResult.Invoke();

            queryResults.Add(queryResult);
        }

        /// <summary>
        /// Добавить с выходными данными.
        /// </summary>
        /// <typeparam name="TOutput">Тип выходных данных.</typeparam>
        /// <param name="queryResults">Результаты запроса.</param>
        /// <param name="functionToGetQueryResult">Функция для получения результата запроса.</param>
        /// <param name="actionToSetOutput">Действие по установке выходных данных.</param>
        /// <returns>Признак успешной установки выходных данных.</returns>
        public static bool AddWithOutput<TOutput>(
            this ICollection<QueryResult> queryResults,
            Func<QueryResultWithOutput<TOutput>> functionToGetQueryResult,
            Action<TOutput> actionToSetOutput
            )
        {
            var queryResult = functionToGetQueryResult.Invoke();

            queryResults.Add(queryResult);

            if (queryResult.IsOk && queryResult.Output != null)
            {
                actionToSetOutput.Invoke(queryResult.Output);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Добавить.
        /// </summary>
        /// <param name="queryResults">Результаты запроса.</param>
        /// <param name="functionToGetQueryResultTask">
        /// Функция для получения задачи на получение результата запроса.
        /// </param>
        /// <returns>Задача.</returns>
        public static async Task AddAsync(
            ICollection<QueryResult> queryResults,
            Func<Task<QueryResult>> functionToGetQueryResultTask
            )
        {
            var queryResult = await functionToGetQueryResultTask.Invoke();

            queryResults.Add(queryResult);
        }

        /// <summary>
        /// Добавить с выходными данными асинхронно.
        /// </summary>
        /// <typeparam name="TOutput">Тип выходных данных.</typeparam>
        /// <param name="queryResults">Результаты запроса.</param>
        /// <param name="functionToGetQueryResultTask">
        /// Функция для получения задачи на получение результата запроса.
        /// </param>
        /// <param name="actionToSetOutput">Действие по установке выходных данных.</param>
        /// <returns>Задача на получение признака успешной установки выходных данных.</returns>
        public static async Task<bool> AddWithOutputAsync<TOutput>(
            this ICollection<QueryResult> queryResults,
            Func<Task<QueryResultWithOutput<TOutput>>> functionToGetQueryResultTask,
            Action<TOutput> actionToSetOutput
            )
        {
            var queryResult = await functionToGetQueryResultTask.Invoke();

            queryResults.Add(queryResult);

            if (queryResult.IsOk && queryResult.Output != null)
            {
                actionToSetOutput.Invoke(queryResult.Output);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Загрузить.
        /// </summary>
        /// <param name="queryResult">Результат запроса.</param>
        /// <param name="queryResultsToLoad">Результаты запроса для загрузки.</param>
        public static void Load(this QueryResult queryResult, IEnumerable<QueryResult> queryResultsToLoad)
        {
            bool isOk = true;

            foreach (var queryResultToLoad in queryResultsToLoad)
            {
                isOk = isOk && queryResultToLoad.IsOk;

                queryResult.ErrorMessages.UnionWith(queryResultToLoad.ErrorMessages);
                queryResult.SuccessMessages.UnionWith(queryResultToLoad.SuccessMessages);
                queryResult.WarningMessages.UnionWith(queryResultToLoad.WarningMessages);
            }

            queryResult.IsOk = isOk;
        }

        #endregion Public methods
    }
}
