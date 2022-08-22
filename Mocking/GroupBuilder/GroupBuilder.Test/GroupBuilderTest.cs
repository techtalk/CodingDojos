using Xunit;

namespace GroupBuilder.Test
{
    /// <summary>
    /// What do we need for working tests?
    /// Which methods/classes do we want to mock for test execution, and how?
    /// How do we manage accessibility of methods, so we do not expose all methods we want to test?
    /// What test cases could help us to instantly identify an issue when it fails?
    /// </summary>
    public class GroupBuilderTest
    {
        [Fact]
        public void DummyTest_ShouldWork()
        {
            Assert.True(true);
        }

        [Fact]
        public void GroupBuilder_NumberGroupsEqualsPersons_ReturnsFlatList()
        {
            //arrange
            List<Person> people = new[]
                {
                    new Person("John Rambo", Roles.Architekt),
                    new Person("Enemy of Rambo", Roles.Architekt),
                }
                .ToList();

            var groupMode = GroupMode.Group;
            var count = 1;

            var groupBuilder = new Builder();

            //act
            List<Group> groups = groupBuilder.BuildGroups(people, groupMode, count);

            //assert
            Assert.NotNull(groups);
            Assert.Single(groups);

            foreach (var group in groups)
            {
                Assert.NotNull(group.Members);
                Assert.Equal(2, group.Members.Count);
            }
        }

        [Fact]
        public void DojoRestService_ReturnsInvalidStatusCode_ThrowsException()
        {
            //arrange
            List<Group> groups = new []
            {
                new Group()
                {
                    Members = new []
                    {
                        new Person("foo", Roles.Architekt)
                    }
                    .ToList()
                }
            }
            .ToList();

            //TODO mock interface with to throw exception
            var restService = new DojoRestService();
            var externalService = new ExternalService(restService);

            //act
            externalService.SendGroupsToDojoService(groups);
        }
    }
}