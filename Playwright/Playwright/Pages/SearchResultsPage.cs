using FluentAssertions;
using Microsoft.Playwright;
using Playwright.Hooks;

namespace Playwright.Pages
{
    public class SearchResultsPage
    {
        #region Constructors

        private readonly IPage _currentPage;

        public SearchResultsPage(PlaywrightHooks hooks)
        {
            _currentPage = hooks.CurrentPage;
        }

        #endregion

        #region Selectors

        private int _resultIndex;

        private ILocator SearchInput => _currentPage.Locator("input[id='search_form_input']");
        private ILocator SearchResults => _currentPage.Locator("div[id='links']");
        private ILocator ResultArticle => SearchResults.Locator("article").Nth(_resultIndex);
        private ILocator ResultHeading => ResultArticle.Locator("h2");
        private ILocator ResultLink => ResultArticle.Locator("a[data-testid='result-title-a']");

        #endregion

        #region Actions/Assertions

        public async Task AssertPageContent(string searchTerm, string searchUrl)
        {
            await _currentPage.WaitForURLAsync($"{searchUrl}{searchTerm}*");

            var searchInputInnerText = await SearchInput.InputValueAsync();
            searchInputInnerText.Should().Be(searchTerm);
        }

        public async Task AssertSearchResultAtIndex(string searchTerm, int resultIndex, string expectedResultLink)
        {
            _resultIndex = resultIndex;

            var firstResultInnerText = await ResultHeading.InnerTextAsync();
            firstResultInnerText.Should().Contain(searchTerm);

            var firstResultLink = await ResultLink.GetAttributeAsync("href");
            firstResultLink.Should().Be(expectedResultLink);
        }

        #endregion
    }
}