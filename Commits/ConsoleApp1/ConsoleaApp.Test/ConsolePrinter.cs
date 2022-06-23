namespace ConsoleaApp.Test
{
    public class ConsolePrinter : IPrinter
    {
        public string ReadLine()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

    }
}