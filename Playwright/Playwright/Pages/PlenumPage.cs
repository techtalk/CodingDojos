using FluentAssertions;
using Microsoft.Playwright;
using Playwright.Hooks;

namespace Playwright.Pages
{
    public class PlenumPage
    {
        #region Constructors

        private readonly IPage _currentPage;
        private string UserName => "verena.muster@plenum.loc";
        private string Password => "Test1Test!";
        private string PlenumUrl => "https://thankful-river-04943d203-preview.westeurope.1.azurestaticapps.net/";

        public PlenumPage(PlaywrightHooks hooks)
        {
            _currentPage = hooks.CurrentPage;
        }

        #endregion

        #region Selectors

        private ILocator EmailInput => _currentPage.GetByPlaceholder("Email Address");
        private ILocator PasswordInput => _currentPage.GetByPlaceholder("Password");
        private ILocator SaveButton => _currentPage.GetByRole(AriaRole.Button, new() { Name = "Speichern" });
        private ILocator YesButton => _currentPage.GetByRole(AriaRole.Button, new() { Name = "Ja" });

        #endregion

        #region Actions

        public async Task Login()
        {
            await EmailInput.FillAsync(UserName);
            await PasswordInput.FillAsync(Password);
            await _currentPage.GetByRole(AriaRole.Button, new() { Name = "Sign in" }).ClickAsync();
        }

        public async Task OpenHomepage()
        {
            await _currentPage.GotoAsync(PlenumUrl);
        }

        public async Task<bool> ExistsTextInPage(IPage page, string element)
        {
            return await page.IsVisibleAsync($"text='{element}'");
        }

        public async Task<bool> ExistsElementInPage(IPage page, string element)
        {
            return await page.Locator(element).CountAsync() > 0;
        }

        public async Task ClickElementWithTextIfExists(string element)
        {
            if (await ExistsTextInPage(_currentPage, element))
                await _currentPage.GetByText(element).ClickAsync();
        }

        public async Task RemoveTeilnehmendeFromSitzung(string teilnehmende)
        {
            if (await ExistsElementInPage(_currentPage, "kendo-treelist") &&
                await _currentPage.GetByRole(AriaRole.Gridcell, new() { Name = teilnehmende }).CountAsync() == 1)
            {
                await _currentPage.GetByRole(AriaRole.Row, new() { Name = teilnehmende })
                    .GetByTitle("aus Sitzung entfernen").ClickAsync();
                await YesButton.ClickAsync();
            }
        }

        public async Task ClickStatusDropDown()
        {
            await _currentPage.Locator("formly-field")
                .Filter(new() { HasText = "Status *" })
                .Nth(2).ClickAsync();
        }

        public async Task GoToStartpage()
        {
            var navigation = _currentPage.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Button);
            navigation.Should().NotBeNull();
            await navigation.ClickAsync();

            var startButton = _currentPage.GetByRole(AriaRole.Button, new() { Name = " Startseite" });
            startButton.Should().NotBeNull();
            await startButton.ClickAsync();

            await ClickElementWithTextIfExists("Weitere Sitzungen anzeigen");
        }

        public async Task OpenSitzung(string sitzungsArt)
        {
            var sitzung = _currentPage.GetByText(sitzungsArt);
            sitzung.Should().NotBeNull();
            await sitzung.ClickAsync();
        }

        #endregion

        #region Assertions

        public async Task AssertPageContent()
        {
            var emailInputVisibility = await EmailInput.IsVisibleAsync();
            emailInputVisibility.Should().BeTrue();

            var passwordInputVisibility = await PasswordInput.IsVisibleAsync();
            passwordInputVisibility.Should().BeTrue();
        }

        #endregion
    }
}