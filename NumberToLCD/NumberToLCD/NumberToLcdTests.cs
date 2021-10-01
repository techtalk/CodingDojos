using System;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace NumberToLCD
{
    public class NumberToLcdTests
    {
        [Fact]
        public void Number1()
        {
            const string expectedOutput = "";

            string testString = new NumberToLcdConverter().IntToString(1);

            Assert.Equal(expectedOutput, testString);
        }
        [Fact]
        public void Number35()
        {
            string testString = new NumberToLcdConverter().IntToString(35);

        }

        [Fact]
        public void NumberMinus7()
        {
            string testString = new NumberToLcdConverter().IntToString(-7);

        }
    }
}
