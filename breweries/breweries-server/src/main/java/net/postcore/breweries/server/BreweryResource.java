package net.postcore.breweries.server;

import jakarta.ws.rs.GET;
import jakarta.ws.rs.NotFoundException;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.core.MediaType;
import net.postcore.breweries.domain.Brewery;
import net.postcore.breweries.repository.BreweryRepository;
import net.postcore.breweries.repository.RepositoryException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.Comparator;
import java.util.List;

@Path("/breweries")
public class BreweryResource {

    private static final Logger LOG = LoggerFactory.getLogger(BreweryResource.class);

    private final BreweryRepository breweryRepository;

    public BreweryResource(BreweryRepository breweryRepository) {
        this.breweryRepository = breweryRepository;
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Brewery> getBreweries() {
        try {
            return breweryRepository
                    .getAllBreweries()
                    .stream()
                    .sorted(Comparator.comparing(Brewery::name))
                    .toList();
        } catch (RepositoryException e) {
            LOG.error("Could not retrieve breweries from the database", e);
            throw  new NotFoundException();
        }
    }
}
