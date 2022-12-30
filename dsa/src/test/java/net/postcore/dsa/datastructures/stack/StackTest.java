package net.postcore.dsa.datastructures.stack;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class StackTest {

    Stack stack;

    @BeforeEach
    void setUp() {
        stack = new StackImpl(10);
    }

    @Test
    public void peekTest() {
        stack.push(10);
        stack.push(100);
        stack.push(44);
        stack.pop();
        int value = stack.peek();

        assertEquals(value, 100);
    }

    @Test
    public void popTest() {
        stack.push(10);
        stack.push(100);
        stack.push(44);
        stack.peek();
        int value = stack.pop();

        assertEquals(value, 44);
    }

    @Test
    void popFail() {
        assertThrows(IllegalStateException.class, () ->
            stack.pop()
        );
    }
}