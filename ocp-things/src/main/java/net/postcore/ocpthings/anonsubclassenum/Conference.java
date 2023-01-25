package net.postcore.ocpthings.anonsubclassenum;

import java.time.Year;

public enum Conference {
    SPRING_ONE("SpringOne Essentials", 2023, "United States"),
    DEVOXX_UK("Devoxx UK", 2023, "United Kingdom"),
    JAVA_WORLD("Java World", 2024, "Palau");

    private final String name;
    private final Year nextEdition;
    private final String country;

    Conference(String name, int nextEdition, String country) {
        this.name = name;
        this.nextEdition = Year.of(nextEdition);
        this.country = country;
    }
    public String whenIsTheNext() {
        return String.format("The next %s conference will be in %s in %d.",
                name, country, nextEdition.getValue());
    }
}
