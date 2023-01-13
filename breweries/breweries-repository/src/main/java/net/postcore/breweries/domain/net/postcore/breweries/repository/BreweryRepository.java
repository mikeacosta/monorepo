package net.postcore.breweries.domain.net.postcore.breweries.repository;

import net.postcore.breweries.domain.Brewery;

import java.util.List;

public interface BreweryRepository {

    void saveBrewery(Brewery brewery);

    List<Brewery> getAllBreweries();
}
