package net.postcore.breweries.cli.service;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.Arrays;
import java.util.List;

public class BreweryRetrievalService {

    private final static String BREW_URI = "https://api.openbrewerydb.org/breweries?by_city=%s&per_page=50";

    private final static HttpClient CLIENT = HttpClient
            .newBuilder()
            .followRedirects(HttpClient.Redirect.ALWAYS)
            .build();

    private static final ObjectMapper OBJECT_MAPPER = new ObjectMapper();

    public List<OpenBrewery> getBreweriesFor(String city) {
        HttpRequest request = HttpRequest
                .newBuilder(URI.create(BREW_URI.formatted(city)))
                .GET()
                .build();

        try {
            HttpResponse<String> response = CLIENT.send(request, HttpResponse.BodyHandlers.ofString());
            return switch(response.statusCode()) {
                case 200 -> toOpenBreweries(response, city);
                case 404 -> List.of();
                default -> throw new RuntimeException("Open Brewery DB API call failed with status code " + response.statusCode());
            };
        } catch (IOException | InterruptedException e) {
            throw new RuntimeException("Could not call Open Brewery DB API", e);
        }
    }

    private List<OpenBrewery> toOpenBreweries(HttpResponse<String> response, String city) throws JsonProcessingException {
        OpenBrewery[] openBreweries = OBJECT_MAPPER.readValue(response.body(), OpenBrewery[].class);
        List<OpenBrewery> breweryList = Arrays.asList(openBreweries);

        return breweryList.stream()
                .filter(a -> a.city().equalsIgnoreCase(city))
                .toList();
    }
}
