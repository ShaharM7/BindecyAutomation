using OpenQA.Selenium.Chrome;

namespace BindecyAutomation.Drivers
{
    public class ChromeBrowser : ChromeDriver
    {
        public ChromeBrowser(ChromeOptions options) : base(options)
        {
        }
    }
}