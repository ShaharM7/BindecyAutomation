using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BindecyAutomation.Pages
{
    public abstract class Page
    {
        private const string MENU_BUTTON_BY_ID = "react-burger-menu-btn";
        private const string RESET_APP_STATE_BUTTON_BY_ID = "reset_sidebar_link";
        private const string LOGOUT_BUTTON_BY_ID = "logout_sidebar_link";

        private IWebElement? _menuButton;
        private IWebElement? _resetAppStateButton;
        private IWebElement? _logoutButton;

        protected IWebDriver WebDriver;
        protected WebDriverWait WebDriverWait;

        public Page(IWebDriver webDriver, WebDriverWait webDriverWait)
        {
            WebDriver = webDriver;
            WebDriverWait = webDriverWait;
        }

        public void OpenMenuOptions()
        {
            InitMenuButton();
            _menuButton!.Click();
        }

        public void ResetAppState()
        {
            OpenMenuOptions();
            InitResetAppStateButton();
            _resetAppStateButton!.Click();
        }

        public void Logout()
        {
            OpenMenuOptions();
            InitLogoutButton();
            _logoutButton!.Click();
        }

        public string GetPageUrl()
        {
            return WebDriver.Url;
        }

        private void InitMenuButton()
        {
            _menuButton = WebDriverWait.Until(ElementToBeClickable(By.Id(MENU_BUTTON_BY_ID)));
        }

        private void InitResetAppStateButton()
        {
            _resetAppStateButton = WebDriverWait.Until(ElementToBeClickable(By.Id(RESET_APP_STATE_BUTTON_BY_ID)));
        }

        private void InitLogoutButton()
        {
            _logoutButton = WebDriverWait.Until(ElementToBeClickable(By.Id(LOGOUT_BUTTON_BY_ID)));
        }
    }
}