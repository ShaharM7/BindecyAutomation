using BindecyAutomation.Configuration;
using BindecyAutomation.Pages;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace BindecyAutomation.Navigation
{
    public class PageNavigator
    {
        private readonly IWebDriver _driver;

        private readonly string _baseUrl;
        private readonly string _loginPageRoute;
        private readonly string _mainPageRoute;
        private readonly string _cartPageRoute;

        private readonly LoginPage _loginPage;
        private readonly MainPage _mainPage;
        private readonly CartPage _cartPage;

        public PageNavigator(IWebDriver driver, IOptions<NavigationConfig> navigationConfig, LoginPage loginPage,
            MainPage mainPage, CartPage cartPage)
        {
            _driver = driver;
            _loginPage = loginPage;
            _mainPage = mainPage;
            _cartPage = cartPage;

            _baseUrl = navigationConfig.Value.BaseUrl;
            _loginPageRoute = navigationConfig.Value.LoginPageRoute;
            _mainPageRoute = navigationConfig.Value.MainPageRoute;
            _cartPageRoute = navigationConfig.Value.CartPageRoute;
        }

        public LoginPage NavigateToLoginPage()
        {
            NavigateTo(_baseUrl + _loginPageRoute);
            return _loginPage;
        }

        public MainPage NavigateToMainPage()
        {
            NavigateTo(_baseUrl + _mainPageRoute);
            return _mainPage;
        }

        public CartPage NavigateToCartPage()
        {
            NavigateTo(_baseUrl + _cartPageRoute);
            return _cartPage;
        }

        private void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}