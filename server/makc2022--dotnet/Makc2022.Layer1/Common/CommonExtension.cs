// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using OptionsFactory = Microsoft.Extensions.Options.Options;

namespace Makc2022.Layer1.Common
{
    /// <summary>
    /// Общее расширение.
    /// </summary>
    public static class CommonExtension
    {
        #region Public methods

        /// <summary>
        /// Добавить модули приложения.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="modules">Модули.</param>
        public static void AddAppModules(this IServiceCollection services, IEnumerable<CommonModule> modules)
        {
            var exports = Enumerable.Empty<Type>();

            foreach (var module in modules)
            {
                exports = exports.Union(module.GetExports());

                var dependencies = module.GetDependencies();

                foreach (var dependency in dependencies)
                {
                    exports = exports.Union(dependency.GetExports());
                }
            }

            var allExports = exports.ToHashSet();

            var notImportedTypes = Enumerable.Empty<Type>();

            foreach (var module in modules)
            {
                var notImportedtTypesOfModule = module.GetNotImportedtTypes(allExports);

                if (notImportedtTypesOfModule.Any())
                {
                    notImportedTypes = notImportedTypes.Union(notImportedtTypesOfModule);
                }
            }

            if (notImportedTypes.Any())
            {
                ThrowExceptionForNotImportedTypes(notImportedTypes);
            }

            foreach (var module in modules)
            {
                module.ConfigureServices(services);
            }
        }

        /// <summary>
        /// Настроить опции локализации.
        /// </summary>
        /// <param name="options">Опции.</param>
        public static void ConfigureLocalization(this LocalizationOptions options)
        {
            options.ResourcesPath = "ResourceFiles";
        }

        #endregion Public methods

        #region Private methods

        private static void ThrowExceptionForNotImportedTypes(IEnumerable<Type> types)
        {
            var localizationOptions = new LocalizationOptions();

            localizationOptions.ConfigureLocalization();

            var options = OptionsFactory.Create(localizationOptions);

            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);

            var localizer = new StringLocalizer<CommonResource>(factory);

            var resource = new CommonResource(localizer);

            throw new Exception(resource.GetErrorMessageForNotImportedTypes(types));
        }

        #endregion Private methods
    }
}
