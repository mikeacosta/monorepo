package net.postcore.apilist.server;

import jakarta.ws.rs.*;
import jakarta.ws.rs.core.MediaType;
import net.postcore.apilist.domain.ApiRecord;
import net.postcore.apilist.repository.ApiRepository;
import net.postcore.apilist.repository.RepositoryException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.List;
import java.util.stream.Stream;

import static java.util.Comparator.comparing;

@Path("apis")
public class ApiResource {
    private static final Logger LOG = LoggerFactory.getLogger(ApiResource.class);

    private ApiRepository apiRepository;

    public ApiResource(ApiRepository apiRepository) {
        this.apiRepository = apiRepository;
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Stream<ApiRecord> getApis() {
        try {
            return apiRepository
                    .getAllApis()
                    .stream()
                    .sorted(comparing(ApiRecord::api));
        } catch (RepositoryException e) {
            LOG.error("Could not retrieve APIs from the database", e);
            throw new NotFoundException();
        }
    }

    @POST
    @Path("/{api}/notes")
    @Consumes(MediaType.TEXT_PLAIN)
    public void addNotes(@PathParam("api") String api, String notes) {
        apiRepository.addNotes(api, notes);
    }
}
