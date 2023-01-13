package net.postcore.breweries.cli.service;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.*;

class OpenBreweryTest {

    private OpenBrewery getTestOpenBrewery(String url) {
        return new OpenBrewery("reel-brew-co-los-angeles",
                "Reel Brew Co",
                "micro",
                "7037 Laurel Canyon Boulevard",
                "Los Angeles",
                "CA",
                "91605",
                null,
                url);
    }

    @Test
    void validUrlTest() {
        OpenBrewery openBrewery = getTestOpenBrewery("https://www.reelbrew.com");
        assertTrue(openBrewery.isUrlValid());
    }

    @Test
    void invalidUrlTest() {
        OpenBrewery openBrewery = getTestOpenBrewery("ftp://ftp.server.net");
        assertFalse(openBrewery.isUrlValid());
    }

    @ParameterizedTest
    @CsvSource(textBlock = """
            https://www.adoptapet.com/public/apis/pet_list.html, true
            http://theaxolotlapi.netlify.app/, true
            mailto://joe@blow.com, false
            """)
    void isLinkValidParamTest(String link, boolean expected) {
        OpenBrewery openBrewery = getTestOpenBrewery(link);
        assertEquals(expected, openBrewery.isUrlValid());
    }
}