using Xunit;

namespace GroupBuilder.Test;

public class CsvParserTests
{
    [Fact]
    public void CsvParser_Parses_Person()
    {
        //arrange
        var fileContent = @"John Rambo, Architekt";

        //act
        var person = CsvPersonParser.ParsePerson(fileContent);

        //assert
        Assert.Equal("John Rambo", person.Name);
        Assert.Equal(Roles.Architekt, person.Role);
    }

    [Fact]
    public void CsvParser_Parses_People()
    {
        //arrange
        var fileContent =
            @"John Rambo, Architekt
Enemy of Rambo, Junior";

        var expectedPeople = new[]
        {
            new Person("John Rambo", Roles.Architekt),
            new Person("Enemy of Rambo", Roles.Junior),
        }.ToList();

        //act
        var parsedPeople = CsvPersonParser.Parse(fileContent);

        //assert
        Assert.Equal(2, parsedPeople.Count);

        foreach (var (expectedPerson, parsedPerson) in expectedPeople.Zip(parsedPeople))
        {
            Assert.Equal(expectedPerson.Name, parsedPerson.Name);
            Assert.Equal(expectedPerson.Role, parsedPerson.Role);
        }
    }
}