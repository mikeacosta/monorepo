package net.postcore.ocpthings.declarearrays;

import net.postcore.ocpthings.declarearrays.DeclareArrays;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.*;
import static org.junit.jupiter.api.Assertions.*;

class DeclareArraysTest {

    @Test
    void varArray() {
        var arr = DeclareArrays.varArray();
        assertEquals(5, arr.length);
    }

    @Test
    void likeCLang() {
        var list = DeclareArrays.likeCLang();
        assertEquals(2, list.size());
        assertThat(list).hasOnlyElementsOfType(int[].class);
    }
}