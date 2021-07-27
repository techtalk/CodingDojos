using System.Threading.Tasks;
using SpecFlowTests.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Steps
{
    [Binding]
    public class UserSteps
    {
        public UserDriver UserDriver { get; }

        public UserSteps(UserDriver userDriver)
        {
            UserDriver = userDriver;
        }

        [Given(@"I am logged in as '(.*)'")]
        public void GivenIAmLoggedInAs(string username)
        {
            UserDriver.LoginAsUser(username);
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            UserDriver.LoginAsUser(UserDriver.DefaultUser);
        }
    }
}