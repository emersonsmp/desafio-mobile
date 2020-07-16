using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MarvelUITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            //AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            //app.Screenshot("Welcome screen.");
            app.EnterText("SearchBar", "3D");
            app.Screenshot("BUsca < 3 char");
            app.ClearText("SearchBar");

            app.EnterText("SearchBar", "3-D Man");
            app.Screenshot("BUsca Correta");
            app.ClearText("SearchBar");

            app.EnterText("SearchBar", "xxxxxxxx");
            app.Screenshot("BUsca Not Found");
        }
    }
}
