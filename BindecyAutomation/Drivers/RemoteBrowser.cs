using System;
using BindecyAutomation.Configuration;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace BindecyAutomation.Drivers
{
    public class RemoteBrowser : RemoteWebDriver
    {
        public RemoteBrowser(IOptions<RemoteBrowserConfig> remoteBrowserConfig, ChromeOptions browserOptions)
            : base(new Uri(remoteBrowserConfig.Value.SeleniumGridUrl), browserOptions)
        {
        }
    }
}