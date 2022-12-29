package net.postcore.apilist.cli.service;

import net.postcore.apilist.domain.ApiRecord;
import net.postcore.apilist.repository.ApiRepository;

import java.util.List;
import java.util.Optional;

public class ApiStorageService {

    private final ApiRepository apiRepository;

    public ApiStorageService(ApiRepository apiRepository) {
        this.apiRepository = apiRepository;
    }

    public void storeApis(List<PublicApi> publicApis) {
        for (PublicApi api : publicApis) {
            ApiRecord apiRecord = new ApiRecord(api.API(),
                    api.Description(),
                    api.Auth(),
                    api.HTTPS(),
                    api.Cors(),
                    api.Link(),
                    api.Category(),
                    Optional.empty());
            apiRepository.saveApi(apiRecord);
        }
    }
}
