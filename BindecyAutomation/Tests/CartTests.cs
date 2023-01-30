using NUnit.Framework;
using static BindecyAutomation.Tests.TestData;

namespace BindecyAutomation.Tests
{
    [TestFixture]
    public class CartTests : BaseTest
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
        public void WhenAddItemToCart_AndRemoveItFromCartPage_ThenCartNotExist()
        {
            var mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            var cartPage = mainPage.GoToCartPage();
            cartPage.RemoveItemCart(SauceLabsBackpack);

            Assert.That(cartPage.GetNumberOfItems(), Is.EqualTo(0));
        }
    }
}