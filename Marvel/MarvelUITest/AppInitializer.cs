using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MarvelUITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                     .Android
                     .EnableLocalScreenshots()
                     .ApkFile(@"C:/desafio-mobile/Marvel/Marvel.Android/bin/Release/com.companyname.marvel-Signed.apk")
                     .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}