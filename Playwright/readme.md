Installation:
Install the SpecFlow IDE plugin (recommended)
Create the project (Specflow Project)
    Setup Driver Pattern
Install Playwright (Nuget)
Install SpecFlow.NUnit (Nuget)

Setup:
Create a Hook for Playwright
    BeforeScenario -> Create a playwright instance
Create a Feature and test caseses
Create PageObjects
    Constructor, Selector and Assertions/Actions
Create Steps which uses the logic from the PageObjects

Recording Tests:
.\Playwright\bin\Debug\net6.0\.playwright\node\win32_x64\playwright.cmd codegen
opens and creates a playwright instance
now your behavoir will be tracked und you can recored
After that change target to .Net NUnit