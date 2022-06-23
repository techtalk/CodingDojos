namespace ConsoleaApp.Test
{
    public class GroupBuilderTest
    {
        [Fact]
        public void PrintGroupBuildingQuestion_LastLineIsExpectedQuestion()
        {
            Printer printer = new Printer();
            var groupBuilder = new GroupBuilder(printer);

            groupBuilder.PrintGroupBuildingQuestion();
           
            Assert.Equal("Soll nach Gruppenanzahl oder Mitgliederanzahl die Gruppen gebildet werden?", printer.Lines.Last());
        }

        [Fact]
        public void ReadBuilderMode_Gruppe_BuilderMode()
        {
            Printer printer = new Printer();
            var groupBuilder = new GroupBuilder(printer);

            printer.WriteLine("Gruppe");

            groupBuilder.ReadBuilderMode();
           
            Assert.Equal("Gruppe", groupBuilder.BuilderMode);
        }

    }
}