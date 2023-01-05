package net.postcore.apilist.server;

import net.postcore.apilist.repository.ApiRepository;
import net.postcore.apilist.utils.PropertiesFileReader;
import org.glassfish.jersey.grizzly2.httpserver.GrizzlyHttpServerFactory;
import org.glassfish.jersey.server.ResourceConfig;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.bridge.SLF4JBridgeHandler;

import java.io.IOException;
import java.net.URI;
import java.util.logging.LogManager;

public class ApiServer {

    static {
        LogManager.getLogManager().reset();
        SLF4JBridgeHandler.install();
    }

    private static final Logger LOG = LoggerFactory.getLogger(ApiServer.class);

    public static void main(String[] args) throws IOException {
        String baseUri = PropertiesFileReader.getValue("base-uri");
        String databaseFile = PropertiesFileReader.getValue("api-list.database");

        LOG.info("Starting HTTP server with database {}", databaseFile);
        ApiRepository apiRepository = ApiRepository.openApiRepository(databaseFile);
        ResourceConfig resourceConfig = new ResourceConfig().register(new ApiResource(apiRepository));

        GrizzlyHttpServerFactory.createHttpServer(URI.create(baseUri), resourceConfig);
    }
}
