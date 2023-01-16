package net.postcore.breweries.cli.service;

import net.postcore.breweries.domain.Brewery;
import net.postcore.breweries.repository.BreweryRepository;

import java.util.List;

public class BreweryStorageService {

    private final BreweryRepository breweryRepository;

    public BreweryStorageService(BreweryRepository breweryRepository) {
        this.breweryRepository = breweryRepository;
    }

    public void storeOpenBreweries(List<OpenBrewery> openBreweries) {
        for (OpenBrewery openBrewery : openBreweries) {
            Brewery brewery = new Brewery(openBrewery.id(),
                    openBrewery.name(),
                    openBrewery.brewery_type(),
                    openBrewery.street(),
                    openBrewery.city(),
                    openBrewery.state(),
                    openBrewery.postal_code(),
                    openBrewery.phone(),
                    openBrewery.website_url());
            breweryRepository.saveBrewery(brewery);
        }
    }
}
