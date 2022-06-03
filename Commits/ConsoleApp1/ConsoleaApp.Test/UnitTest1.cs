using System.Xml.Serialization;

namespace ConsoleaApp.Test
{
    public class UnitTest1
    {
        [Fact]
        public void GetQuestionIfGroupCountOrMemberCountGroupBuilding()
        {
            Printer printer = new Printer();
            var groupBuilder = new GroupBuilder(printer);
            groupBuilder.PrintGroupBuildingQuestion();
           
            Assert.Equal("Soll nach Gruppenanzahl oder Mitgliederanzahl die Gruppen gebildet werden?", printer.Lines.Last());
        }


    }

    class Printer
    {
        public List<string> Lines = new List<string>();

        public void WriteLine(string text)
        {
            Lines.Add(text);
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
        public GroupBuilder(Printer printer)
        {
        }

        internal void PrintGroupBuildingQuestion()
        {
            throw new NotImplementedException();
        }
    }
}