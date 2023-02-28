package net.postcore.crittercare.model;

import java.util.Set;

public class Owner extends Person {

    private Set<Critter> critters;

    public Set<Critter> getCritters() {
        return critters;
    }

    public void setCritters(Set<Critter> critters) {
        this.critters = critters;
    }
}
