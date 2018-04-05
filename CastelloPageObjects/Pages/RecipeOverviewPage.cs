using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using CastelloPageObjects.Helpers;

namespace CastelloPageObjects.Pages
{
    public class RecipeOverviewPage : BrowserPage
    {
        public static string Url = "https://castello-tie.cmsstage.com/recipes/";
        // private IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "span.overview-filters__search-title.js-filter-search")]
        private IWebElement SearchItem;

        [FindsBy(How = How.CssSelector, Using = ".overview-filters__search-input.js-search-field")]
        private IWebElement SearchInputField;

        //[FindsBy(How = How.CssSelector, Using = ".recipes-overview__grid-item--featured")]
        //private IWebElement FirstRecipe;


        public void EnterSearchQuery(string searchQuery)
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div.sign-in-popup")));
            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(".overview-filters__search-title.js-filter-search")));
            Console.WriteLine("search is visible");
            SearchItem.Click();
            
            Console.WriteLine("clicked on search");
            
            SearchInputField.SendKeys(searchQuery);
           // Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            SearchInputField.SendKeys(Keys.Return);
           // Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public string FirstRecipeTitle()
        {
            var firstRecipe = Driver.FindElement(By.CssSelector(".recipes-overview__grid-item--featured h4"));
            return firstRecipe.Text;
        }

    }
}
