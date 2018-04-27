using NSpec;
using FluentAssertions;
using CastelloPageObjects.Pages;
using CastelloPageObjects.Helpers;

namespace NSpecIntro
{
    [Tag("search")]
    class search_on_recipe_overview : nspec
    {
        void describe_enter_search_query()
        {
            RecipeOverviewPage page = null;
            BrowserSetup browser = new BrowserSetup("UI");
            var searchQuery = "cake";
            var negativeQuery = "qwerty";

            context["given Recipe Overview page is opened"] = () =>
            {
                before = () => page = browser.OpenPage<RecipeOverviewPage>(RecipeOverviewPage.Url);

                context[$"when I have entered '{searchQuery}' in the search field"] = () =>
                {
                    before = () =>
                    {
                        
                        page.EnterSearchQuery(searchQuery);
                        
                    };

                    it[$"result should contain '{searchQuery}' in the title"] =
                        () =>
                        {
                            string firstRecipeTitle = page.FirstRecipeTitle();
                            
                            firstRecipeTitle.ToLower().Should().Contain(searchQuery);

                        };
                };

               // context[$"when I have entered '{negativeQuery}' in the search field"] = () =>
               //{
               //    before = () =>
               //    {
               //        page.EnterSearchQuery(negativeQuery);
               //    };

               //    it["result should show Nothing found message"] =
               //            () =>
               //            {
               //                var isMessageShown = page.NothingFoundMessage();
                               
               //                isMessageShown.Should().BeTrue();

               //            };
               //};

                afterAll = () => browser.Close();
            };
        }
    }
}
