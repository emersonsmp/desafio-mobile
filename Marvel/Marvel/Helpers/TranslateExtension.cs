using Plugin.Multilingual;
using System;
using System.Reflection;
using System.Resources;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace Marvel.Helpers
{
    [ContentProperty("Text")]
    class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "Marvel.Resources.AppResources";

        static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return string.Empty;

            var cultureInfo = CrossMultilingual.Current.CurrentCultureInfo;
            var translationText = resmgr.Value.GetString(Text, cultureInfo);

            if (translationText == null)
                translationText = Text;

            return translationText;
        }

        public static string TranslateText(string key)
        {
            if (key == null)
                return string.Empty;

            var cultureInfo = CrossMultilingual.Current.CurrentCultureInfo;
            var translationText = resmgr.Value.GetString(key, cultureInfo);

            if (translationText == null)
                translationText = string.Empty;

            return translationText;
        }
    }
}
