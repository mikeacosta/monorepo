package net.postcore.apilist.domain;

public record ApiRecord(String api, String description, String auth, Boolean https, String cors, String link, String category) {

    public ApiRecord {
        checkValue(api);
        checkValue(link);
        checkValue(category);
    }

    public static void checkValue(String value) {
        if (value == null || value.isBlank())
            throw new IllegalArgumentException("Value required!");
    }
}
