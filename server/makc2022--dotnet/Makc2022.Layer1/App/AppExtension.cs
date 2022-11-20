// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Makc2022.Layer1.App
{
    /// <summary>
    /// Расширение приложения.
    /// </summary>
    public static class AppExtension
    {
        #region Public methods

        /// <summary>
        /// Добавить модули приложения.
        /// </summary>
        /// <param name="services">Сервисы.</param>
        /// <param name="appModules">Модули приложения.</param>
        public static void AddAppModules(this IServiceCollection services, IEnumerable<AppModule> appModules)
        {
            var exports = Enumerable.Empty<Type>();

            foreach (var module in appModules)
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

            foreach (var module in appModules)
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

            foreach (var module in appModules)
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

            var options = Options.Create(localizationOptions);

            var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);

            var localizer = new StringLocalizer<AppResource>(factory);

            var resource = new AppResource(localizer);

            throw new Exception(resource.GetErrorMessageForNotImportedTypes(types));
        }

        #endregion Private methods
    }
}
