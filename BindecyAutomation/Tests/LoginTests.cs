using BindecyAutomation.Pages;
using NUnit.Framework;
using static BindecyAutomation.Tests.TestData;

namespace BindecyAutomation.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        [Test]
        public void WhenLoginWithStandardUser_ThenSuccessfulLogin()
        {
            LoginPage loginPage = PageNavigator!.NavigateToLoginPage();
            loginPage.EnterUserName(STANDARD_USER);
            loginPage.EnterPassword(CORRECT_PASSWORD);
            loginPage.Login();

            StringAssert.AreEqualIgnoringCase("https://www.saucedemo.com/inventory.html", loginPage.GetPageUrl());
        }

        [Test]
        public void WhenLoginWithStandardUser_AndIncorrectPassword_ThenUnsuccessfulLogin()
        {
            LoginPage loginPage = PageNavigator!.NavigateToLoginPage();
            loginPage.EnterUserName(STANDARD_USER);
            loginPage.EnterPassword(INCORRECT_PASSWORD);
            loginPage.Login();

            StringAssert.Contains(" not match any user in this service", loginPage.GetErrorMessage());
        }
    }
}