package net.postcore.breweries.server;

import jakarta.ws.rs.GET;
import jakarta.ws.rs.Path;
import net.postcore.breweries.domain.Brewery;
import net.postcore.breweries.repository.BreweryRepository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.stream.Collectors;

@Path("/breweries")
public class BreweryResource {

    private static final Logger LOG = LoggerFactory.getLogger(BreweryResource.class);

    private final BreweryRepository breweryRepository;

    public BreweryResource(BreweryRepository breweryRepository) {
        this.breweryRepository = breweryRepository;
    }

    @GET
    public String getBreweries() {
        return breweryRepository
                .getAllBreweries()
                .stream()
                .map(Brewery::toString)
                .collect(Collectors.joining(", "));
    }
}
