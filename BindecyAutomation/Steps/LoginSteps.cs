using BindecyAutomation.Navigation;

namespace BindecyAutomation.Steps
{
    public class LoginSteps
    {
        private PageNavigator _pageNavigator;
        
        public LoginSteps(PageNavigator pageNavigator)
        {
            _pageNavigator = pageNavigator;
        }
        
        
        public void LoginToSystem(string username, string password)
        {
            var loginPage = _pageNavigator!.NavigateToLoginPage();
            loginPage.EnterUserName(username);
            loginPage.EnterPassword(password);
            loginPage.Login();
        }
    }
}