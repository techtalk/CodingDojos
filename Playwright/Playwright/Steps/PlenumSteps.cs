using Microsoft.Playwright;
using Playwright.Hooks;
using Playwright.Pages;
using TechTalk.SpecFlow;

namespace Playwright.Steps
{
    [Binding]
    public class PlenumSteps
    {
        private readonly IPage _user;
        private readonly PlenumPage _plenumHomePage;

        public PlenumSteps(PlaywrightHooks hooks, PlenumPage plenumHomePage)
        {
            _user = hooks.User;
            _plenumHomePage = plenumHomePage;
        }
    }
}