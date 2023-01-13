package net.postcore.breweries.domain;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertThrows;

class BreweryTest {

    @Test
    void rejectNullComponents() {
        assertThrows(IllegalArgumentException.class, () ->
                new Brewery(null, null, null, null, null, null, null, null, null));

    }

}