namespace SpecFlowTests.Drivers
{
    public class UserDriver
    {
        public string CurrentUsername { get; set; }

        public string DefaultUser => "Adam User";

        public void LoginAsUser(string username)
        {
            CurrentUsername = username;
        }
    }
}
