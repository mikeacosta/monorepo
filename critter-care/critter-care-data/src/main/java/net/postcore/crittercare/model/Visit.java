package net.postcore.crittercare.model;

import java.time.LocalDate;

public class Visit extends BaseEntity {

    private LocalDate date;
    private String description;
    private Critter critter;

    public LocalDate getDate() {
        return date;
    }

    public void setDate(LocalDate date) {
        this.date = date;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Critter getCritter() {
        return critter;
    }

    public void setCritter(Critter critter) {
        this.critter = critter;
    }
}
