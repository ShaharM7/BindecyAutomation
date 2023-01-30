using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace BindecyAutomation.Pages
{
    public class MainPage : Page
    {
        private const string SHOPPING_CART_BUTTON_CLASSNAME = "shopping_cart_container";
        private const string SORT_OPTIONS_BY_DATA_TEST = "//select[@data-test='product_sort_container']";
        
        private IWebElement? _shoppingCartButton;
        private SelectElement? _sortOptions;
        private IWebElement? _itemCartButton;
        
        private readonly CartPage? _cartPage;

        public MainPage(IWebDriver webDriver, WebDriverWait webDriverWait, CartPage? cartPage) : base(webDriver, webDriverWait)
        {
            _cartPage = cartPage;
        }

        public string GetNumberOfItemsInShoppingCard()
        {
            InitShoppingCartButton();
            return _shoppingCartButton!.Text;
        }

        public void SortBy(string sortOption)
        {
            InitSortOptions();
            _sortOptions!.SelectByText(sortOption);
        }

        public void AddItemToCart(string itemName)
        {
            InitAddItemCartButton(itemName);
            _itemCartButton!.Click();
        }

        public void RemoveItemToCart(string itemName)
        {
            InitRemoveItemCartButton(itemName);
            _itemCartButton!.Click();
        }

        public void AddFirstItem()
        {
            WebDriverWait.Until(ElementIsVisible(By.ClassName("inventory_item"))).FindElement(By.TagName("button")).Click();
        }

        public void AddItems(string itemsContainsName)
        {
            var itemsSharedName = itemsContainsName.ToLower().Replace(" ", "-");
            var itemsButton =
                WebDriverWait.Until(
                    VisibilityOfAllElementsLocatedBy(By.XPath($"//button[contains(@data-test, 'add-to-cart-{itemsSharedName}')]")));

            foreach (var itemButton in itemsButton)
            {
                itemButton.Click();
            }
        }

        public CartPage GoToCartPage()
        {
            InitShoppingCartButton();
            _shoppingCartButton = WebDriverWait.Until(ElementToBeClickable(By.ClassName(SHOPPING_CART_BUTTON_CLASSNAME)));
            _shoppingCartButton!.Click();
            return _cartPage!;
        }

        private void InitShoppingCartButton()
        {
            _shoppingCartButton = WebDriverWait.Until(ElementIsVisible(By.Id(SHOPPING_CART_BUTTON_CLASSNAME)));
        }

        private void InitSortOptions()
        {
            _sortOptions = new SelectElement(WebDriverWait.Until(ElementToBeClickable(By.XPath(SORT_OPTIONS_BY_DATA_TEST))));
        }

        private void InitAddItemCartButton(string itemName)
        {
            var cleanItemName = itemName.ToLower().Replace(" ", "-");
            _itemCartButton = WebDriverWait.Until(ElementToBeClickable(By.XPath($"//button[@data-test='add-to-cart-{cleanItemName}']")));
        }

        private void InitRemoveItemCartButton(string itemName)
        {
            var cleanItemName = itemName.ToLower().Replace(" ", "-");
            _itemCartButton = WebDriverWait.Until(ElementToBeClickable(By.XPath($"//button[@data-test='remove-{cleanItemName}']")));
        }
    }
}