// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Types.Role
{
    /// <summary>
    /// Загрузчик типа "Роль".
    /// </summary>
    public class RoleTypeLoader : TypeLoader<RoleTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleTypeLoader(RoleTypeEntity? entity = null)
            : base(entity ?? new RoleTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            RoleTypeEntity entity,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(entity, loadableProperties);

            if (result.Contains(nameof(Entity.ConcurrencyStamp)))
            {
                Entity.ConcurrencyStamp = entity.ConcurrencyStamp;
            }

            if (result.Contains(nameof(Entity.Id)))
            {
                Entity.Id = entity.Id;
            }

            if (result.Contains(nameof(Entity.Name)))
            {
                Entity.Name = entity.Name;
            }

            if (result.Contains(nameof(Entity.NormalizedName)))
            {
                Entity.NormalizedName = entity.NormalizedName;
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
                nameof(Entity.ConcurrencyStamp),
                nameof(Entity.Id),
                nameof(Entity.Name),
                nameof(Entity.NormalizedName)
            };
        }

        #endregion Protected methods
    }
}
