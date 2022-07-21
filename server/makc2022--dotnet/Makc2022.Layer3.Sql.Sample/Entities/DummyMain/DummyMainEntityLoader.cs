// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer3.Sql.Sample.Entity;

namespace Makc2022.Layer3.Sql.Sample.Entities.DummyMain
{
    /// <summary>
    /// Загрузчик сущности "DummyMain".
    /// </summary>
    public class DummyMainEntityLoader : EntityLoader<DummyMainEntityObject>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainEntityLoader(DummyMainEntityObject? entityObject = null)
            : base(entityObject ?? new DummyMainEntityObject())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyMainEntityObject entityObject,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entityObject, loadableProperties);

            if (result.Contains(nameof(EntityObject.Id)))
            {
                EntityObject.Id = entityObject.Id;
            }

            if (result.Contains(nameof(EntityObject.IdOfDummyOneToManyEntity)))
            {
                EntityObject.IdOfDummyOneToManyEntity = entityObject.IdOfDummyOneToManyEntity;
            }

            if (result.Contains(nameof(EntityObject.Name)))
            {
                EntityObject.Name = entityObject.Name ?? string.Empty;
            }

            if (result.Contains(nameof(EntityObject.PropBoolean)))
            {
                EntityObject.PropBoolean = entityObject.PropBoolean;
            }

            if (result.Contains(nameof(EntityObject.PropBooleanNullable)))
            {
                EntityObject.PropBooleanNullable = entityObject.PropBooleanNullable;
            }

            if (result.Contains(nameof(EntityObject.PropDate)))
            {
                EntityObject.PropDate = entityObject.PropDate;
            }

            if (result.Contains(nameof(EntityObject.PropDateNullable)))
            {
                EntityObject.PropDateNullable = entityObject.PropDateNullable;
            }

            if (result.Contains(nameof(EntityObject.PropDateTimeOffset)))
            {
                EntityObject.PropDateTimeOffset = entityObject.PropDateTimeOffset;
            }

            if (result.Contains(nameof(EntityObject.PropDateTimeOffsetNullable)))
            {
                EntityObject.PropDateTimeOffsetNullable = entityObject.PropDateTimeOffsetNullable;
            }

            if (result.Contains(nameof(EntityObject.PropDecimal)))
            {
                EntityObject.PropDecimal = entityObject.PropDecimal;
            }

            if (result.Contains(nameof(EntityObject.PropDecimalNullable)))
            {
                EntityObject.PropDecimalNullable = entityObject.PropDecimalNullable;
            }

            if (result.Contains(nameof(EntityObject.PropInt32)))
            {
                EntityObject.PropInt32 = entityObject.PropInt32;
            }

            if (result.Contains(nameof(EntityObject.PropInt32Nullable)))
            {
                EntityObject.PropInt32Nullable = entityObject.PropInt32Nullable;
            }

            if (result.Contains(nameof(EntityObject.PropInt64)))
            {
                EntityObject.PropInt64 = entityObject.PropInt64;
            }

            if (result.Contains(nameof(EntityObject.PropInt64Nullable)))
            {
                EntityObject.PropInt64Nullable = entityObject.PropInt64Nullable;
            }

            if (result.Contains(nameof(EntityObject.PropString)))
            {
                EntityObject.PropString = entityObject.PropString ?? string.Empty;
            }

            if (result.Contains(nameof(EntityObject.PropStringNullable)))
            {
                EntityObject.PropStringNullable = entityObject.PropStringNullable;
            }

            return result;
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected override HashSet<string> CreateAllPropertiesToLoad()
        {
            return new HashSet<string>
            {
                nameof(EntityObject.Id),
                nameof(EntityObject.Name),
                nameof(EntityObject.IdOfDummyOneToManyEntity),
                nameof(EntityObject.PropBoolean),
                nameof(EntityObject.PropBooleanNullable),
                nameof(EntityObject.PropDate),
                nameof(EntityObject.PropDateNullable),
                nameof(EntityObject.PropDateTimeOffset),
                nameof(EntityObject.PropDateTimeOffsetNullable),
                nameof(EntityObject.PropDecimal),
                nameof(EntityObject.PropDecimalNullable),
                nameof(EntityObject.PropInt32),
                nameof(EntityObject.PropInt32Nullable),
                nameof(EntityObject.PropInt64),
                nameof(EntityObject.PropInt64Nullable),
                nameof(EntityObject.PropString),
                nameof(EntityObject.PropStringNullable)
            };
        }

        #endregion Protected methods
    }
}
