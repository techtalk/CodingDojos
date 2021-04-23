using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace RegexTests
{
    //Examples taken from: https://www.hackerrank.com/challenges/ide-identifying-comments/problem
    public class MatchCommentsTests
    {
        private const string RegexExpression =
            "";

        private readonly Regex _matcher = new Regex(RegexExpression);

        [Fact]
        public void MatchSingleLineComment()
        {
            const string comment = "// this is a single line comment";

            var matches = _matcher.Matches(comment);

            Assert.Single(matches);
            Assert.Equal(comment, matches[0].Value);
        }

        [Fact]
        public void MatchSingleLineCommentAfterCode()
        {
            const string comment = "// a single line comment after code";
            string line = $"x = 1; ${comment}";

            var matches = _matcher.Matches(line);

            Assert.Single(matches);
            Assert.Equal(comment, matches[0].Value);
        }

        [Fact]
        public void MatchMulitLineCommentInSingleLine()
        {
            const string comment = "/* This is one way of writing comments */";

            var matches = _matcher.Matches(comment);

            Assert.Single(matches);
            Assert.Equal(comment, matches[0].Value);
        }

        [Fact]
        public void MatchMulitLineComment()
        {
            const string comment = "/* This is a multiline \n  comment. These can often\n   be useful*/";

            var matches = _matcher.Matches(comment);

            Assert.Single(matches);
            Assert.Equal(comment, matches[0].Value);
        }


        [Fact]
        public void ComplexTest()
        {
            string[] comments = {"// my  program in C++", "/** playing around in\na new programming language **/", "//use cout"};
            string lines =
                $"{comments[0]}\n\n#include <iostream>\n{comments[1]}\nusing namespace std;\n\nint main ()\n{{\n cout << \"Hello World\";\n  cout << \"I'm a C++ program\"; {comments[2]}\n  return 0;\n}}";

            var matches = _matcher.Matches(lines);

            Assert.Equal(3, matches.Count);
            Assert.Equal(comments, matches.ToArray().Select(m => m.Value));
        }

        [Fact]
        public void BonusChallenge()
        {
            string[] comments = {"/* \" */", "/*\"hello\"*/", "// symbol \" for testing purposes"};
            string lines =
                $"{comments[0]} string z = {comments[1]}\"test\";\n      char f2 = '\\\"'; {comments[2]}\n      Console.WriteLine(\"/*dfsdf*////****/**//**Hello, world!\\\\\");";

            var matches = _matcher.Matches(lines);

            Assert.Equal(3, matches.Count);
            Assert.Equal(comments, matches.ToArray().Select(m => m.Value));
        }
    }
}