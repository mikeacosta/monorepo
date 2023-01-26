package net.postcore.ocpthings.clonedarray;

import net.postcore.ocpthings.streamcomparable.Presentation;

import java.time.LocalTime;

public class ClonedArray {

    private final Presentation[] presentations = new Presentation[] {
        new Presentation("Joe Blow", "Clean Code", LocalTime.of(12, 15)),
        new Presentation("Donald Duck", "Quack", LocalTime.of(9, 30))
    };

    public Presentation[] getPresentations() {
        return presentations;
    }

    public Presentation[] getClonedPresentations() {
        return presentations.clone();
    }
}
