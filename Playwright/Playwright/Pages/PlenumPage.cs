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
            var emailInputVisibility = await EmailInput.IsVisibleAsync();
            emailInputVisibility.Should().BeTrue();

            var passwordInputVisibility = await PasswordInput.IsVisibleAsync();
            passwordInputVisibility.Should().BeTrue();
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
            var navigation = _user.GetByRole(AriaRole.Navigation).GetByRole(AriaRole.Button);
            navigation.Should().NotBeNull();
            await navigation.ClickAsync();

            var startButton = _user.GetByRole(AriaRole.Button, new() { Name = " Startseite" });
            startButton.Should().NotBeNull();
            await startButton.ClickAsync();

            await ClickElementWithTextIfExists("Weitere Sitzungen anzeigen");
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
            if (await ExistsTextInPage(_user, element))
                await _user.GetByText(element).ClickAsync();
        }

        public async Task SetDateToNow()
        {
            await _user.GetByRole(AriaRole.Button, new() { Name = "Toggle popup" }).ClickAsync();
            await _user.GetByRole(AriaRole.Link, new() { Name = "Heute" }).ClickAsync();
            await _user.GetByRole(AriaRole.Button, new() { Name = "Jetzt" }).ClickAsync();
            await _user.GetByRole(AriaRole.Button, new() { Name = "OK" }).ClickAsync();
        }

        public async Task ClickSave()
        {
            await _user.GetByRole(AriaRole.Button, new() { Name = "Speichern" }).ClickAsync();
        }

        public async Task ClickYes()
        {
            await _user.GetByRole(AriaRole.Button, new() { Name = "Ja" }).ClickAsync();
        }

        public async Task CreateSitzung(string sitzungName, string sitzungsArt)
        {
            await _user.GetByRole(AriaRole.Link, new() { Name = "Neue Sitzung" }).ClickAsync();
            await _user.GetByPlaceholder("Titel").ClickAsync();
            await _user.GetByPlaceholder("Titel").FillAsync(sitzungName);

            await SetDateToNow();

            await _user.GetByRole(AriaRole.Combobox, new() { Name = "Sitzungsart" }).ClickAsync();
            await _user.GetByRole(AriaRole.Combobox, new() { Name = "Sitzungsart" })
                .FillAsync(sitzungsArt);
            await _user.GetByRole(AriaRole.Combobox, new() { Name = "Ort" }).ClickAsync();
            await _user.GetByText("Gemeinderatssaal").ClickAsync();

            await ClickSave();
            await GoToStartpage();
        }

        public async Task RemoveTeilnehmendeFromSitzung(string teilnehmende)
        {
            if (await ExistsElementInPage(_user, "kendo-treelist") &&
                await _user.GetByRole(AriaRole.Gridcell, new() { Name = teilnehmende }).CountAsync() == 1)
            {
                await _user.GetByRole(AriaRole.Row, new() { Name = teilnehmende })
                    .GetByTitle("aus Sitzung entfernen").ClickAsync();
                await ClickYes();
            }
        }

        public async Task AddExistingTeilnehmendeToSitzung(string teilnehmer)
        {
            await RemoveTeilnehmendeFromSitzung(teilnehmer);
            await _user.GetByRole(AriaRole.Button, new() { Name = "Teilnehmende hinzufügen" }).ClickAsync();
            await _user.GetByRole(AriaRole.Treeitem, new() { Name = teilnehmer }).Locator("kendo-checkbox")
                .ClickAsync();
            await _user.GetByRole(AriaRole.Button, new() { Name = "Zur Sitzung hinzufügen" }).ClickAsync();
        }

        public async Task OpenSitzung(string sitzungsArt)
        {
            var sitzung = _user.GetByText(sitzungsArt);
            sitzung.Should().NotBeNull();
            await sitzung.ClickAsync();
        }

        public async Task OpenTagesordnungspunkt(string topName)
        {
            var top = _user.GetByText(topName, new() { Exact = true });
            top.Should().NotBeNull();
            await top.ClickAsync();
        }

        public async Task AddCommentToTagesordnungspunkt(string comment)
        {
            await _user.GetByRole(AriaRole.Button, new() { Name = " Neuen Kommentar hinzufügen" }).ClickAsync();
            //await _user.Locator("newCommentBtn").GetByRole(AriaRole.Button).ClickAsync();
            await _user.GetByPlaceholder("Schreibe einen Kommentar ...").FillAsync(comment);
            await _user.GetByRole(AriaRole.Button, new() { Name = "Posten" }).ClickAsync();
            await GoToStartpage();
        }

        public async Task CreateTagesordnungspunktWithinSitzung(string topName)
        {
            await _user.Locator("pl-button").Filter(new() { HasText = "Neuen Tagesordnungspunkt erstellen" })
                .GetByRole(AriaRole.Button, new() { Name = "Neuen Tagesordnungspunkt erstellen" }).ClickAsync();

            await _user.GetByPlaceholder("eintippen", new() { Exact = true }).ClickAsync();
            await _user.GetByPlaceholder("eintippen", new() { Exact = true }).FillAsync(topName);

            await ClickSave();
            await GoToStartpage();
        }

        public async Task AddTagesordnungspunktToSitzung(string topName)
        {
            await _user.Locator("app-admin-add-pending-traktandum")
                .GetByRole(AriaRole.Button, new() { Name = "Select" }).ClickAsync();

            await _user.GetByText(topName).ClickAsync();
            await _user.GetByRole(AriaRole.Button, new() { Name = "Tagesordnungspunkt zuordnen" }).ClickAsync();

            await GoToStartpage();
        }

        public async Task CreateTagesordnungspunkt(string topName)
        {
            await _user.GetByRole(AriaRole.Link, new() { Name = "Neuer Tagesordnungspunkt" }).ClickAsync();

            await _user.GetByPlaceholder("eintippen", new() { Exact = true }).ClickAsync();
            await _user.GetByPlaceholder("eintippen", new() { Exact = true }).FillAsync(topName);

            await ClickSave();
            await GoToStartpage();
        }

        public async Task ShowAllCompletedSitzungen()
        {
            await _user.GetByRole(AriaRole.Checkbox).CheckAsync();
        }

        public async Task ClickStatusDropDown()
        {
            await _user.Locator("formly-field")
                .Filter(new() { HasText = "Status *" })
                .Nth(2).ClickAsync();
        }

        public async Task ChangeStateOfTagesordnungspunkt(string newState)
        {
            await ClickStatusDropDown();
            await _user.GetByText(newState, new() { Exact = true }).ClickAsync();
            await ClickSave();
        }

        public async Task AssertSitzung(string sitzungsName, string sitzungsArt)
        {
            await GoToStartpage();
            var sitzungsArtExists = await ExistsTextInPage(_user, sitzungsArt);
            sitzungsArtExists.Should().BeTrue();
            await OpenSitzung(sitzungsArt);
            var sitzungInputField = await _user.GetByPlaceholder("Titel").InputValueAsync();
            sitzungInputField.Should().Be(sitzungsName);
        }

        #endregion
    }
}