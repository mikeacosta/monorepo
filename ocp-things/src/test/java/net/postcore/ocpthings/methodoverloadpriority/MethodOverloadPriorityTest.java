package net.postcore.ocpthings.methodoverloadpriority;

import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

import static org.assertj.core.api.Assertions.assertThat;

@DisplayName("Method overloading priorities are all over the place")
class MethodOverloadPriorityTest {
    private final PrintStream standardOut = System.out;
    private final ByteArrayOutputStream outputStreamCaptor = new ByteArrayOutputStream();

    @BeforeEach
    void setUp() {
        System.setOut(new PrintStream(outputStreamCaptor));
    }

    @Test
    @DisplayName("printSum() should print 'In printSum(Integer)' when int arguments are passed, because boxing is prioritised over widening, which in turn is prioritised over varargs.")
    void printSumBoxedInteger() {
        int a = 32;
        int b = 10;

        MethodOverloadPriority.printSum(a, b);

        assertThat(outputStreamCaptor.toString()).isEqualTo(
                String.format("In printSum(Integer): %d%n", a + b));
    }

    @Test
    @DisplayName("printSum() should print 'In printSum(int...)' when int arguments are passed, because varargs are prioritised over boxing, which in turn is prioritised over widening.")
    void printSumIntVarArgs() {
        int a = 32;
        int b = 10;

        MethodOverloadPriority.printSum(a, b);

        assertThat(outputStreamCaptor.toString()).isEqualTo(
                String.format("In printSum(int...): %d%n", a + b));
    }

    @Test
    @DisplayName("printSum() should print 'In printSum(double)' when int arguments are passed, because widening is prioritised over boxing, which in turn is prioritised over varargs.")
    void printSumDouble() {
        int a = 32;
        int b = 10;

        MethodOverloadPriority.printSum(a, b);

        assertThat(outputStreamCaptor.toString()).isEqualTo(
                String.format("In printSum(double): %f%n", (double) a + b));
    }

    @AfterEach
    void tearDown() {
        System.setOut(standardOut);
    }
}