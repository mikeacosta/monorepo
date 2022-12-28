package net.postcore.apilist.server;

import jakarta.ws.rs.GET;
import jakarta.ws.rs.Path;
import net.postcore.apilist.domain.ApiRecord;
import net.postcore.apilist.repository.ApiRepository;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.stream.Collectors;

@Path("apis")
public class ApiResource {
    private static final Logger LOG = LoggerFactory.getLogger(ApiResource.class);

    private ApiRepository apiRepository;

    public ApiResource(ApiRepository apiRepository) {
        this.apiRepository = apiRepository;
    }

    @GET
    public String getApis() {
        return apiRepository
                .getAllApis()
                .stream()
                .map(ApiRecord::toString)
                .collect(Collectors.joining(", "));
    }
}
