using FluentAssertions;
using Microsoft.Playwright;
using Playwright.Hooks;

namespace Playwright.Pages
{
    public class PlenumPage
    {
        #region Constructors

        private readonly IPage _user;

        public PlenumPage(PlaywrightHooks hooks)
        {
            _user = hooks.User;
        }

        #endregion

        #region Selectors

        private ILocator SearchInput => _user.Locator("input[id='XXX']");

        #endregion

        #region Actions/Assertions

        public async Task AssertPageContent()
        {
            //Assert that the correct URL has been reached
            _user.Url.Should().Be("https://thankful-river-04943d203-preview.westeurope.1.azurestaticapps.net/");

            //Assert that the search input is visible
            var searchInputVisibility = await SearchInput.IsVisibleAsync();
            searchInputVisibility.Should().BeTrue();
        }

        #endregion
    }
}