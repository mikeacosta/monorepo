package net.postcore.breweries.cli;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

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
    }
}
