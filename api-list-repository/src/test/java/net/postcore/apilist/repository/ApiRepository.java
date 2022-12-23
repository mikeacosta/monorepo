package net.postcore.apilist.repository;

import net.postcore.apilist.domain.ApiRecord;

import java.util.List;

public interface ApiRepository {

    void saveApi(ApiRecord apiRecord);

    List<ApiRecord> getAllApis();
}
