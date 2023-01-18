package net.postcore.breweries.repository;

import net.postcore.breweries.domain.Brewery;

import java.util.List;

public interface BreweryRepository {

    void saveBrewery(Brewery brewery);

    List<Brewery> getAllBreweries();

    void addNotes(String id, String notes);

    static BreweryRepository openBreweryRepository(String databaseFile) {
        return new BreweryJdbcRepository(databaseFile);
    }
}
