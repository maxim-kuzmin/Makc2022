// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Operations.List.Get;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMain;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Types.DummyOneToMany;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get;
using Microsoft.EntityFrameworkCore;
using IMapperDbFactoryForSample = Makc2022.Layer3.Sql.Sample.Mappers.EF.Db.IMapperDbContextFactory;

namespace Makc2022.Layer4.Sql.Domains.DummyMain
{
    /// <summary>
    /// Сервис домена.
    /// </summary>
    public class DomainService : IDomainService
    {
        #region Properties

        private IMapperDbFactoryForSample MapperDbFactoryForSample { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="mapperDbFactoryForSample">Фабрика базы данных сопоставителя для "Sample".</param>
        public DomainService(IMapperDbFactoryForSample mapperDbFactoryForSample)
        {
            MapperDbFactoryForSample = mapperDbFactoryForSample;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task<DomainItemGetOperationOutput?> GetItem(DomainItemGetOperationInput input)
        {
            DomainItemGetOperationOutput? result = null;

            using var dbContext = MapperDbFactoryForSample.CreateDbContext();

            var mapperDummyMain = await dbContext.DummyMain
                .Include(x => x.DummyOneToMany)
                .Include(x => x.DummyMainDummyManyToManyList)
                .ApplyFiltering(input)
                .SingleOrDefaultAsync();

            if (mapperDummyMain != null)
            {
                result = CreateItem(mapperDummyMain);

                if (result.DummyMainDummyManyToManyList != null)
                {
                    long[] mapperDummyManyToManyIds = result.DummyMainDummyManyToManyList
                        .Select(x => x.DummyManyToManyId)
                        .ToArray();

                    if (mapperDummyManyToManyIds.Any())
                    {
                        var enities = await dbContext.DummyManyToMany
                            .Where(x => mapperDummyManyToManyIds.Contains(x.Id))
                            .ToArrayAsync();

                        if (enities.Any())
                        {
                            InitItemDummyManyToMany(result, enities);
                        }
                    }
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<DomainListGetOperationOutput> GetList(DomainListGetOperationInput input)
        {
            var result = new DomainListGetOperationOutput();

            using var dbContext = MapperDbFactoryForSample.CreateDbContext();
            using var dbContextForTotalCount = MapperDbFactoryForSample.CreateDbContext();

            var queryForItems = dbContext.DummyMain
                .Include(x => x.DummyOneToMany)
                .Include(x => x.DummyMainDummyManyToManyList)
                .ApplyFiltering(input)
                .ApplySorting(input)
                .ApplyPagination(input);

            var queryForTotalCount = dbContextForTotalCount.DummyMain
                .ApplyFiltering(input);

            var taskForItems = queryForItems.ToArrayAsync();
            var taskForTotalCount = queryForTotalCount.CountAsync();

            await Task.WhenAll(taskForItems, taskForTotalCount);

            var mapperDummyMainList = taskForItems.Result;

            result.Items = mapperDummyMainList.Select(CreateItem).ToArray();
            result.TotalCount = taskForTotalCount.Result;

            if (mapperDummyMainList.Any())
            {
                long[] mapperDummyManyToManyIds = mapperDummyMainList
                    .SelectMany(x => x.DummyMainDummyManyToManyList)
                    .Select(x => x.DummyManyToManyId)
                    .Distinct()
                    .ToArray();

                if (mapperDummyManyToManyIds.Any())
                {
                    var mapperDummyManyToManyLookup = await dbContext.DummyManyToMany
                        .Where(x => mapperDummyManyToManyIds.Contains(x.Id))
                        .ToDictionaryAsync(x => x.Id);

                    if (mapperDummyManyToManyLookup.Any())
                    {
                        foreach (var item in result.Items)
                        {
                            if (item.DummyMainDummyManyToManyList != null)
                            {
                                InitItemDummyManyToMany(item, mapperDummyManyToManyLookup);
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion Public methods

        #region Private methods

        private static DomainItemGetOperationOutput CreateItem(MapperDummyMainTypeEntity entity)
        {
            var result = new DomainItemGetOperationOutput
            {
                DummyMain = entity.ToEntity(),
                DummyOneToMany = entity.DummyOneToMany!.ToEntity()
            };

            if (entity.DummyMainDummyManyToManyList.Any())
            {
                result.DummyMainDummyManyToManyList = entity.DummyMainDummyManyToManyList
                    .Select(x => x.ToEntity())
                    .ToArray();
            }

            return result;
        }

        private static void InitItemDummyManyToMany(
            DomainItemGetOperationOutput item,
            IEnumerable<MapperDummyManyToManyTypeEntity> enities
            )
        {
            item.DummyManyToManyList = enities
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .Select(x => x.ToEntity())
                .ToArray();
        }

        private static void InitItemDummyManyToMany(
            DomainItemGetOperationOutput item,
            IDictionary<long, MapperDummyManyToManyTypeEntity> lookup
            )
        {
            long[] ids = item.DummyMainDummyManyToManyList!
                .Select(x => x.DummyManyToManyId)
                .ToArray();

            var entities = new List<MapperDummyManyToManyTypeEntity>();

            foreach (long id in ids)
            {
                if (lookup.TryGetValue(id, out MapperDummyManyToManyTypeEntity? entity))
                {
                    entities.Add(entity);
                }
            }

            if (entities.Any())
            {
                InitItemDummyManyToMany(item, entities);
            }
        }

        #endregion Private methods
    }
}
