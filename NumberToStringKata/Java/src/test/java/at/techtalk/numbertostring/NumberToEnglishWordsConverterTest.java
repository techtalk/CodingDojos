package at.techtalk.numbertostring;

import junitparams.JUnitParamsRunner;
import junitparams.Parameters;
import org.junit.Test;
import org.junit.runner.RunWith;

import static org.junit.Assert.*;

@RunWith(JUnitParamsRunner.class)
public class NumberToEnglishWordsConverterTest {

    private final NumberToEnglishWordsConverter converter;

    public NumberToEnglishWordsConverterTest() {
        converter = new NumberToEnglishWordsConverter();
    }

    @Test
    @Parameters({"1, one"})
    public void singleDigitNumber(int number, String expectedWords) {
        final String actualWords = converter.convert(number);

        assertEquals(expectedWords, actualWords);
    }

}