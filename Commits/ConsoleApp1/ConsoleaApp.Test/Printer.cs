namespace ConsoleaApp.Test
{
    public class Printer : IPrinter
    {
        public List<string> Lines = new List<string>();

        public void WriteLine(string text)
        {
            Lines.Add(text);
        }

        public string ReadLine()
        {
            return Lines.Last();
        }
    }
}