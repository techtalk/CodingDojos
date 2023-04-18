using FluentAssertions;
using Microsoft.Playwright;
using Playwright.Hooks;

namespace Playwright.Pages
{
    public class PlenumPage
    {
        #region Constructors

        private readonly IPage _user;
        private string UserName => "verena.muster@plenum.loc";
        private string Password => "Test1Test!";
        private string PlenumUrl => "https://thankful-river-04943d203-preview.westeurope.1.azurestaticapps.net/";

        public PlenumPage(PlaywrightHooks hooks)
        {
            _user = hooks.User;
        }

        #endregion

        #region Selectors
        
        private ILocator EmailInput => _user.GetByPlaceholder("Email Address");
        private ILocator PasswordInput => _user.GetByPlaceholder("Password");

        #endregion

        #region Actions/Assertions

        public async Task AssertPageContent()
        {
            //Assert that the search input is visible
            var emailInputVisibility = await EmailInput.IsVisibleAsync();
            emailInputVisibility.Should().BeTrue();

            var passwordInputVisibility = await PasswordInput.IsVisibleAsync();
            passwordInputVisibility.Should().BeTrue();

            await Login();
            await CreateSitzung();
            await TeilnehmendeHinzufuegen();
            await CreateTagesordnungspunkte();
            await ChangeState();
        }

        public async Task Login()
        {
            await EmailInput.FillAsync(UserName);
            await PasswordInput.FillAsync(Password);
            await _user.GetByRole(AriaRole.Button, new() { Name = "Sign in" }).ClickAsync();
        }

        public async Task OpenHomepage()
        {
            await _user.GotoAsync(PlenumUrl);
        }

        public async Task GoToStartpage()
        {
            if (await ExistsTextInPage(_user, "Weitere Sitzungen anzeigen"))
                await _user.GetByRole(AriaRole.Button, new() { Name = "Weitere Sitzungen anzeigen" }).ClickAsync();
            
            await _user.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Button).ClickAsync();
            await _user.GetByRole(AriaRole.Button, new() { Name = " Startseite" }).ClickAsync();
        }

        public async Task<bool> ExistsTextInPage(IPage page, string element)
        {
            return await page.IsVisibleAsync($"text='{element}'");
        }
        public async Task<bool> ExistsElementInPage(IPage page, string element)
        {
            return await page.Locator(element).CountAsync() > 0;
        }

        public async Task CreateSitzung()
        {
            //Assert that the correct URL has been reached
            //_user.Url.Should().Be(PlenumUrl);

            await _user.GetByRole(AriaRole.Link, new() { Name = "Neue Sitzung" }).ClickAsync();

            await _user.GetByPlaceholder("Titel").ClickAsync();

            await _user.GetByPlaceholder("Titel").FillAsync("Playwright-Sirtung");

            await _user.GetByRole(AriaRole.Button, new() { Name = "Toggle popup" }).ClickAsync();

            await _user.GetByRole(AriaRole.Link, new() { Name = "Heute" }).ClickAsync();

            await _user.GetByRole(AriaRole.Button, new() { Name = "Jetzt" }).ClickAsync();

            await _user.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();

            await _user.GetByRole(AriaRole.Combobox, new() { Name = "Sitzungsart" }).ClickAsync();

            await _user.GetByRole(AriaRole.Combobox, new() { Name = "Sitzungsart" })
                .FillAsync("GX_Gemeinderatssitzung");

            await _user.GetByRole(AriaRole.Combobox, new() { Name = "Ort" }).ClickAsync();

            await _user.GetByText("Gemeinderatssaal").ClickAsync();

            await _user.GetByRole(AriaRole.Button, new() { Name = "Speichern" }).ClickAsync();

            await GoToStartpage();

        }

