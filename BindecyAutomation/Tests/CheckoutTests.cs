using System.Collections.Generic;
using NUnit.Framework;
using static BindecyAutomation.Tests.TestData;

namespace BindecyAutomation.Tests
{
    [TestFixture]
    public class CheckoutTests : BaseTest
    {
        [Test]
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenTwoItemsAddedToTheCart_ThenTheyAppearCheckoutPage(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
            var mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            mainPage.AddItemToCart(SauceLabsBikeLight);
            var cartPage = mainPage.GoToCartPage();
            var checkoutPage = cartPage.Checkout();
            checkoutPage.FillFirstName("Shahar");
            checkoutPage.FillLastName("Moshe Refaeli");
            checkoutPage.FillPostalCode("27000");
            checkoutPage.Continue();
            StringAssert.AreEqualIgnoringCase("https://www.saucedemo.com/checkout-step-two.html", checkoutPage.GetPageUrl());
            
            var expectedItems = new List<string> {SauceLabsBackpack, SauceLabsBikeLight};
            CollectionAssert.AreEqual(expectedItems, checkoutPage.GetAllItemsName());
        }
    }
}