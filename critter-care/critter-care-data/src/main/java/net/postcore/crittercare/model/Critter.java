package net.postcore.crittercare.model;

import java.time.LocalDate;

public class Critter extends BaseEntity {

    private LocalDate birthDate;
    private CritterType critterType;
    private Owner owner;

    public LocalDate getBirthDate() {
        return birthDate;
    }

    public void setBirthDate(LocalDate birthDate) {
        this.birthDate = birthDate;
    }

    public CritterType getCritterType() {
        return critterType;
    }

    public void setCritterType(CritterType critterType) {
        this.critterType = critterType;
    }

    public Owner getOwner() {
        return owner;
    }

    public void setOwner(Owner owner) {
        this.owner = owner;
    }
}
