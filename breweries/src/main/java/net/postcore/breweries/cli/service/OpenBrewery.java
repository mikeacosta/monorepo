package net.postcore.breweries.cli.service;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public record OpenBrewery(String id,
                          String name,
                          String brewery_type,
                          String street,
                          String city,
                          String state,
                          String postal_code,
                          String phone,
                          String website_url) {
}
