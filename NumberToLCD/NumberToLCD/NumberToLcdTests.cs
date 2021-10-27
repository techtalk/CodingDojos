using System;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace NumberToLCD
{
    //https://codingdojo.org/kata/NumberToLCD/
    [UseReporter(typeof(DiffReporter))]
    public class NumberToLcdTests
    {
        [Fact]
        public void Number1()
        {
            string testString = new NumberToLcdConverterTeamA().IntToString(1);

            Approvals.Verify(testString);
        }

        [Fact]
        public void Number2()
        {
            string testString = new NumberToLcdConverterTeamA().IntToString(2);

            Approvals.Verify(testString);
        }

        [Fact]
        public void Number35()
        {
            string testString = new NumberToLcdConverterTeamA().IntToString(35);

            Approvals.Verify(testString);
        }

        [Fact]
        public void Number94613546()
        {
            string testString = new NumberToLcdConverterTeamA().IntToString(94613546);

            Approvals.Verify(testString);
        }

        [Fact]
        public void NumberMinus7()
        {
            string testString = new NumberToLcdConverterTeamA().IntToString(-7);

            Approvals.Verify(testString);
        }
    }
}
