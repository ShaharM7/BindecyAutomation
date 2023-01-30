using NUnit.Framework;
using static BindecyAutomation.Tests.TestData;

namespace BindecyAutomation.Tests
{
    [TestFixture]
    public class CartTests : BaseTest
    {
        [Test]
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenAddItemToCart_AndRemoveItFromCartPage_ThenCartNotExist(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);

            var mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            var cartPage = mainPage.GoToCartPage();
            cartPage.RemoveItemCart(SauceLabsBackpack);

            Assert.That(cartPage.GetNumberOfItems(), Is.EqualTo(0));
        }
    }
}