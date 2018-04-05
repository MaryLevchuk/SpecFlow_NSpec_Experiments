using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CastelloPageObjects.Helpers
{
    public abstract class BrowserPage
    {
        protected IWebDriver Driver;
        public WebDriverWait Wait;
        internal void SetDriver(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
            PageFactory.InitElements(driver, this);
        }
    }

    

    public class BrowserSetup
    {
        public IWebDriver Driver;
        
        public BrowserSetup(string mode)
        {
            switch (mode)
            {
                case "Headless":
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("--headless");
                    Driver = new ChromeDriver(option);
                    break;
                case "UI":
                    Driver = new ChromeDriver();
                    break;
            }

            
            


        }

        public TPage OpenPage<TPage>(string url)
            where TPage: BrowserPage, new()
        {
            Driver.Navigate().GoToUrl(url);
            var result = new TPage();
            result.SetDriver(Driver);
            return result;
        }

        public void Close()
        {
            Driver.Quit();
        }        
    }
}
