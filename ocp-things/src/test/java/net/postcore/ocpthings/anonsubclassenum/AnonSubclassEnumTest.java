package net.postcore.ocpthings.anonsubclassenum;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;
import static org.assertj.core.api.Assertions.*;

@DisplayName("Creating anonymous subclasses in an enum definition")
class AnonSubclassEnumTest {

    @Test
    void whenIsTheNextSpringOne() {
        var expected = "The next SpringOne Essentials conference will be in United States in 2023.";
        assertEquals(expected, AnonSubclassEnum.whenIsTheNextSpringOne());
    }

    @Test
    void whenIsTheNextDevoxxUk() {
        var expected = "The next Devoxx UK conference will be in United Kingdom in 2023.";
        assertEquals(expected, AnonSubclassEnum.whenIsTheNextDevoxxUk());
    }

    @Test
    void whenIsTheNextJavaWorld() {
        var expected = "The next Java World conference will be in Palau in 2024. It's awesome!";
        assertEquals(expected, AnonSubclassEnum.whenIsTheNextJavaWorld());
    }
}