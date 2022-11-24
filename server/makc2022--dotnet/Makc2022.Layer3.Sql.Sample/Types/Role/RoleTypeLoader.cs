// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1;

namespace Makc2022.Layer3.Sql.Sample.Types.Role
{
    /// <summary>
    /// Загрузчик типа "Роль".
    /// </summary>
    public class RoleTypeLoader : Loader<RoleTypeEntity>
    {
        #region Constructors

        /// <inheritdoc/>
        public RoleTypeLoader(RoleTypeEntity? target = null)
            : base(target ?? new RoleTypeEntity())
        {
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public sealed override HashSet<string> Load(
            RoleTypeEntity source,
            HashSet<string>? loadableProperties = null)
        {
            var result = base.Load(source, loadableProperties);

            if (result.Contains(nameof(Target.ConcurrencyStamp)))
            {
                Target.ConcurrencyStamp = source.ConcurrencyStamp;
            }

            if (result.Contains(nameof(Target.Id)))
            {
                Target.Id = source.Id;
            }

            if (result.Contains(nameof(Target.Name)))
            {
                Target.Name = source.Name;
            }

            if (result.Contains(nameof(Target.NormalizedName)))
            {
                Target.NormalizedName = source.NormalizedName;
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
                nameof(Target.ConcurrencyStamp),
                nameof(Target.Id),
                nameof(Target.Name),
                nameof(Target.NormalizedName)
            };
        }

        #endregion Protected methods
    }
}
