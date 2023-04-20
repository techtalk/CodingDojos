using Microsoft.Playwright;
using Playwright.Hooks;
using Playwright.Pages;
using TechTalk.SpecFlow;

namespace Playwright.Steps
{
    [Binding]
    public class DuckDuckGoSteps
    {
        private readonly IPage _currentPage;
        private readonly DuckDuckGoHomePage _duckDuckGoHomePage;

        public DuckDuckGoSteps(PlaywrightHooks hooks, DuckDuckGoHomePage duckDuckGoHomePage)
        {
            _currentPage = hooks.CurrentPage;
            _duckDuckGoHomePage = duckDuckGoHomePage;
        }

        [Given(@"the user is on the DuckDuckGo homepage")]
        public async Task GivenTheUserIsOnTheDuckDuckGoHomepage()
        {
            await _currentPage.GotoAsync("https://duckduckgo.com/");
            await _duckDuckGoHomePage.AssertPageContent();
        }

        [When(@"the user searches for '(.*)' on DuckDuckGo")]
        public async Task WhenTheUserSearchesFor(string searchTerm)
        {
            await _duckDuckGoHomePage.SearchAndEnter(searchTerm);
        }
    }
}