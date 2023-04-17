using Microsoft.Playwright;
using Playwright.Hooks;
using Playwright.Pages;
using TechTalk.SpecFlow;

namespace Playwright.Steps
{
    [Binding]
    public class PlaywrightRecordSampleSteps 
    {
        private readonly IPage _user;
        private readonly DuckDuckGoHomePage _duckDuckGoHomePage;

        public PlaywrightRecordSampleSteps(PlaywrightHooks hooks, DuckDuckGoHomePage duckDuckGoHomePage)
        {
            _user = hooks.User;
            _duckDuckGoHomePage = duckDuckGoHomePage;
        }

        [Given(@"start the recorded test")]
        public async Task GivenStartTheRecordedTest()
        {
            await _duckDuckGoHomePage.RunRecord();
        }
    }
}