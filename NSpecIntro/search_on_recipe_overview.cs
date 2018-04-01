using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSpec;
using CastelloPageObjects.Pages;
using CastelloPageObjects.Helpers;
using System.Threading;
using FluentAssertions;

namespace NSpecIntro
{
    [Tag("search")]
    class search_on_recipe_overview : nspec
    {
        void describe_enter_search_query()
        {
            RecipeOverviewPage page = null;
            BrowserSetup browser = new BrowserSetup();
            var searchQuery = "cake";

            context["given Recipe Overview page is opened"] = () =>
            {
                before = () => page = browser.OpenPage<RecipeOverviewPage>(RecipeOverviewPage.Url);

                context[$"when I have entered '{searchQuery}' in the search field"] = () =>
                {
                    before = () =>
                    {
                        page.EnterSearchQuery(searchQuery);
                        Thread.Sleep(2000);
                    };

                    it[$"result should contain '{searchQuery}' in the title"] =
                        () =>
                        {
                            string firstRecipeTitle = page.FirstRecipeTitle();
                            browser.Close();
                            firstRecipeTitle.ToLower().Should().Contain(searchQuery);

                        };
                };
            };
        }
    }
}
