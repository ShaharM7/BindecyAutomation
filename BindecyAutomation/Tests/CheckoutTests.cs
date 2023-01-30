using System.Collections.Generic;
using NUnit.Framework;
using static BindecyAutomation.Tests.TestData;

namespace BindecyAutomation.Tests
{
    [TestFixture]
    public class CheckoutTests : BaseTest
    {
        [SetUp]
        public void LoginToSystem()
        {
            var loginPage = PageNavigator!.NavigateToLoginPage();
            loginPage.EnterUserName(STANDARD_USER);
            loginPage.EnterPassword(CORRECT_PASSWORD);
            loginPage.Login();
        }

        [Test]
        public void WhenLastNameEmptyRequired_ThenErrorMessageAppear()
        {
            var mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            mainPage.AddItemToCart(SauceLabsBikeLight);
            var cartPage = mainPage.GoToCartPage();
            var checkoutPage = cartPage.Checkout();
            checkoutPage.FillFirstName("Shahar");
            checkoutPage.FillLastName("Moshe Refaeli");
            checkoutPage.FillPostalCode("27000");
            checkoutPage.Continue();
            var expectedItems = new List<string> {SauceLabsBackpack, SauceLabsBikeLight};

            CollectionAssert.AreEqual(expectedItems, checkoutPage.GetAllItemsName());
        }
    }
}