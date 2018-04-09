using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using CastelloPageObjects.Helpers;
using System.Threading;

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
            SearchItem.Click();
            SearchInputField.Clear();
            SearchInputField.SendKeys(searchQuery);
            SearchInputField.SendKeys(Keys.Return);
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("svg.ajax-loader__circular")));
            ///ajax - loader__circular
        }

        public string FirstRecipeTitle()
        {
            var firstRecipe = Driver.FindElement(By.CssSelector(".recipes-overview__grid-item--featured h4"));
            return firstRecipe.Text;
        }

        public Boolean NothingFoundMessage()
        {
            var message = Driver.FindElement(By.CssSelector("recipes-overview__empty-result.js-endless-scroll-empty.is-shown h4"));
            return message.Displayed;
        }

    }
}
