using System;
using BindecyAutomation.Pages;
using NUnit.Framework;
using static BindecyAutomation.Tests.TestData;

namespace BindecyAutomation.Tests
{
    [TestFixture]
    public class MainTests : BaseTest
    {
        [Test]
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenAddItem_ThenCartBadgeWasUpdatedWithTheRightNumberOfItems(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            StringAssert.AreEqualIgnoringCase("1", mainPage.GetNumberOfItemsInShoppingCard());
        }

        [Test]
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenAddItem_AndThenRemoveIt_ThenCartBadgeWasUpdatedWithTheRightNumberOfItems(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            mainPage.RemoveItemToCart(SauceLabsBackpack);
            StringAssert.AreEqualIgnoringCase(String.Empty, mainPage.GetNumberOfItemsInShoppingCard());
        }

        [Test]
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenAddTheCheapest_AndTheMostExpensiveItem_ThenTheCartBadgeHasTwoItems(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.SortBy(PriceLowToHigh);
            mainPage.AddFirstItem();
            mainPage.SortBy(PriceHighToLow);
            mainPage.AddFirstItem();
            StringAssert.AreEqualIgnoringCase("2", mainPage.GetNumberOfItemsInShoppingCard());
        }

        [Test]
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenAddAllItemsStartIWithTheWordsSauceLabs_ThenTheCartBadgeHasFiveItems(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItems(SauceLabsItems);
            StringAssert.AreEqualIgnoringCase("5", mainPage.GetNumberOfItemsInShoppingCard());
        }

        [Test]
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenAddItem_ThenItemShowsAtTheCheckoutPage(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            CartPage cartPage = mainPage.GoToCartPage();
            StringAssert.AreEqualIgnoringCase(SauceLabsBackpack, cartPage.GetFirstItemName());
        }

        [Test]
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenResetAppState_ThenShoppingCartReset(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            mainPage.ResetAppState();
            StringAssert.AreEqualIgnoringCase(String.Empty, mainPage.GetNumberOfItemsInShoppingCard());
        }

        [Test]
        [TestCase(STANDARD_USER)]
        [TestCase(PROBLEM_USER)]
        [TestCase(PERFORMANCE_GLITCH_USER)]
        public void WhenLogout_ThenGoToLoginPage(string userName)
        {
            LoginSteps?.LoginToSystem(userName, CORRECT_PASSWORD);
            
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            mainPage.Logout();

            StringAssert.AreEqualIgnoringCase("https://www.saucedemo.com/",
                mainPage.GetPageUrl());
        }
    }
}