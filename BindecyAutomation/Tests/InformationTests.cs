using NUnit.Framework;
using static BindecyAutomation.Tests.TestData;

namespace BindecyAutomation.Tests
{
    [TestFixture]
    public class InformationTests : BaseTest
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
        public void WhenFirstNameEmptyRequired_ThenErrorMessageAppear()
        {
            var mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            var cartPage = mainPage.GoToCartPage();
            var checkoutPage = cartPage.Checkout();
            checkoutPage.FillLastName("Moshe Refaeli");
            checkoutPage.FillPostalCode("27000");
            checkoutPage.Continue();
            StringAssert.Contains("First Name is required", checkoutPage.GetErrorMessage());
        }

        [Test]
        public void WhenLastNameEmptyRequired_ThenErrorMessageAppear()
        {
            var mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            var cartPage = mainPage.GoToCartPage();
            var checkoutPage = cartPage.Checkout();
            checkoutPage.FillFirstName("Shahar");
            checkoutPage.FillPostalCode("27000");
            checkoutPage.Continue();
            StringAssert.Contains("Last Name is required", checkoutPage.GetErrorMessage());
        }

        [Test]
        public void WhePostalCodeEmptyRequired_ThenErrorMessageAppear()
        {
            var mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            var cartPage = mainPage.GoToCartPage();
            var checkoutPage = cartPage.Checkout();
            checkoutPage.FillFirstName("Shahar");
            checkoutPage.FillLastName("Moshe Refaeli");
            checkoutPage.Continue();
            StringAssert.Contains("Postal Code is required", checkoutPage.GetErrorMessage());
        }

        [Test]
        public void WheAllFieldsEmptyRequired_ThenErrorMessageAppear()
        {
            var mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            var cartPage = mainPage.GoToCartPage();
            var checkoutPage = cartPage.Checkout();
            checkoutPage.Continue();
            StringAssert.Contains("First Name is required", checkoutPage.GetErrorMessage());
        }
    }
}