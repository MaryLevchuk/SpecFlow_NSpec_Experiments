using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace CastelloPageObjects.Helpers
{
    public abstract class BrowserPage
    {
        protected IWebDriver Driver;
        internal void SetDriver(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }

    public class BrowserSetup
    {
        public IWebDriver Driver;
        public BrowserSetup()
        {
            //ChromeOptions option = new ChromeOptions();
            //option.AddArgument("--headless");
            //Driver = new ChromeDriver(option);
            Driver = new ChromeDriver();
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
