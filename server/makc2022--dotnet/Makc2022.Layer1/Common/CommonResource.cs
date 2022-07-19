// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.Localization;

namespace Makc2022.Layer1.Common
{
    /// <summary>
    /// Общий ресурс.
    /// </summary>
    public class CommonResource : ICommonResource
    {
        #region Properties

        private IStringLocalizer<CommonResource> Localizer { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="localizer">Локализатор.</param>
        public CommonResource(IStringLocalizer<CommonResource> localizer)
        {
            Localizer = localizer;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public string GetErrorMessageForNotImportedTypes(IEnumerable<Type> types)
        {
            return Localizer["@@ErrorMessageForNotImportedTypes", string.Join("', '", types)];
        }

        #endregion Public methods
    }
}
