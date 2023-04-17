using Playwright.Pages;
using Playwright.Utilits;
using TechTalk.SpecFlow;

namespace Playwright.Steps
{
    [Binding]
    public class SearchResultSteps
    {
        private readonly SearchResultsPage _searchResultsPage;

        public SearchResultSteps(SearchResultsPage searchResultsPage)
        {
            _searchResultsPage = searchResultsPage;
        }

        [Then(@"the search results show '(.*)' as the first result with link '(.*)' on '(.*)'")]
        public async Task ThenTheSearchResultsShowAsTheFirstResult(string expectedResult, string expectedLink, string searchEngine)
        {
            //Assert the page content
            await _searchResultsPage.AssertPageContent(expectedResult, SearchEngineDictionary.GetSearchEngineUrl(searchEngine));

            //Assert the first search result (hence the index of 0)
            await _searchResultsPage.AssertSearchResultAtIndex(expectedResult, 0, expectedLink);
        }
    }
}