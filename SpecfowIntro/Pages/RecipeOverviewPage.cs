using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using SpecfowIntro.Helpers;

namespace SpecfowIntro.Pages
{
    public class RecipeOverviewPage : BrowserPage
    {
        // private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = ".overview-filters__search-title.js-filter-search")]
        private IWebElement SearchItem;

        [FindsBy(How = How.CssSelector, Using = ".overview-filters__search-input.js-search-field")]
        private IWebElement SearchInputField;

        //[FindsBy(How = How.CssSelector, Using = ".recipes-overview__grid-item--featured")]
        //private IWebElement FirstRecipe;


        //public RecipeOverviewPage(IWebDriver driver)
        //{
        //    _driver = driver;
        //    PageFactory.InitElements(_driver, this);
        //}

        public void EnterSearchQuery(string searchQuery)
        {
            SearchItem.Click();
            SearchInputField.SendKeys(searchQuery);
            SearchInputField.SendKeys(Keys.Return);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        public string FirstRecipeTitle()
        {
            var firstRecipe = Driver.FindElement(By.CssSelector(".recipes-overview__grid-item--featured h4"));
            return firstRecipe.Text;
        }

    }
}
