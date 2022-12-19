package net.postcore.apilist.cli.service;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.JavaType;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.List;

public class ApiRetrievalService {
    private static final String BASE_URL = "https://api.publicapis.org";

    private static final HttpClient CLIENT = HttpClient
            .newBuilder()
            .followRedirects(HttpClient.Redirect.ALWAYS)
            .build();

    private static final ObjectMapper OBJECT_MAPPER = new ObjectMapper();

    public List<PublicApi> getApisFor(String category) {
        HttpRequest request = HttpRequest
                .newBuilder(URI.create(BASE_URL + "/entries"))
                .GET()
                .build();

        try {
            HttpResponse<String> response = CLIENT.send(request, HttpResponse.BodyHandlers.ofString());
            return switch(response.statusCode()) {
                case 200 -> toPublicApis(response, category);
                case 404 -> List.of();
                default -> throw new RuntimeException("API call failed with status code " + response.statusCode());
            };
        } catch (IOException | InterruptedException e) {
            throw new RuntimeException("Could not call Public APIs API", e);
        }
    }

    private List<PublicApi> toPublicApis(HttpResponse<String> response, String category) throws JsonProcessingException {
        JavaType javaType = OBJECT_MAPPER.getTypeFactory()
                        .constructType(ParentRecord.class);
        ParentRecord parentRecord = OBJECT_MAPPER.readValue(response.body(), javaType);
        List<PublicApi> apiList = parentRecord.entries();
        return apiList.stream()
                .filter(a -> a.Category().equalsIgnoreCase(category))
                .toList();
    }
}
