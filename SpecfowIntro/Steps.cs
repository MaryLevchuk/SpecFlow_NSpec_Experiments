using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using CastelloPageObjects.Pages;
using CastelloPageObjects.Helpers;
using FluentAssertions;
using System.Threading;

namespace SpecfowIntro
{
    [Binding]
    class Steps
    {
        public RecipeOverviewPage RecipeOverviewPage;
        public BrowserSetup Browser { get; } = new BrowserSetup("UI");

        [Given(@"RecipeOverview page is opened")]
        public void GivenRecipeOverviewPageIsOpened()
        {
            RecipeOverviewPage = Browser.OpenPage<RecipeOverviewPage>(RecipeOverviewPage.Url);
            Thread.Sleep(5000);
        }

        [When(@"I have entered '(.*)' into the SearchField")]
        public void WhenIHaveEnteredIntoTheSearchField(string searchQuery)
        {
            RecipeOverviewPage.EnterSearchQuery(searchQuery);
            Thread.Sleep(2000); // todo: find a correct way (see ExpectedConditions)
        }

        [Then(@"result should contain '(.*)' in the title")]
        public void ThenResultShouldContainInTheTitle(string searchQuery)
        {
            string firstRecipeTitle = RecipeOverviewPage.FirstRecipeTitle();
            Browser.Close();
            firstRecipeTitle.ToLower().Should().Contain(searchQuery);
        }

        [Then(@"result should not contain recipes")]
        public void ThenResultShouldNotContainRecipes()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"show '(.*)' message")]
        public void ThenShowMessage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
