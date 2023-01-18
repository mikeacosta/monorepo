package net.postcore.breweries.cli.service;

import net.postcore.breweries.domain.Brewery;
import net.postcore.breweries.repository.BreweryRepository;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class BreweryStorageServiceTest {

    @Test
    void storeOpenBreweries() {
        BreweryRepository repository = new FakeBreweryRepository();
        BreweryStorageService breweryStorageService = new BreweryStorageService(repository);

        OpenBrewery openBrewery = new OpenBrewery("reel-brew-co-los-angeles",
                "Reel Brew Co",
                "micro",
                "7037 Laurel Canyon Boulevard",
                "Los Angeles",
                "CA",
                "91605",
                null,
                "https://www.reelbrew.com");
        breweryStorageService.storeOpenBreweries(List.of(openBrewery));

        assertEquals("Reel Brew Co", repository.getAllBreweries().get(0).name());
    }

    static class FakeBreweryRepository implements BreweryRepository {

        private final List<Brewery> breweries = new ArrayList<>();

        @Override
        public void saveBrewery(Brewery brewery) {
            breweries.add(brewery);
        }

        @Override
        public List<Brewery> getAllBreweries() {
            return breweries;
        }

        @Override
        public void addNotes(String id, String notes) {
            throw new UnsupportedOperationException();
        }
    }
}