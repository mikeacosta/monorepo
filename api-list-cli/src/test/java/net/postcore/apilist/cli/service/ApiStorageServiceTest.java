package net.postcore.apilist.cli.service;

import net.postcore.apilist.domain.ApiRecord;
import net.postcore.apilist.repository.ApiRepository;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class ApiStorageServiceTest {

    @Test
    void storeApis() {
        ApiRepository repository = new FakeApiRepository();
        ApiStorageService apiStorageService = new ApiStorageService(repository);
        PublicApi publicApi = new PublicApi("test API",
                "test desc",
                "",
                true,
                "yes",
                "https://my.api.com/path",
                "test");
        apiStorageService.storeApis(List.of(publicApi));

        ApiRecord expected = new ApiRecord("test API",
                "test desc",
                "",
                true,
                "yes",
                "https://my.api.com/path",
                "test");
        assertEquals(List.of(expected), repository.getAllApis());
    }

    static class FakeApiRepository implements ApiRepository {

        private final List<ApiRecord> apiRecords = new ArrayList<ApiRecord>();

        @Override
        public void saveApi(ApiRecord apiRecord) {
            apiRecords.add(apiRecord);
        }

        @Override
        public List<ApiRecord> getAllApis() {
            return apiRecords;
        }
    }
}