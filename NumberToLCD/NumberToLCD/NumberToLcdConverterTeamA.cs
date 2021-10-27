using System.Collections.Generic;
using System.Linq;

namespace NumberToLCD
{
    /// <summary>
    /// Converts integers for display on an LCD
    ///     _  _     _  _  _  _  _  
    ///  |  _| _||_||_ |_   ||_||_|  
    ///  | |_  _|  | _||_|  ||_| _|  
    /// </summary>
    class NumberToLcdConverterTeamA
    {
        private readonly IDictionary<char, string[]> _numbers = new Dictionary<char, string[]>
        {
            {'1', new []{Rows[0], Rows[1], Rows[1]} },
            {'2', new []{Rows[4], Rows[2], Rows[3]} },
            {'3', new []{Rows[4], Rows[2], Rows[2]} },
            {'4', new []{Rows[0], Rows[5], Rows[1]} },
            {'5', new []{Rows[4], Rows[3], Rows[2]} },
            {'6', new []{Rows[4], Rows[3], Rows[5]} },
            {'7', new []{Rows[4], Rows[1], Rows[1]} },
            {'8', new []{Rows[4], Rows[5], Rows[5]} },
            {'9', new []{Rows[4], Rows[5], Rows[2]} },
            {'0', new []{Rows[4], Rows[6], Rows[5]} },
            {'-', new []{Rows[0], Rows[7], Rows[0]} }
            
        };

        private static readonly IDictionary<int, string> Rows = new Dictionary<int, string>
        {
            {0, "   "},
            {1, "  |" },
            {2, " _|" },
            {3, "|_ " },
            {4, " _ " },
            {5, "|_|" },
            {6, "| |" },
            {7, "  _" },
        };

        public string IntToString(int inputNumber)
        {
            var rows = new[] {"", "", ""};

            foreach (var number in inputNumber.ToString())
            {
                rows[0] += _numbers[number][0];
                rows[1] += _numbers[number][1];
                rows[2] += _numbers[number][2];
            }

            return string.Join("\n", rows);
        }
    }
}
