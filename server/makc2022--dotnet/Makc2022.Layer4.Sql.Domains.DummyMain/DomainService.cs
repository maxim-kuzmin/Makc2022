// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Operations.List.Get;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.Item.Get;
using Makc2022.Layer4.Sql.Domains.DummyMain.Operations.List.Get;
using Microsoft.EntityFrameworkCore;
using IMapperDbFactoryForSample = Makc2022.Layer3.Sql.Sample.Mappers.EF.Db.IMapperDbFactory;

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

            var entityOfDummyMain = await dbContext.DummyMain!
                .Include(x => x.ObjectOfDummyOneToManyEntity)
                .Include(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .ApplyFiltering(input)
                .FirstOrDefaultAsync();

            if (entityOfDummyMain != null)
            {
                result = CreateItem(entityOfDummyMain);

                if (result.ObjectsOfDummyMainDummyManyToManyEntity != null)
                {
                    long[] idsOfDummyManyToMany = result.ObjectsOfDummyMainDummyManyToManyEntity
                        .Select(x => x.IdOfDummyManyToManyEntity)
                        .ToArray();

                    if (idsOfDummyManyToMany.Any())
                    {
                        var enitiesOfDummyManyToMany = await dbContext.DummyManyToMany!
                            .Where(x => idsOfDummyManyToMany.Contains(x.Id))
                            .ToArrayAsync();

                        if (enitiesOfDummyManyToMany.Any())
                        {
                            InitItemDummyManyToMany(result, enitiesOfDummyManyToMany);
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

            var queryOfItems = dbContext.DummyMain!
                .Include(x => x.ObjectOfDummyOneToManyEntity)
                .Include(x => x.ObjectsOfDummyMainDummyManyToManyEntity)
                .ApplyFiltering(input)
                .ApplySorting(input)
                .ApplyPagination(input);

            var queryOfTotalCount = dbContextForTotalCount.DummyMain!
                .ApplyFiltering(input);

            var taskOfItems = queryOfItems.ToArrayAsync();
            var taskOfTotalCount = queryOfTotalCount.CountAsync();

            await Task.WhenAll(taskOfItems, taskOfTotalCount);

            result.Items = taskOfItems.Result.Select(x => CreateItem(x)).ToArray();
            result.TotalCount = taskOfTotalCount.Result;

            if (result.Items.Any())
            {
                long[] idsDummyManyToMany = result.Items
                    .Where(x => x.ObjectsOfDummyMainDummyManyToManyEntity != null)
                    .SelectMany(x => x.ObjectsOfDummyMainDummyManyToManyEntity!)
                    .Select(x => x.IdOfDummyManyToManyEntity)
                    .Distinct()
                    .ToArray();

                if (idsDummyManyToMany.Any())
                {
                    var lookupOfDummyManyToMany = await dbContext.DummyManyToMany!
                        .Where(x => idsDummyManyToMany.Contains(x.Id))
                        .ToDictionaryAsync(x => x.Id);

                    if (lookupOfDummyManyToMany.Any())
                    {
                        foreach (var item in result.Items)
                        {
                            if (item.ObjectsOfDummyMainDummyManyToManyEntity != null)
                            {
                                InitItemDummyManyToMany(item, lookupOfDummyManyToMany);
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion Public methods

        #region Private methods

        private static DomainItemGetOperationOutput CreateItem(MapperDummyMainEntityObject entity)
        {
            var result = new DomainItemGetOperationOutput
            {
                ObjectOfDummyMainEntity = entity.FromMapperToEntityObject(),
                ObjectOfDummyOneToManyEntity = entity.ObjectOfDummyOneToManyEntity!.FromMapperToEntityObject()
            };

            if (entity.ObjectsOfDummyMainDummyManyToManyEntity.Any())
            {
                result.ObjectsOfDummyMainDummyManyToManyEntity = entity.ObjectsOfDummyMainDummyManyToManyEntity
                    .Select(x => x.FromMapperToEntityObject())
                    .ToArray();
            }

            return result;
        }

        private static void InitItemDummyManyToMany(
            DomainItemGetOperationOutput item,
            IEnumerable<MapperDummyManyToManyEntityObject> enities
            )
        {
            item.ObjectsOfDummyManyToManyEntity = enities
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .Select(x => x.FromMapperToEntityObject())
                .ToArray();
        }

        private static void InitItemDummyManyToMany(
            DomainItemGetOperationOutput item,
            IDictionary<long, MapperDummyManyToManyEntityObject> lookup
            )
        {
            long[] ids = item.ObjectsOfDummyMainDummyManyToManyEntity!
                .Select(x => x.IdOfDummyManyToManyEntity)
                .ToArray();

            var entities = new List<MapperDummyManyToManyEntityObject>();

            foreach (long id in ids)
            {
                if (lookup.TryGetValue(id, out MapperDummyManyToManyEntityObject? entity))
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
