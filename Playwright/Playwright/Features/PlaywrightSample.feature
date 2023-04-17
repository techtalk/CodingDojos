Feature: PlaywrightSample
	An example how a use palywright

Scenario: Search for Playwright on DuckDuckGo (after Record)
	Given start the recorded test

Scenario: Search for Playwright on DuckDuckGo
	Given the user is on the DuckDuckGo homepage
	When the user searches for 'Playwright' on DuckDuckGo
	Then the search results show 'Playwright' as the first result with link 'https://playwright.dev/' on 'DuckDuckGo'