package net.postcore.breweries.cli;

import net.postcore.breweries.cli.service.BreweryRetrievalService;
import net.postcore.breweries.cli.service.BreweryStorageService;
import net.postcore.breweries.cli.service.OpenBrewery;
import net.postcore.breweries.repository.BreweryRepository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.List;

public class BreweryRetriever {

    private static final Logger LOG = LoggerFactory.getLogger(BreweryRetriever.class);

    public static void main(String[] args) {
        LOG.info("BreweryRetriever running...");
        if (args.length == 0) {
            LOG.warn("First argument should be a city.");
            return;
        }

        try {
            retrieveBreweries(args[0]);
        } catch (Exception e) {
            LOG.error("Unexpected error!", e);
        }
    }

    private static void retrieveBreweries(String city) {
        LOG.info("Retrieving breweries located in {}", city);
        BreweryRetrievalService breweryRetrievalService = new BreweryRetrievalService();
        BreweryRepository breweryRepository = BreweryRepository.openBreweryRepository("./breweries.db");
        BreweryStorageService breweryStorageService = new BreweryStorageService(breweryRepository);

        List<OpenBrewery> breweriesToStore = breweryRetrievalService.getBreweriesFor(city)
                .stream()
                .filter(b -> !b.brewery_type().equals("closed"))
                .toList();
        LOG.info("Retrieved the following {} breweries: {}", breweriesToStore.size(), breweriesToStore);
        breweryStorageService.storeOpenBreweries(breweriesToStore);
        LOG.info("Breweries successfully stored");
    }
}
