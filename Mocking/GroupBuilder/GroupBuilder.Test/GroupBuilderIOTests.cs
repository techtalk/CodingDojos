using Xunit;

namespace GroupBuilder.Test;

public class GroupBuilderIOTests
{
    [Theory]
    [InlineData("g", GroupMode.Group)]
    [InlineData("m", GroupMode.Person)]
    public void GroupBuilderIO_ReadBuilderModeWorks(string builderModeInput, GroupMode expectedGroupMode)
    {
        //arrange
        TextReader reader = new StringReader(builderModeInput);
        TextWriter writer = new StringWriter();

        var io = new GroupBuilderIO(reader, writer);

        //act
        io.ReadBuilderMode();

        //assert
        Assert.Equal(expectedGroupMode, io.Mode);
    }

    //TODO add tests for other Read and Write IO
}