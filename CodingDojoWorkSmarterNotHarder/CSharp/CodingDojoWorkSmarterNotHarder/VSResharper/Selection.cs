using System.Collections.Generic;
using System.Linq;

namespace CodingDojoWorkSmarterNotHarder.VSResharper
{
    class Selection
    {
        public List<string> DoSomethingSuuuuuuperComplex()
        {
            var list = new List<string>();

            // select the entire block of the check for "if (x.EndsWith("_DUMB"))"

            // select the second "m" in the comments on each line
            foreach (var x in Enumerable.Range(0, 1000).Select(item => $"SomePrefix_{item}_SomeSuffix"))
            {
                if (x.Contains("500"))
                {
                    if (x.EndsWith("_DUMB"))
                    {
                        list.Add("42");
                        /*
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         * A stupid ammount of instructions
                         */
                        list.Add("Yo!");
                    }
                    else
                    {
                        list.Add("43");
                    }
                }
            }

            return list;
        }
    }
}
