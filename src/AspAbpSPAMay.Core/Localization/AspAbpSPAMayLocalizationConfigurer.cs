using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AspAbpSPAMay.Localization
{
    public static class AspAbpSPAMayLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AspAbpSPAMayConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AspAbpSPAMayLocalizationConfigurer).GetAssembly(),
                        "AspAbpSPAMay.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
