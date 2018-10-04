using Xunit;

namespace NumbersToString
{
	public class NumberToEnglishWordsConverterTests
	{
		private readonly NumberToEnglishWordsConverter _converter;

		public NumberToEnglishWordsConverterTests()
		{
			_converter = new NumberToEnglishWordsConverter();
		}

		[Theory]
		[InlineData(1, "one")]
		public void SingleDigitNumber(int number, string expectedWords)
		{
			var actualWords = _converter.Convert(number);

			Assert.Equal(expectedWords, actualWords);
		}
	}
}
