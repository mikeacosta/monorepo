package net.postcore.ocpthings.dividebyzero;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;
import static org.assertj.core.api.Assertions.*;

@DisplayName("Division by zero doesn't always cause an ArithmeticException")
class DivideByZeroTest {

    @Test
    @DisplayName("divideInt() should throw an ArithmeticException when trying to divide by zero")
    void divideInt() {
        final var dividend = 50;
        final var divisor = 0;

        assertThrows(ArithmeticException.class, () -> DivideByZero.divide(dividend, divisor));
    }

    @Test
    @DisplayName("divideFloat() should throw an ArithmeticException when trying to divide by zero")
    void divideFloat() {
        final var dividend = 50f;
        final var divisor = 0f;

        assertThrows(ArithmeticException.class, () -> DivideByZero.divide(dividend, divisor));
    }

    @Test
    @DisplayName("divideDouble() should throw an ArithmeticException when trying to divide by zero")
    void divideDouble() {
        final var dividend = 50.0;
        final var divisor = 0.0;

        assertThrows(ArithmeticException.class, () -> DivideByZero.divide(dividend, divisor));
    }
}