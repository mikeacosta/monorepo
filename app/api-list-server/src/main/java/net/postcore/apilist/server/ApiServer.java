package net.postcore.apilist.server;

import net.postcore.apilist.repository.ApiRepository;
import org.glassfish.jersey.grizzly2.httpserver.GrizzlyHttpServerFactory;
import org.glassfish.jersey.server.ResourceConfig;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.net.URI;

public class ApiServer {
    private static final Logger LOG = LoggerFactory.getLogger(ApiServer.class);
    private static final String BASE_URI = "http://localhost:8080/";

    public static void main(String[] args) {
        System.out.println("Starting HTTP server...");
        ApiRepository apiRepository = ApiRepository.openApiRepository("./apis.db");
        ResourceConfig resourceConfig = new ResourceConfig().register(new ApiResource(apiRepository));

        GrizzlyHttpServerFactory.createHttpServer(URI.create(BASE_URI), resourceConfig);
    }
}
