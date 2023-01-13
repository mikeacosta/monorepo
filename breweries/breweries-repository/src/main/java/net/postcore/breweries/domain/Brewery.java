package net.postcore.breweries.domain;

public record Brewery(String id,
                      String name,
                      String brewery_type,
                      String street,
                      String city,
                      String state,
                      String postal_code,
                      String phone,
                      String website_url) {

    public Brewery {
        checkValue(id);
        checkValue(name);
        checkValue(brewery_type);
        checkValue(city);
        checkValue(state);
    }

    public static void checkValue(String value) {
        if (value == null || value.isBlank())
            throw new IllegalArgumentException("Value required!");
    }
}
