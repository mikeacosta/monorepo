package net.postcore.ocpthings.switchstatement;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.assertj.core.api.Assertions.assertThat;

class SwitchExpressionTest {

    @ParameterizedTest
    @DisplayName("getTalkRatingDescription() should return the right description for the given talk rating")
    @CsvSource({"a,great",
            "b,good",
            "c,fair",
            "d,fair",
            "e,poor",
            "f,poor"})
    void getRatingDescription(String rating, String expectedDescription) {
        String actualDescription = SwitchExpression.getRatingDescription(rating.charAt(0));
        assertThat(actualDescription).isEqualTo(expectedDescription);
    }
}