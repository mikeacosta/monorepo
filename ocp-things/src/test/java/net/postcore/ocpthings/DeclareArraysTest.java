package net.postcore.ocpthings;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class DeclareArraysTest {

    @Test
    void varArray() {
        var arr = DeclareArrays.varArray();
        assertEquals(5, arr.length);
    }

    @Test
    void likeCLang() {
        var arr = DeclareArrays.likeCLang();
        assertEquals(2, arr.size());
    }
}