﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer2.Sql.Operations.List.Get
{
    /// <summary>
    /// Расширение операции получения списка.
    /// </summary>
    public static class ListGetOperationExtension
    {
        #region Public methods

        /// <summary>
        /// Применить разбиение на страницы.
        /// </summary>
        /// <typeparam name="T">Тип запрашиваемых данных.</typeparam>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Входные данные.</param>
        /// <returns>Запрос страницы.</returns>
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, ListGetOperationInput input)
        {
            return input.PageSize > 0
                ? query.Skip((input.PageNumber - 1) * input.PageSize).Take(input.PageSize)
                : query;
        }

        #endregion Public methods
    }
}
