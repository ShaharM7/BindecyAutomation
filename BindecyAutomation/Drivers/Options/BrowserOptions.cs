using BindecyAutomation.Configuration;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;

namespace BindecyAutomation.Drivers.Options
{
    public sealed class BrowserOptions : ChromeOptions
    {
        public BrowserOptions(IOptions<BrowserOptionsConfig> browserOptionsConfig,
            IOptions<RemoteBrowserConfig> remoteBrowserConfig, IOptions<BrowserStackConfig> browserStackConfig)
        {
            AddArguments(browserOptionsConfig.Value.Arguments);

            if (remoteBrowserConfig.Value.UseSeleniumGrid)
            {
                BrowserName = remoteBrowserConfig.Value.BrowserName;
                BrowserVersion = remoteBrowserConfig.Value.BrowserVersion;
                PlatformName = remoteBrowserConfig.Value.PlatformName;

                AddAdditionalOption("bstack:options", browserStackConfig.Value.BrowserStackOptions);
            }
        }
    }
}