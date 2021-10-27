using System.Collections.Generic;
using System.Text;

namespace NumberToLCD
{
    /// <summary>
    /// Converts integers for display on an LCD
    ///     _  _     _  _  _  _  _  
    ///  |  _| _||_||_ |_   ||_||_|  
    ///  | |_  _|  | _||_|  ||_| _|  
    /// </summary>
    class NumberToLcdConverterTeamB
    {
        public Dictionary<char, char> MappingDictionary;
        public Dictionary<int, string> NumberDictionary;

        public NumberToLcdConverterTeamB()
        {
            MappingDictionary = new Dictionary<char, char>();
            MappingDictionary.TryAdd('0', ' ');
            MappingDictionary.TryAdd('1', '|');
            MappingDictionary.TryAdd('2', '_');

            NumberDictionary = new Dictionary<int, string>();
            NumberDictionary.TryAdd(0, "020101121");
            NumberDictionary.TryAdd(1, "000010010");
            NumberDictionary.TryAdd(2, "020021120");
            NumberDictionary.TryAdd(3, "020021021");
            NumberDictionary.TryAdd(4, "000121001");
            NumberDictionary.TryAdd(5, "020120021");
        }

        public string IntToString(int i)
        {
            var digits = NumbersIn(i);
            var current = 0;
            var currentDigit = 0;
            var line = 0;


            var result = new StringBuilder();

            for (var j = 0; j < 9 * digits.Length; j++)
            {
                if (j % 3 == 0 && j != 0)
                {
                    current = 0;
                    currentDigit++;
                    currentDigit %= digits.Length;
                    if (currentDigit == 0)
                    {
                        result.Append('\n');
                        line++;
                    }
                }

                var lcd = NumberDictionary[digits[currentDigit]];

                result.Append(MappingDictionary[lcd[(line * 3) + current]]);
                current++;
            }

            return result.ToString();
        }


        public int[] NumbersIn(int value)
        {
            var numbers = new Stack<int>();

            for (; value > 0; value /= 10)
                numbers.Push(value % 10);

            return numbers.ToArray();
        }
    }
}