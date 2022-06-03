using System.Xml.Serialization;

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

    class Printer
    {
        public List<string> Lines = new List<string>();

        public void WriteLine(string text)
        {
            Lines.Add(text);
        }

        internal string ReadLine()
        {
            return Lines.Last();
        }
    }  
    
    class ConsolePrinter 
    {
        private List<string> Lines = new List<string>();

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }

    internal class GroupBuilder
    {
        private Printer _printer;
        
        public GroupBuilder(Printer printer)
        {
            _printer = printer;
        }

        public IEnumerable<char> BuilderMode { get; internal set; }

        internal void PrintGroupBuildingQuestion()
        {
            _printer.WriteLine("Soll nach Gruppenanzahl oder Mitgliederanzahl die Gruppen gebildet werden?");
        }

        internal void ReadBuilderMode()
        {
           BuilderMode =  _printer.ReadLine();
        }
    }
}