package net.postcore.apilist.cli;

import net.postcore.apilist.cli.service.ApiRetrievalService;
import net.postcore.apilist.cli.service.PublicApi;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.List;

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
        ApiRetrievalService apiRetrievalService = new ApiRetrievalService();

        List<PublicApi> apisToStore = apiRetrievalService.getApisFor(category);
        LOG.info("Retrieved the following {} APIs {}", apisToStore.size(), formattedApis(apisToStore));
    }

    private static String formattedApis(List<PublicApi> apiList) {
        StringBuilder sb = new StringBuilder();
        String newline = System.getProperty("line.separator");

        for (PublicApi api : apiList) {
            sb.append(newline);
            sb.append(api.toString());
        }

        return sb.toString();
    }
}
