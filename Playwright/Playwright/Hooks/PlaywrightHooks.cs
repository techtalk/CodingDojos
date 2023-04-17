using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace Playwright.Hooks
{
    [Binding]
    public class PlaywrightHooks
    {
        private bool UsePlaywrightBrowser => true;
        public IPage User { get; private set; } = null!; // -> We'll call this property in the tests

        [BeforeScenario] // -> Notice how we're doing these steps before each scenario
        public async Task RegisterSingleInstancePractitioner()
        {
            //Initialise Playwright
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            //Initialise a browser - 'Chromium' can be changed to 'Firefox' or 'Webkit'
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,   // -> Use this option to be able to see your test running
                SlowMo = 1000,      // -> Sets the speed of playwright
                Timeout = 10000,    // -> Sets the timeout
                Channel = "msedge", // -> Can be "msedge", "chrome" "chrome-beta", "msedge-beta", "msedge-dev", etc.
                ExecutablePath = TryGetPathToInstalledChrome(), // -> Its possible to use the own browser
                //DownloadsPath = ""
            });

            //Setup a browser context
            var context = await browser.NewContextAsync();

            //Initialise a page on the browser context.
            User = await context.NewPageAsync();
        }

        protected virtual string? TryGetPathToInstalledChrome()
        {
            if (UsePlaywrightBrowser)
                return null;

            var regeditBrwoserPath = @"HKEY_CLASSES_ROOT\ChromeHTML\shell\open\command";
            var path = Microsoft.Win32.Registry.GetValue(regeditBrwoserPath, null, null) as string;
            if (path == null) 
                return path;
            
            var split = path.Split('\"');
            return split.Length >= 2 ? split[1] : null;
        }
    }
}