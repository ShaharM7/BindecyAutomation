using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace BindecyAutomation.Pages
{
    public class CartPage : Page
    {
        private const string ITEM_CART = "inventory_item_name";
        private const string CART_LIST = "cart_list";
        private const string CHECKOUT_BUTTON_BY_DATA_TEST = "//button[@data-test='checkout']";

        private IWebElement? _firstItemCart;
        private IWebElement? _itemCartButton;
        private IWebElement? _checkoutButton;

        private readonly CheckoutPage _checkoutPage;

        public CartPage(IWebDriver webDriver, WebDriverWait webDriverWait, CheckoutPage checkoutPage) : base(webDriver, webDriverWait)
        {
            _checkoutPage = checkoutPage;
        }

        public string GetFirstItemName()
        {
            InitFirstItemCart();
            return _firstItemCart!.Text;
        }

        public void RemoveItemCart(string itemName)
        {
            InitRemoveItemCartButton(itemName);
            _itemCartButton!.Click();
        }

        public int GetNumberOfItems()
        {
            var cartsList = WebDriverWait.Until(ElementIsVisible(By.ClassName(CART_LIST)));
            try
            {
                return cartsList.FindElements(By.ClassName("cart_item")).Count;
            }
            catch (WebDriverTimeoutException)
            {
                return 0;
            }
        }

        public CheckoutPage Checkout()
        {
            InitCheckoutButton();
            _checkoutButton!.Click();
            return _checkoutPage;
        }

        private void InitFirstItemCart()
        {
            _firstItemCart = WebDriverWait.Until(ElementIsVisible(By.ClassName(ITEM_CART)));
        }

        private void InitRemoveItemCartButton(string itemName)
        {
            var cleanItemName = itemName.ToLower().Replace(" ", "-");
            _itemCartButton = WebDriverWait.Until(ElementToBeClickable(By.XPath($"//button[@data-test='remove-{cleanItemName}']")));
        }

        private void InitCheckoutButton()
        {
            _checkoutButton = WebDriverWait.Until(ElementToBeClickable(By.XPath(CHECKOUT_BUTTON_BY_DATA_TEST)));
        }
    }
}