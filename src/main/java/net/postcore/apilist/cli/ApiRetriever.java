package net.postcore.apilist.cli;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class ApiRetriever {
    private static final Logger LOG = LoggerFactory.getLogger(ApiRetriever.class);

    public static void main(String[] args) {
        LOG.info("ApiRetriever starting");
        if (args.length == 0) {
            LOG.warn("First argument should be API category.");
            return;
        }

        try {
            retrieveApis(args[0]);
        } catch (Exception e) {
            LOG.error("Unexpected error", e);
        }
    }

    private static void retrieveApis(String category) {
        LOG.info("Retrieving APIs for category \"{}\"", category);
    }
}
