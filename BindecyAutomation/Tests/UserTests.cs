using BindecyAutomation.Pages;
using NUnit.Framework;
using static BindecyAutomation.Tests.TestData;

namespace BindecyAutomation.Tests
{
    [TestFixture]
    public class UserTests : BaseTest
    {
        [Test]
        public void WhenLoginWithLockedOut_ThenErrorAppear()
        {
            LoginPage loginPage = PageNavigator!.NavigateToLoginPage();
            loginPage.EnterUserName(LOCKED_OUT_USER);
            loginPage.EnterPassword(CORRECT_PASSWORD);
            loginPage.Login();

            StringAssert.Contains("Epic sadface: Sorry, this user has been locked out", loginPage.GetErrorMessage());
        }
    }
}