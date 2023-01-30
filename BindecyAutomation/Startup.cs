using BindecyAutomation.Configuration;
using BindecyAutomation.Drivers;
using BindecyAutomation.Drivers.Options;
using BindecyAutomation.Navigation;
using BindecyAutomation.Pages;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BindecyAutomation
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ------------------------------- Configuration -------------------------------------------
            services.AddOptions();
            services.Configure<AwaiterConfig>(Configuration.GetSection(nameof(AwaiterConfig)));
            services.Configure<BrowserOptionsConfig>(Configuration.GetSection(nameof(BrowserOptionsConfig)));
            services.Configure<BrowserStackConfig>(Configuration.GetSection(nameof(RemoteBrowserConfig)));
            services.Configure<NavigationConfig>(Configuration.GetSection(nameof(NavigationConfig)));
            services.Configure<RemoteBrowserConfig>(Configuration.GetSection(nameof(RemoteBrowserConfig)));

            // ---------------------------------- Pages ------------------------------------------------
            services.AddSingleton<LoginPage>();
            services.AddSingleton<MainPage>();
            services.AddSingleton<CartPage>();
            services.AddSingleton<CheckoutPage>();

            // ---------------------------------- Infra -------------------------------------------
            services.AddSingleton<PageNavigator>();
            services.AddSingleton<ChromeOptions, BrowserOptions>();

            // --------------------------------- Drivers -----------------------------------------------
            services.AddSingleton<WebDriverWait, Awaiter>();

            var useSeleniumGridValue = Configuration.GetValue<bool>("RemoteBrowserConfig:UseSeleniumGrid");
            switch (useSeleniumGridValue)
            {
                case true:
                    services.AddSingleton<IWebDriver, RemoteBrowser>();
                    break;
                case false:
                    services.AddSingleton<IWebDriver, ChromeBrowser>();
                    break;
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}