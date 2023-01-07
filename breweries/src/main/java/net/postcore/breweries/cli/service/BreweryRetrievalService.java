package net.postcore.breweries.cli.service;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public class BreweryRetrievalService {

    private final static String BREW_URI = "https://api.openbrewerydb.org/breweries?by_city=%s&per_page=50";

    private final static HttpClient CLIENT = HttpClient
            .newBuilder()
            .followRedirects(HttpClient.Redirect.ALWAYS)
            .build();

    public String getBreweriesFor(String city) {
        HttpRequest request = HttpRequest
                .newBuilder(URI.create(BREW_URI.formatted(city)))
                .GET()
                .build();

        try {
            HttpResponse<String> response = CLIENT.send(request, HttpResponse.BodyHandlers.ofString());
            return switch(response.statusCode()) {
                case 200 -> response.body();
                case 404 -> "";
                default -> throw new RuntimeException("Open Brewery DB API call failed with status code " + response.statusCode());
            };
        } catch (IOException | InterruptedException e) {
            throw new RuntimeException("Could not call Open Brewery DB API", e);
        }
    }
}
