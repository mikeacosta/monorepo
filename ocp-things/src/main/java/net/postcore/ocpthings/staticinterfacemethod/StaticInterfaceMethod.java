package net.postcore.ocpthings.staticinterfacemethod;

import java.time.LocalTime;

public class StaticInterfaceMethod {}

interface Slot {
    int LENGTH_IN_MINUTES = 50;

    static String lengthDescription() {
        return String.format("This slot lasts %d minutes.", LENGTH_IN_MINUTES);
    }
}

class Talk implements Slot {
    private final String speaker;
    private final String title;
    private final LocalTime startTime;

    public Talk(String speaker, String title, LocalTime startTime) {
        this.speaker = speaker;
        this.title = title;
        this.startTime = startTime;
    }
}
