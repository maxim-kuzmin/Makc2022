// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.DummyMain
{
    /// <summary>
    /// Загрузчик типа "Фиктивное главное".
    /// </summary>
    public class DummyMainTypeLoader : TypeLoader<DummyMainTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public DummyMainTypeLoader(DummyMainTypeEntity? entity = null)
            : base(entity ?? new DummyMainTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            DummyMainTypeEntity entity,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entity, loadableProperties);

            if (result.Contains(nameof(Entity.Id)))
            {
                Entity.Id = entity.Id;
            }

            if (result.Contains(nameof(Entity.IdOfDummyOneToManyEntity)))
            {
                Entity.IdOfDummyOneToManyEntity = entity.IdOfDummyOneToManyEntity;
            }

            if (result.Contains(nameof(Entity.Name)))
            {
                Entity.Name = entity.Name ?? string.Empty;
            }

            if (result.Contains(nameof(Entity.PropBoolean)))
            {
                Entity.PropBoolean = entity.PropBoolean;
            }

            if (result.Contains(nameof(Entity.PropBooleanNullable)))
            {
                Entity.PropBooleanNullable = entity.PropBooleanNullable;
            }

            if (result.Contains(nameof(Entity.PropDate)))
            {
                Entity.PropDate = entity.PropDate;
            }

            if (result.Contains(nameof(Entity.PropDateNullable)))
            {
                Entity.PropDateNullable = entity.PropDateNullable;
            }

            if (result.Contains(nameof(Entity.PropDateTimeOffset)))
            {
                Entity.PropDateTimeOffset = entity.PropDateTimeOffset;
            }

            if (result.Contains(nameof(Entity.PropDateTimeOffsetNullable)))
            {
                Entity.PropDateTimeOffsetNullable = entity.PropDateTimeOffsetNullable;
            }

            if (result.Contains(nameof(Entity.PropDecimal)))
            {
                Entity.PropDecimal = entity.PropDecimal;
            }

            if (result.Contains(nameof(Entity.PropDecimalNullable)))
            {
                Entity.PropDecimalNullable = entity.PropDecimalNullable;
            }

            if (result.Contains(nameof(Entity.PropInt32)))
            {
                Entity.PropInt32 = entity.PropInt32;
            }

            if (result.Contains(nameof(Entity.PropInt32Nullable)))
            {
                Entity.PropInt32Nullable = entity.PropInt32Nullable;
            }

            if (result.Contains(nameof(Entity.PropInt64)))
            {
                Entity.PropInt64 = entity.PropInt64;
            }

            if (result.Contains(nameof(Entity.PropInt64Nullable)))
            {
                Entity.PropInt64Nullable = entity.PropInt64Nullable;
            }

            if (result.Contains(nameof(Entity.PropString)))
            {
                Entity.PropString = entity.PropString ?? string.Empty;
            }

            if (result.Contains(nameof(Entity.PropStringNullable)))
            {
                Entity.PropStringNullable = entity.PropStringNullable;
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
                nameof(Entity.Id),
                nameof(Entity.Name),
                nameof(Entity.IdOfDummyOneToManyEntity),
                nameof(Entity.PropBoolean),
                nameof(Entity.PropBooleanNullable),
                nameof(Entity.PropDate),
                nameof(Entity.PropDateNullable),
                nameof(Entity.PropDateTimeOffset),
                nameof(Entity.PropDateTimeOffsetNullable),
                nameof(Entity.PropDecimal),
                nameof(Entity.PropDecimalNullable),
                nameof(Entity.PropInt32),
                nameof(Entity.PropInt32Nullable),
                nameof(Entity.PropInt64),
                nameof(Entity.PropInt64Nullable),
                nameof(Entity.PropString),
                nameof(Entity.PropStringNullable)
            };
        }

        #endregion Protected methods
    }
}
