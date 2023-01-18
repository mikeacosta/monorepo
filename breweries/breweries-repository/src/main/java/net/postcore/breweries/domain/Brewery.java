package net.postcore.breweries.domain;

import java.util.Optional;

public record Brewery(String id,
                      String name,
                      String brewery_type,
                      String street,
                      String city,
                      String state,
                      String postal_code,
                      String phone,
                      String website_url,
                      Optional<String> notes) {

    public Brewery {
        checkValue(id);
        checkValue(name);
        checkValue(brewery_type);
        checkValue(city);
        checkValue(state);
        notes.ifPresent(Brewery::checkValue);
    }

    public static void checkValue(String value) {
        if (value == null || value.isBlank())
            throw new IllegalArgumentException("Value required!");
    }
}
