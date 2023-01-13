package net.postcore.breweries.cli.service;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import org.apache.commons.validator.routines.UrlValidator;

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

    public boolean isUrlValid() {
        String[] schemes = {"http","https"};
        UrlValidator urlValidator = new UrlValidator(schemes);
        return urlValidator.isValid(website_url);
    }
}
