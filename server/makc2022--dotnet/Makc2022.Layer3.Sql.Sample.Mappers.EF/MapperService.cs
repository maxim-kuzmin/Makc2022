// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Exceptions;
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

        private IMapperDbFactory MapperDbFactory { get; }

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
            IMapperDbFactory mapperDbFactory
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

            if (dbContext.DummyMain is null)
            {
                throw new NullVariableException(nameof(dbContext), nameof(dbContext.DummyMain));
            }

            bool isOk = await dbContext.DummyMain.AnyAsync();

            if (!isOk)
            {
                if (dbContext.DummyOneToMany is null)
                {
                    throw new NullVariableException(nameof(dbContext), nameof(dbContext.DummyOneToMany));
                }

                var itemsOfDummyOneToMany = await SeedTestDataForDummyOneToMany(dbContext, dbContext.DummyOneToMany);

                var itemsOfDummyMain = await SeedTestDataForDummyMain(dbContext, dbContext.DummyMain, itemsOfDummyOneToMany);

                if (dbContext.DummyManyToMany is null)
                {
                    throw new NullVariableException(nameof(dbContext), nameof(dbContext.DummyManyToMany));
                }

                var itemsOfDummyManyToMany = await SeedTestDataForDummyManyToMany(dbContext, dbContext.DummyManyToMany);

                await SeedTestDataForDummyMainDummyManyToMany(dbContext, itemsOfDummyMain, itemsOfDummyManyToMany);

                if (dbContext.DummyTree is null)
                {
                    throw new NullVariableException(nameof(dbContext), nameof(dbContext.DummyTree));
                }

                await SeedTestDataForDummyTree(dbContext, dbContext.DummyTree);
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
            DummyTreeLinkEntityOptions? linkSettings,
            DummyTreeEntityOptions? treeSettings
            )
        {
            if (linkSettings is null)
            {
                throw new ArgumentNullException(nameof(linkSettings));
            }

            if (treeSettings is null)
            {
                throw new ArgumentNullException(nameof(treeSettings));
            }

            builder.LinkTableFieldNameForId = linkSettings.DbColumnForId;
            builder.LinkTableFieldNameForParentId = linkSettings.DbColumnForDummyTreeEntityParentId;

            builder.LinkTableNameWithoutSchema = linkSettings.DbTable;
            builder.LinkTableSchema = linkSettings.DbSchema;

            builder.TreeTableFieldNameForId = treeSettings.DbColumnForId;
            builder.TreeTableFieldNameForParentId = treeSettings.DbColumnForDummyTreeEntityParentId;
            builder.TreeTableFieldNameForTreeChildCount = treeSettings.DbColumnForTreeChildCount;
            builder.TreeTableFieldNameForTreeDescendantCount = treeSettings.DbColumnForTreeDescendantCount;
            builder.TreeTableFieldNameForTreeLevel = treeSettings.DbColumnForTreeLevel;
            builder.TreeTableFieldNameForTreePath = treeSettings.DbColumnForTreePath;
            builder.TreeTableFieldNameForTreePosition = treeSettings.DbColumnForTreePosition;
            builder.TreeTableFieldNameForTreeSort = treeSettings.DbColumnForTreeSort;

            builder.TreeTableNameWithoutSchema = treeSettings.DbTable;
            builder.TreeTableSchema = treeSettings.DbSchema;
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
            DbSet<MapperDummyTreeEntityObject> setOfDummyTree,
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

                setOfDummyTree.Add(item);

                await dbContext.SaveChangesAsync();

                await SaveTestDataListForDummyTree(dbContext, setOfDummyTree, list, indexes, item.Id);

                indexes.RemoveAt(indexes.Count - 1);
            }
        }

        private static async Task<IEnumerable<MapperDummyMainEntityObject>> SeedTestDataForDummyMain(
            MapperDbContext dbContext,
            DbSet<MapperDummyMainEntityObject> setOfDummyMain,
            IEnumerable<MapperDummyOneToManyEntityObject> itemsOfDummyOneToMany
            )
        {
            var result = Enumerable.Range(1, 100)
                .Select(index => CreateTestDataItemForDummyMain(index, itemsOfDummyOneToMany))
                .ToArray();

            setOfDummyMain.AddRange(result);

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
            MapperDbContext dbContext,
            DbSet<MapperDummyManyToManyEntityObject> setOfDummyManyToMany
            )
        {
            var result = Enumerable.Range(1, 10)
                .Select(index => CreateTestDataItemForDummyManyToMany(index))
                .ToArray();

            setOfDummyManyToMany.AddRange(result);

            await dbContext.SaveChangesAsync();

            return result;
        }

        private static async Task<IEnumerable<MapperDummyOneToManyEntityObject>> SeedTestDataForDummyOneToMany(
            MapperDbContext dbContext,
            DbSet<MapperDummyOneToManyEntityObject> setOfDummyOneToMany
            )
        {
            var result = Enumerable.Range(1, 10)
                .Select(index => CreateTestDataItemForDummyOneToMany(index))
                .ToArray();

            setOfDummyOneToMany.AddRange(result);

            await dbContext.SaveChangesAsync();

            return result;
        }

        private async Task<IEnumerable<MapperDummyTreeEntityObject>> SeedTestDataForDummyTree(
            MapperDbContext dbContext,
            DbSet<MapperDummyTreeEntityObject> setOfDummyTree
            )
        {
            var result = new List<MapperDummyTreeEntityObject>();

            await SaveTestDataListForDummyTree(dbContext, setOfDummyTree, result, new List<int>(), null);

            var queryTreeTriggerBuilder = CreateQueryTreeTriggerBuilder(TriggerCommandAction.None);

            string sql = queryTreeTriggerBuilder.GetResultSql();

            await dbContext.Database.ExecuteSqlRawAsync(sql);

            return result;
        }

        #endregion Private methods
    }
}
