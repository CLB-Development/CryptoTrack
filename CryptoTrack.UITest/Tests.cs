using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CryptoTrack.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
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
        public void ButtonTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Refresh Coin Values"));
            app.Screenshot("CryptoCurrency");

            Assert.IsTrue(results.Any());
        }
    }
}
