// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer2.Sql.Commands.Tree.Trigger;
using Makc2022.Layer2.Sql.Commands.Trigger;
using Makc2022.Layer2.Sql.Common;
using Makc2022.Layer3.Sql.Sample.Entities;
using Makc2022.Layer3.Sql.Sample.Entities.DummyTree;
using Makc2022.Layer3.Sql.Sample.Entities.DummyTreeLink;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Db;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany;
using Makc2022.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree;
using Microsoft.EntityFrameworkCore;

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF
{
    /// <summary>
    /// Сервис сопоставителя.
    /// </summary>
    public class MapperService : IMapperService
    {
        #region Properties

        private ICommonProvider ClientProvider { get; }

        private EntitiesOptions EntitiesOptions { get; }

        private IMapperDbContextFactory MapperDbFactory { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>        
        /// <param name="сlientProvider">Поставщик клиента.</param>
        /// <param name="entitiesOptions">Параметры сущностей.</param>        
        /// <param name="mapperDbFactory">Фабрика базы данных сопоставителя.</param>
        public MapperService(            
            ICommonProvider сlientProvider,
            EntitiesOptions entitiesOptions,
            IMapperDbContextFactory mapperDbFactory
            )
        {
            ClientProvider = сlientProvider;
            EntitiesOptions = entitiesOptions;
            MapperDbFactory = mapperDbFactory;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public async Task MigrateDatabase()
        {
            using var dbContext = MapperDbFactory.CreateDbContext();

            await dbContext.Database.MigrateAsync();
        }

        /// <inheritdoc/>
        public async Task SeedTestData()
        {
            using var dbContext = MapperDbFactory.CreateDbContext();

            using var transaction = await dbContext.Database.BeginTransactionAsync();

            bool isOk = await dbContext.DummyMain!.AnyAsync();

            if (!isOk)
            {
                var itemsOfDummyOneToMany = await SeedTestDataForDummyOneToMany(dbContext);

                var itemsOfDummyMain = await SeedTestDataForDummyMain(dbContext, itemsOfDummyOneToMany);

                var itemsOfDummyManyToMany = await SeedTestDataForDummyManyToMany(dbContext);

                await SeedTestDataForDummyMainDummyManyToMany(dbContext, itemsOfDummyMain, itemsOfDummyManyToMany);

                await SeedTestDataForDummyTree(dbContext);
            }

            await transaction.CommitAsync();
        }

        #endregion Public methods

        #region Private methods

        private TreeTriggerCommandBuilder CreateQueryTreeTriggerBuilder(
            TriggerCommandAction action
            )
        {
            var result = ClientProvider.CreateQueryTreeTriggerBuilder();

            result.Action = action;

            InitQueryBuilder(result, EntitiesOptions.DummyTreeLink, EntitiesOptions.DummyTree);

            return result;
        }

        private static void InitQueryBuilder(
            TreeTriggerCommandBuilder builder,
            DummyTreeLinkEntityOptions? linkOptions,
            DummyTreeEntityOptions? treeOptions
            )
        {
            if (linkOptions is null)
            {
                throw new ArgumentNullException(nameof(linkOptions));
            }

            if (treeOptions is null)
            {
                throw new ArgumentNullException(nameof(treeOptions));
            }

            builder.LinkTableFieldNameForId = linkOptions.DbColumnForId;
            builder.LinkTableFieldNameForParentId = linkOptions.DbColumnForDummyTreeEntityParentId;

            builder.LinkTableNameWithoutSchema = linkOptions.DbTable;
            builder.LinkTableSchema = linkOptions.DbSchema;

            builder.TreeTableFieldNameForId = treeOptions.DbColumnForId;
            builder.TreeTableFieldNameForParentId = treeOptions.DbColumnForDummyTreeEntityParentId;
            builder.TreeTableFieldNameForTreeChildCount = treeOptions.DbColumnForTreeChildCount;
            builder.TreeTableFieldNameForTreeDescendantCount = treeOptions.DbColumnForTreeDescendantCount;
            builder.TreeTableFieldNameForTreeLevel = treeOptions.DbColumnForTreeLevel;
            builder.TreeTableFieldNameForTreePath = treeOptions.DbColumnForTreePath;
            builder.TreeTableFieldNameForTreePosition = treeOptions.DbColumnForTreePosition;
            builder.TreeTableFieldNameForTreeSort = treeOptions.DbColumnForTreeSort;

            builder.TreeTableNameWithoutSchema = treeOptions.DbTable;
            builder.TreeTableSchema = treeOptions.DbSchema;
        }

        private static MapperDummyMainEntityObject CreateTestDataItemForDummyMain(
            long index,
            IEnumerable<MapperDummyOneToManyEntityObject> itemsOfDummyOneToMany
            )
        {
            bool isEven = index % 2 == 0;

            int day = isEven ? 2 : 1;

            var localTime = new DateTime(2018, 03, day, 06, 32, 00);

            var dateAndOffsetLocal = new DateTimeOffset(
                localTime,
                TimeZoneInfo.Local.GetUtcOffset(localTime)
                );

            int indexOfDummyOneToMany = GetRandomIndex(itemsOfDummyOneToMany);

            return new MapperDummyMainEntityObject
            {
                Name = $"Name-{index}",
                IdOfDummyOneToManyEntity = itemsOfDummyOneToMany.ElementAt(indexOfDummyOneToMany).Id,
                PropBoolean = isEven,
                PropBooleanNullable = isEven ? new bool?(!isEven) : null,
                PropDate = new DateTime(2018, 01, day),
                PropDateNullable = isEven ? new DateTime?(new DateTime(2018, 02, day)) : null,
                PropDateTimeOffset = dateAndOffsetLocal,
                PropDateTimeOffsetNullable = isEven ? new DateTimeOffset?(dateAndOffsetLocal) : null,
                PropDecimal = 1000M + index + (index / 100M),
                PropDecimalNullable = isEven ? new decimal?(2000M + index + (index / 200M)) : null,
                PropInt32 = 1000 + (int)index,
                PropInt32Nullable = isEven ? new int?(1000 + (int)index) : null,
                PropInt64 = 3000 + index,
                PropInt64Nullable = isEven ? new long?(3000 + index) : null,
                PropString = $"PropString-{index}",
                PropStringNullable = isEven ? $"PropStringNullable-{index}" : null
            };
        }

        private static List<MapperDummyMainDummyManyToManyEntityObject> CreateTestDataItemsForDummyMainDummyManyToMany(
            MapperDummyMainEntityObject itemOfDummyMain,
            IEnumerable<MapperDummyManyToManyEntityObject> itemsOfDummyManyToMany
            )
        {
            var result = new List<MapperDummyMainDummyManyToManyEntityObject>();

            foreach (var itemOfDummyManyToMany in itemsOfDummyManyToMany)
            {
                bool isEven = GetRandomIndex(itemsOfDummyManyToMany) % 2 == 0;

                if (isEven) continue;

                var item = new MapperDummyMainDummyManyToManyEntityObject
                {
                    IdOfDummyMainEntity = itemOfDummyMain.Id,
                    IdOfDummyManyToManyEntity = itemOfDummyManyToMany.Id
                };

                result.Add(item);
            }

            if (!result.Any())
            {
                int index = GetRandomIndex(itemsOfDummyManyToMany);

                var item = new MapperDummyMainDummyManyToManyEntityObject
                {
                    IdOfDummyMainEntity = itemOfDummyMain.Id,
                    IdOfDummyManyToManyEntity = itemsOfDummyManyToMany.ElementAt(index).Id
                };

                result.Add(item);
            }

            return result;
        }

        private static MapperDummyManyToManyEntityObject CreateTestDataItemForDummyManyToMany(long index)
        {
            return new MapperDummyManyToManyEntityObject
            {
                Name = $"Name-{index}"
            };
        }

        private static MapperDummyOneToManyEntityObject CreateTestDataItemForDummyOneToMany(long index)
        {
            return new MapperDummyOneToManyEntityObject
            {
                Name = $"Name-{index}"
            };
        }

        private static MapperDummyTreeEntityObject CreateTestDataItemForDummyTree(IEnumerable<int> indexes, long? parentId)
        {
            string suffix = indexes.Any() ? "-" + string.Join("-", indexes) : string.Empty;

            return new MapperDummyTreeEntityObject
            {
                Name = $"Name{suffix}",
                ParentId = parentId
            };
        }

        private static int GetRandomIndex<T>(IEnumerable<T> items)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(0, items.Count());
        }

        private async Task SaveTestDataListForDummyTree(
            MapperDbContext dbContext,
            List<MapperDummyTreeEntityObject> list,
            List<int> parentIndexes,
            long? parentId
            )
        {
            if (parentIndexes.Count == 5)
            {
                return;
            }

            var indexes = new List<int>();

            if (parentIndexes.Any())
            {
                indexes.AddRange(parentIndexes);
            }

            for (int index = 1; index < 4; index++)
            {
                indexes.Add(index);

                var item = CreateTestDataItemForDummyTree(indexes, parentId);

                list.Add(item);

                dbContext.DummyTree!.Add(item);

                await dbContext.SaveChangesAsync();

                await SaveTestDataListForDummyTree(dbContext, list, indexes, item.Id);

                indexes.RemoveAt(indexes.Count - 1);
            }
        }

        private static async Task<IEnumerable<MapperDummyMainEntityObject>> SeedTestDataForDummyMain(
            MapperDbContext dbContext,
            IEnumerable<MapperDummyOneToManyEntityObject> itemsOfDummyOneToMany
            )
        {
            var result = Enumerable.Range(1, 100)
                .Select(index => CreateTestDataItemForDummyMain(index, itemsOfDummyOneToMany))
                .ToArray();

            dbContext.DummyMain!.AddRange(result);

            await dbContext.SaveChangesAsync();

            return result;
        }

        private static async Task<IEnumerable<MapperDummyMainDummyManyToManyEntityObject>> SeedTestDataForDummyMainDummyManyToMany(
            MapperDbContext dbContext,
            IEnumerable<MapperDummyMainEntityObject> itemsOfDummyMain,
            IEnumerable<MapperDummyManyToManyEntityObject> itemsOfDummyManyToMany
            )
        {
            var result = new List<MapperDummyMainDummyManyToManyEntityObject>();

            foreach (var itemOfDummyMain in itemsOfDummyMain)
            {
                var itemsOfDummyMainDummyManyToMany = CreateTestDataItemsForDummyMainDummyManyToMany(
                    itemOfDummyMain,
                    itemsOfDummyManyToMany
                    );

                if (itemsOfDummyMainDummyManyToMany.Any())
                {
                    result.AddRange(itemsOfDummyMainDummyManyToMany);
                }
            }

            dbContext.AddRange(result);

            await dbContext.SaveChangesAsync();

            return result;
        }

        private static async Task<IEnumerable<MapperDummyManyToManyEntityObject>> SeedTestDataForDummyManyToMany(
            MapperDbContext dbContext
            )
        {
            var result = Enumerable.Range(1, 10)
                .Select(index => CreateTestDataItemForDummyManyToMany(index))
                .ToArray();

            dbContext.DummyManyToMany!.AddRange(result);

            await dbContext.SaveChangesAsync();

            return result;
        }

        private static async Task<IEnumerable<MapperDummyOneToManyEntityObject>> SeedTestDataForDummyOneToMany(
            MapperDbContext dbContext)
        {
            var result = Enumerable.Range(1, 10)
                .Select(index => CreateTestDataItemForDummyOneToMany(index))
                .ToArray();

            dbContext.DummyOneToMany!.AddRange(result);

            await dbContext.SaveChangesAsync();

            return result;
        }

        private async Task<IEnumerable<MapperDummyTreeEntityObject>> SeedTestDataForDummyTree(
            MapperDbContext dbContext
            )
        {
            var result = new List<MapperDummyTreeEntityObject>();

            await SaveTestDataListForDummyTree(dbContext, result, new List<int>(), null);

            var queryTreeTriggerBuilder = CreateQueryTreeTriggerBuilder(TriggerCommandAction.None);

            string sql = queryTreeTriggerBuilder.GetResultSql();

            await dbContext.Database.ExecuteSqlRawAsync(sql);

            return result;
        }

        #endregion Private methods
    }
}
