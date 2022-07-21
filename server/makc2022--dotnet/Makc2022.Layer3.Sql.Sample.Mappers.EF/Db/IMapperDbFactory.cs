// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2022.Layer3.Sql.Sample.Mappers.EF.Db
{
    /// <summary>
    /// Расширение базы данных сопоставителя.
    /// </summary>
    public interface IMapperDbFactory
    {
        #region Methods

        /// <summary>
        /// Создать контекст базы данных.
        /// </summary>
        /// <returns>Контекст базы данных.</returns>
        MapperDbContext CreateDbContext();

        #endregion Methods
    }
}
