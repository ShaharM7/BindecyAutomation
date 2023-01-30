using NUnit.Framework;
using static BindecyAutomation.Tests.TestData;

namespace BindecyAutomation.Tests
{
    [TestFixture]
    public class InformationTests : BaseTest
    {
        [Test]
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenFirstNameEmptyRequired_ThenErrorMessageAppear(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
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
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenLastNameEmptyRequired_ThenErrorMessageAppear(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
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
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhePostalCodeEmptyRequired_ThenErrorMessageAppear(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
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
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WheAllFieldsEmptyRequired_ThenErrorMessageAppear(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
            var mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            var cartPage = mainPage.GoToCartPage();
            var checkoutPage = cartPage.Checkout();
            checkoutPage.Continue();
            StringAssert.Contains("First Name is required", checkoutPage.GetErrorMessage());
        }
    }
}