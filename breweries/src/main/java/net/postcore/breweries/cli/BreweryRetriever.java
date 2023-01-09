package net.postcore.breweries.cli;

import net.postcore.breweries.cli.service.BreweryRetrievalService;
import net.postcore.breweries.cli.service.OpenBrewery;
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

        List<OpenBrewery> breweriesToStore = breweryRetrievalService.getBreweriesFor(city);
        // TODO: filter out closed breweries (brewery_type = 'closed')
        LOG.info("Retrieved the following {} breweries: {}", breweriesToStore.size(), breweriesToStore);
    }
}
