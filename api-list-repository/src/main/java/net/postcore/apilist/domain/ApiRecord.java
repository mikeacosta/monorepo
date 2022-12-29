package net.postcore.apilist.domain;

import java.util.Optional;

public record ApiRecord(String api, String description, String auth, Boolean https, String cors, String link, String category,
                        Optional<String> notes) {

    public ApiRecord {
        checkValue(api);
        checkValue(description);
        checkValue(link);
        checkValue(category);
        notes.ifPresent(ApiRecord::checkValue);
    }

    public static void checkValue(String value) {
        if (value == null || value.isBlank())
            throw new IllegalArgumentException("Value required!");
    }
}
