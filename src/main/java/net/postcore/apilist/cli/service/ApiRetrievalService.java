package net.postcore.apilist.cli.service;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public class ApiRetrievalService {
    private static final String BASE_URL = "https://api.publicapis.org";

    private static final HttpClient CLIENT = HttpClient.newHttpClient();

    public String getApisFor(String category) {
        HttpRequest request = HttpRequest
                .newBuilder(URI.create(BASE_URL + "/entries"))
                .GET()
                .build();

        try {
            HttpResponse<String> response = CLIENT.send(request, HttpResponse.BodyHandlers.ofString());
            return response.body();
        } catch (IOException | InterruptedException e) {
            throw new RuntimeException("Could not call Public APIs API", e);
        }
    }
}
