package net.postcore.breweries.server;

import jakarta.ws.rs.*;
import jakarta.ws.rs.core.MediaType;
import net.postcore.breweries.domain.Brewery;
import net.postcore.breweries.repository.BreweryRepository;
import net.postcore.breweries.repository.RepositoryException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.Comparator;
import java.util.stream.Stream;

@Path("/breweries")
public class BreweryResource {

    private static final Logger LOG = LoggerFactory.getLogger(BreweryResource.class);

    private final BreweryRepository breweryRepository;

    public BreweryResource(BreweryRepository breweryRepository) {
        this.breweryRepository = breweryRepository;
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Stream<Brewery> getBreweries() {
        try {
            return breweryRepository
                    .getAllBreweries()
                    .stream()
                    .sorted(Comparator.comparing(Brewery::name));
        } catch (RepositoryException e) {
            LOG.error("Could not retrieve breweries from the database", e);
            throw  new NotFoundException();
        }
    }

    @POST
    @Path("/{id}/notes")
    @Consumes(MediaType.TEXT_PLAIN)
    public void addNotes(@PathParam("id") String api, String notes) {
        breweryRepository.addNotes(api, notes);
    }
}
