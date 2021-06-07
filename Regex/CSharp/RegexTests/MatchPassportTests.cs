using System.Text.RegularExpressions;
using Xunit;

namespace RegexTests
{
    //Examples taken from: https://adventofcode.com/2020/day/4
    public class MatchPassportTests
    {
        private const string RegexExpression =
            "";

        private readonly Regex _matcher = new Regex(RegexExpression);

        [Fact]
        public void AllFields_Match()
        {
            const string passport = "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\nbyr:1937 iyr:2017 cid:147 hgt:183cm";

            var matches = _matcher.Matches(passport);

            Assert.Single(matches);
        }

        [Fact]
        public void HgtFielMissing_NoMatch()
        {
            const string passport = "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884\nhcl:#cfa07d byr:1929";
            string line = $"x = 1; ${passport}";

            var matches = _matcher.Matches(line);

            Assert.Empty(matches);
        }

        [Fact]
        public void CidMissing_Match()
        {
            const string passport = "hcl:#ae17e1 iyr:2013\neyr:2024\necl:brn pid:760753108 byr:1931\nhgt:179cm";

            var matches = _matcher.Matches(passport);

            Assert.Single(matches);
        }

        [Fact]
        public void TwoFieldsMissing_NoMatch()
        {
            const string passport = "hcl:#cfa07d eyr:2025 pid:166559648\niyr:2011 ecl:brn hgt:59in";

            var matches = _matcher.Matches(passport);

            Assert.Empty(matches);
        }
    }
}