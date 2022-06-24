namespace ConsoleaApp.Test
{
    internal class GroupBuilder
    {
        private readonly IPrinter _printer;
        
        public GroupBuilder(IPrinter printer)
        {
            _printer = printer;
        }

        public string BuilderMode { get; private set; } = String.Empty;

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