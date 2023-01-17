package net.postcore.breweries.server;

import net.postcore.breweries.repository.BreweryRepository;
import net.postcore.breweries.utils.PropertiesFileReader;
import org.glassfish.jersey.grizzly2.httpserver.GrizzlyHttpServerFactory;
import org.glassfish.jersey.server.ResourceConfig;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.net.URI;

public class BreweryServer {

    private static final Logger LOG = LoggerFactory.getLogger(BreweryServer.class);

    public static void main(String[] args) throws IOException {
        String baseUri = PropertiesFileReader.getValue("base-uri");
        String databaseFile = PropertiesFileReader.getValue("breweries.database");

        LOG.info("Starting HTTP server with database {}", databaseFile);
        BreweryRepository breweryRepository = BreweryRepository.openBreweryRepository(databaseFile);
        ResourceConfig resourceConfig = new ResourceConfig().register(new BreweryResource(breweryRepository));

        GrizzlyHttpServerFactory.createHttpServer(URI.create(baseUri), resourceConfig);
    }
}
