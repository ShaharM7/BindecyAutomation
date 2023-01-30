using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BindecyAutomation.Pages
{
    public class CheckoutPage : Page
    {
        private const string FIRST_NAME_INPUT_BOX_BY_DATA_TEST = "//input[@data-test='firstName']";
        private const string LAST_NAME_INPUT_BOX_BY_DATA_TEST = "//input[@data-test='lastName']";
        private const string POSTAL_CODE_INPUT_BOX_BY_DATA_TEST = "//input[@data-test='postalCode']";
        private const string CONTINUE_BUTTON_BY_DATA_TEST = "//input[@data-test='continue']";
        private const string ERROR_MESSAGE_DATA_TEST = "//h3[@data-test='error']";
        private const string INVENTORY_ITEMS_NAME_BY_CLASSNAME = "inventory_item_name";

        private IWebElement? _firstNameInputBox;
        private IWebElement? _lastNameInputBox;
        private IWebElement? _postalCodeInputBox;
        private IWebElement? _continueButton;
        private IWebElement? _errorMessage;

        public CheckoutPage(IWebDriver webDriver, WebDriverWait webDriverWait) : base(webDriver, webDriverWait)
        {
        }

        public void FillFirstName(string firstName)
        {
            InitFirstNameInputBox();
            _firstNameInputBox!.SendKeys(firstName);
        }

        public void FillLastName(string password)
        {
            InitLastNameInputBox();
            _lastNameInputBox!.SendKeys(password);
        }

        public void FillPostalCode(string postalCode)
        {
            InitPostCodeInputBox();
            _postalCodeInputBox!.SendKeys(postalCode);
        }

        public void Continue()
        {
            InitContinueButton();
            _continueButton!.Click();
        }

        public string GetErrorMessage()
        {
            InitErrorMessage();
            return _errorMessage!.Text;
        }

        public IList<string> GetAllItemsName()
        {
            var itemsNameText = new List<string>();

            var itemsName =
                WebDriverWait.Until(VisibilityOfAllElementsLocatedBy(By.ClassName(INVENTORY_ITEMS_NAME_BY_CLASSNAME)));
            foreach (var itemName in itemsName)
            {
                itemsNameText.Add(itemName.Text);
            }

            return itemsNameText;
        }

        private void InitFirstNameInputBox()
        {
            _firstNameInputBox = WebDriverWait.Until(ElementIsVisible(By.XPath(FIRST_NAME_INPUT_BOX_BY_DATA_TEST)));
        }

        private void InitLastNameInputBox()
        {
            _lastNameInputBox = WebDriverWait.Until(ElementIsVisible(By.XPath(LAST_NAME_INPUT_BOX_BY_DATA_TEST)));
        }

        private void InitPostCodeInputBox()
        {
            _postalCodeInputBox = WebDriverWait.Until(ElementIsVisible(By.XPath(POSTAL_CODE_INPUT_BOX_BY_DATA_TEST)));
        }

        private void InitContinueButton()
        {
            _continueButton = WebDriverWait.Until(ElementToBeClickable(By.XPath(CONTINUE_BUTTON_BY_DATA_TEST)));
        }

        private void InitErrorMessage()
        {
            _errorMessage = WebDriverWait.Until(ElementIsVisible(By.XPath(ERROR_MESSAGE_DATA_TEST)));
        }
    }
}