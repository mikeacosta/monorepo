package net.postcore.apilist.cli.service;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.*;

class PublicApiTest {

    private PublicApi getTestApi(String link) {
        return new PublicApi("test API",
                "test desc",
                "",
                link.startsWith("https"),
                "yes",
                link,
                "test");
    }

    @Test
    void validLinkTest() {
        PublicApi publicApi = getTestApi("https://www.baseurl.com");
        assertTrue(publicApi.isLinkValid());
    }

    @Test
    void invalidLinkTest() {
        PublicApi publicApi = getTestApi("ftp://ftp.server.net");
        assertFalse(publicApi.isLinkValid());
    }

    @ParameterizedTest
    @CsvSource(textBlock = """
            https://www.adoptapet.com/public/apis/pet_list.html, true
            http://theaxolotlapi.netlify.app/, true
            mailto://joe@blow.com, false
            """)
    void isLinkValidParamTest(String link, boolean expected) {
        PublicApi publicApi = getTestApi(link);
        assertEquals(expected, publicApi.isLinkValid());
    }
}