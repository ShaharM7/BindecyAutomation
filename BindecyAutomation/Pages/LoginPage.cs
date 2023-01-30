using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BindecyAutomation.Pages
{
    public class LoginPage : Page
    {
        private const string USER_NAME_ID_SELECTOR = "user-name";
        private const string PASSWORD_ID_SELECTOR = "password";
        private const string LOGIN_ID_SELECTOR = "login-button";
        private const string ERROR_MESSAGE_SELECTOR_CLASSNAME = "error-message-container";

        private IWebElement? _userNameInputBox;
        private IWebElement? _passwordInputBox;
        private IWebElement? _loginButton;
        private IWebElement? _errorMessage;

        private readonly MainPage _mainPage;

        public LoginPage(IWebDriver webDriver, WebDriverWait webDriverWait, MainPage mainPage)
            : base(webDriver, webDriverWait)
        {
            _mainPage = mainPage;
        }

        public void EnterUserName(string userName)
        {
            InitUserNameInputBox();
            _userNameInputBox!.SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            InitPasswordInputBox();
            _passwordInputBox!.SendKeys(password);
        }

        public MainPage Login()
        {
            InitLoginButton();
            _loginButton!.Click();
            return _mainPage;
        }

        public string GetErrorMessage()
        {
            InitErrorMessage();
            return _errorMessage!.Text;
        }

        private void InitUserNameInputBox()
        {
            _userNameInputBox = WebDriverWait.Until(ElementIsVisible(By.Id(USER_NAME_ID_SELECTOR)));
        }

        private void InitPasswordInputBox()
        {
            _passwordInputBox = WebDriverWait.Until(ElementIsVisible(By.Id(PASSWORD_ID_SELECTOR)));
        }

        private void InitLoginButton()
        {
            _loginButton = WebDriverWait.Until(ElementToBeClickable(By.Id(LOGIN_ID_SELECTOR)));
        }

        private void InitErrorMessage()
        {
            _errorMessage = WebDriverWait.Until(ElementIsVisible(By.ClassName(ERROR_MESSAGE_SELECTOR_CLASSNAME)));
        }
    }
}