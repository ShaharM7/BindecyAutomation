using System;
using BindecyAutomation.Pages;
using NUnit.Framework;
using static BindecyAutomation.Tests.TestData;

namespace BindecyAutomation.Tests
{
    [TestFixture]
    public class MainTests : BaseTest
    {
        [SetUp]
        public void LoginToSystem()
        {
            LoginPage loginPage = PageNavigator!.NavigateToLoginPage();
            loginPage.EnterUserName(STANDARD_USER);
            loginPage.EnterPassword(CORRECT_PASSWORD);
            loginPage.Login();
        }

        [Test]
        public void WhenAddItem_ThenCartBadgeWasUpdatedWithTheRightNumberOfItems()
        {
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            StringAssert.AreEqualIgnoringCase("1", mainPage.GetNumberOfItemsInShoppingCard());
        }

        [Test]
        public void WhenAddItem_AndThenRemoveIt_ThenCartBadgeWasUpdatedWithTheRightNumberOfItems()
        {
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            mainPage.RemoveItemToCart(SauceLabsBackpack);
            StringAssert.AreEqualIgnoringCase(String.Empty, mainPage.GetNumberOfItemsInShoppingCard());
        }

        [Test]
        public void WhenAddTheCheapest_AndTheMostExpensiveItem_ThenTheCartBadgeHasTwoItems()
        {
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.SortBy(PriceLowToHigh);
            mainPage.AddFirstItem();
            mainPage.SortBy(PriceHighToLow);
            mainPage.AddFirstItem();
            StringAssert.AreEqualIgnoringCase("2", mainPage.GetNumberOfItemsInShoppingCard());
        }

        [Test]
        public void WhenAddAllItemsStartIWithTheWordsSauceLabs_ThenTheCartBadgeHasFiveItems()
        {
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItems(SauceLabsItems);
            StringAssert.AreEqualIgnoringCase("5", mainPage.GetNumberOfItemsInShoppingCard());
        }

        [Test]
        public void WhenAddItem_ThenItemShowsAtTheCheckoutPage()
        {
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            CartPage cartPage = mainPage.GoToCartPage();
            StringAssert.AreEqualIgnoringCase(SauceLabsBackpack, cartPage.GetFirstItemName());
        }

        [Test]
        public void WhenResetAppState_ThenShoppingCartReset()
        {
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            mainPage.ResetAppState();
            StringAssert.AreEqualIgnoringCase(String.Empty, mainPage.GetNumberOfItemsInShoppingCard());
        }

        [Test]
        public void WhenLogout_ThenGoToLoginPage()
        {
            MainPage mainPage = PageNavigator!.NavigateToMainPage();
            mainPage.AddItemToCart(SauceLabsBackpack);
            mainPage.Logout();

            StringAssert.AreEqualIgnoringCase("https://www.saucedemo.com/",
                mainPage.GetPageUrl());
        }
    }
}