        public async Task TeilnehmendeHinzufuegen()
        {
            if(await ExistsTextInPage(_user, "Weitere Sitzungen anzeigen"))
                await _user.GetByRole(AriaRole.Button, new() { Name = "Weitere Sitzungen anzeigen" }).ClickAsync();

            await _user.GetByText("GX_Gemeinderatssitzung").ClickAsync();

            if (await ExistsElementInPage(_user, "kendo-treelist"))
            {
                //await _user.GetByRole(AriaRole.Row, new() { Name = "Verena Muster Administration " }).GetByTitle("aus Sitzung entfernen").ClickAsync();
                //await _user.GetByRole(AriaRole.Button, new() { Name = "Ja" }).ClickAsync();

                //await _user.GetByRole(AriaRole.Table).GetByRole(AriaRole.Row).Nth(0).GetByTitle("aus Sitzung entfernen").ClickAsync();
            }

            await _user.GetByRole(AriaRole.Button, new() { Name = "Teilnehmende hinzufügen" }).ClickAsync();

            await _user.GetByRole(AriaRole.Treeitem, new() { Name = "Verena Muster | Administration  | AdminUser" }).Locator("kendo-checkbox").ClickAsync();
            await _user.GetByRole(AriaRole.Button, new() { Name = "Zur Sitzung hinzufügen" }).ClickAsync();
            //await _user.GetByRole(AriaRole.Button, new() { Name = "Teilnehmende hinzufügen" }).ClickAsync();

            //await _user.GetByRole(AriaRole.Button, new() { Name = "Neuen Teilnehmenden anlegen" }).ClickAsync();

            await GoToStartpage();

        }

        public async Task CreateTagesordnungspunkte()
        {
            await _user.GetByText("GX_Gemeinderatssitzung").ClickAsync();

            await _user.Locator("pl-button").Filter(new() { HasText = "Neuen Tagesordnungspunkt erstellen" }).GetByRole(AriaRole.Button, new() { Name = "Neuen Tagesordnungspunkt erstellen" }).ClickAsync();

            await _user.GetByPlaceholder("eintippen", new() { Exact = true }).ClickAsync();

            await _user.GetByPlaceholder("eintippen", new() { Exact = true }).FillAsync("Test TOP");

            await _user.GetByRole(AriaRole.Button, new() { Name = "Speichern" }).ClickAsync();

            await _user.GetByRole(AriaRole.Button, new() { Name = " Neuen Kommentar hinzufügen" }).ClickAsync();

            await _user.GetByPlaceholder("Schreibe einen Kommentar ...").FillAsync("bla");

            await _user.GetByRole(AriaRole.Button, new() { Name = "Posten" }).ClickAsync();

            await _user.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Button).ClickAsync();

            await _user.GetByRole(AriaRole.Button, new() { Name = " Startseite" }).ClickAsync();

            //--------------------------------------

            await _user.GetByRole(AriaRole.Link, new() { Name = "Neuer Tagesordnungspunkt" }).ClickAsync();

            await _user.GetByPlaceholder("eintippen", new() { Exact = true }).ClickAsync();

            await _user.GetByPlaceholder("eintippen", new() { Exact = true }).FillAsync("Test TOP 2");

            await _user.GetByRole(AriaRole.Button, new() { Name = "Speichern" }).ClickAsync();

            await _user.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Button).ClickAsync();

            await _user.GetByRole(AriaRole.Button, new() { Name = " Startseite" }).ClickAsync();

            await _user.GetByText("GX_Gemeinderatssitzung").ClickAsync();

            await _user.Locator("app-admin-add-pending-traktandum").GetByRole(AriaRole.Button, new() { Name = "Select" }).ClickAsync();

            await _user.GetByText("Test TOP 2").ClickAsync();

            await _user.GetByRole(AriaRole.Button, new() { Name = "Tagesordnungspunkt zuordnen" }).ClickAsync();

            await _user.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Button).ClickAsync();

            await _user.GetByRole(AriaRole.Button, new() { Name = " Startseite" }).ClickAsync();


        }

        public async Task ChangeState()
        {
            await _user.GetByText("GX_Gemeinderatssitzung").ClickAsync();

            await _user.GetByText("Test TOP 2").ClickAsync();

            await _user.GetByText("Offen").ClickAsync();

            await _user.GetByText("Verschoben", new() { Exact = true }).ClickAsync();

            await _user.GetByRole(AriaRole.Button, new() { Name = "Speichern" }).ClickAsync();

            await _user.GetByRole(AriaRole.Combobox).Filter(new() { HasText = "GX_Gemeinderatssitzung | 18.04.2023" }).GetByRole(AriaRole.Button, new() { Name = "Select" }).ClickAsync();

            await _user.GetByText("Gemeinderatssitzung | 18.04.2023").Nth(4).ClickAsync();

            await _user.GetByRole(AriaRole.Button, new() { Name = "Speichern" }).ClickAsync();

            await _user.GetByRole(AriaRole.Link, new() { Name = "Startseite" }).ClickAsync();

            await _user.GetByRole(AriaRole.Checkbox).CheckAsync();
        }

        #endregion
    }
}