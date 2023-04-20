using Microsoft.Playwright;
using Playwright.Hooks;
using Playwright.Pages;
using TechTalk.SpecFlow;

namespace Playwright.Steps
{
    [Binding]
    public class PlenumSteps
    {
        private readonly IPage _currentPage;
        private readonly PlenumPage _plenumHomePage;

        public PlenumSteps(PlaywrightHooks hooks, PlenumPage plenumHomePage)
        {
            _currentPage = hooks.CurrentPage;
            _plenumHomePage = plenumHomePage;
        }
    }
}