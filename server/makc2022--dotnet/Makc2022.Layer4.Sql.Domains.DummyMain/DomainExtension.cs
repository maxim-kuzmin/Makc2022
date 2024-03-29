﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions.VariableExceptions;
using Makc2022.Layer1.Operation;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMain;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get;

namespace Makc2022.Layer4.Sql.Domains.DummyMain
{
    /// <summary>
    /// Расширение домена.
    /// </summary>
    public static class DomainExtension
    {
        #region Public methods

        /// <summary>
        /// Применить. Фильтрацию.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Входные данные.</param>
        /// <returns>Запрос с учётом фильтрации.</returns>
        public static IQueryable<MapperDummyMainTypeEntity> ApplyFiltering(
            this IQueryable<MapperDummyMainTypeEntity> query,
            DomainItemGetOperationInput input
            )
        {
            if (input.Id > 0)
            {
                query = query.Where(x => x.Id == input.Id);
            }

            if (input.Name != null)
            {
                query = query.Where(x => x.Name == input.Name);
            }

            return query;
        }

        /// <summary>
        /// Применить. Фильтрацию.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Входные данные.</param>
        /// <returns>Запрос с учётом фильтрации.</returns>
        public static IQueryable<MapperDummyMainTypeEntity> ApplyFiltering(
            this IQueryable<MapperDummyMainTypeEntity> query,
            DomainListGetOperationInput input
            )
        {
            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                query = query.Where(x => x.Name!.Contains(input.Name));
            }

            if (input.Ids != null && input.Ids.Any())
            {
                if (input.Ids.Length > 1)
                {
                    query = query.Where(x => input.Ids.Contains(x.Id));
                }
                else
                {
                    long entityId = input.Ids[0];

                    query = query.Where(x => x.Id == entityId);
                }
            }

            if (input.DummyOneToManyId > 0)
            {
                query = query.Where(x => x.DummyOneToManyId == input.DummyOneToManyId);
            }

            if (input.DummyOneToManyIds != null && input.DummyOneToManyIds.Any())
            {
                if (input.DummyOneToManyIds.Length > 1)
                {
                    query = query.Where(x => input.DummyOneToManyIds.Contains(x.DummyOneToManyId));
                }
                else
                {
                    long id = input.DummyOneToManyIds[0];

                    query = query.Where(x => x.DummyOneToManyId == id);
                }
            }

            if (!string.IsNullOrWhiteSpace(input.DummyOneToManyName))
            {
                query = query.Where(x => x.DummyOneToMany!.Name!.Contains(input.DummyOneToManyName));
            }

            return query;
        }

        /// <summary>
        /// Применить. Сортировку.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <param name="input">Входные данные.</param>
        /// <returns>Запрос с учётом сортировки.</returns>
        public static IQueryable<MapperDummyMainTypeEntity> ApplySorting(
            this IQueryable<MapperDummyMainTypeEntity> query,
            DomainListGetOperationInput input
            )
        {
            if (string.IsNullOrWhiteSpace(input.SortField))
            {
                throw new NullOrWhiteSpaceStringVariableException(typeof(DomainExtension), nameof(input), nameof(input.SortField));
            }

            string sortField = input.SortField.ToLower();

            if (string.IsNullOrWhiteSpace(input.SortDirection))
            {
                throw new NullOrWhiteSpaceStringVariableException(typeof(DomainExtension), nameof(input), nameof(input.SortDirection));
            }

            string sortDirection = input.SortDirection.ToLower();

            MapperDummyMainTypeEntity obj;

            string sortFieldForId = nameof(obj.Id).ToLower();
            string sortFieldForName = nameof(obj.Name).ToLower();
            string sortFieldForObjectDummyOneToMany = nameof(obj.DummyOneToMany).ToLower();
            string sortFieldForPropDate = nameof(obj.PropDate).ToLower();
            string sortFieldForPropBoolean = nameof(obj.PropBoolean).ToLower();

            if (sortField == sortFieldForId)
            {
                switch (sortDirection)
                {
                    case OperationOptions.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.Id);
                        break;
                    case OperationOptions.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.Id);
                        break;
                }
            }
            else if (sortField == sortFieldForName)
            {
                switch (sortDirection)
                {
                    case OperationOptions.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.Name);
                        break;
                    case OperationOptions.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.Name);
                        break;
                }
            }
            else if (sortField == sortFieldForObjectDummyOneToMany)
            {
                switch (sortDirection)
                {
                    case OperationOptions.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.DummyOneToMany!.Name);
                        break;
                    case OperationOptions.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.DummyOneToMany!.Name);
                        break;
                }
            }
            else if (sortField == sortFieldForPropDate)
            {
                switch (sortDirection)
                {
                    case OperationOptions.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.PropDate);
                        break;
                    case OperationOptions.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.PropDate);
                        break;
                }
            }
            else if (sortField == sortFieldForPropBoolean)
            {
                switch (sortDirection)
                {
                    case OperationOptions.SORT_DIRECTION_ASC:
                        query = query.OrderBy(x => x.PropBoolean);
                        break;
                    case OperationOptions.SORT_DIRECTION_DESC:
                        query = query.OrderByDescending(x => x.PropBoolean);
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(sortField) && sortField != sortFieldForId)
            {
                query = ((IOrderedQueryable<MapperDummyMainTypeEntity>)query).ThenBy(x => x.Id);
            }

            return query;
        }

        #endregion Public methods
    }
}
