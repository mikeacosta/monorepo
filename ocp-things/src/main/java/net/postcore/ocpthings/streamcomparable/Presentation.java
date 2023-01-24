package net.postcore.ocpthings.streamcomparable;

import java.time.LocalTime;

public class Presentation {

    private String speaker;
    private String title;
    private LocalTime startTime;

    public Presentation(String speaker, String title, LocalTime startTime) {
        this.speaker = speaker;
        this.title = title;
        this.startTime = startTime;
    }

    public String getSpeaker() {
        return speaker;
    }

    public void setSpeaker(String speaker) {
        this.speaker = speaker;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public LocalTime getStartTime() {
        return startTime;
    }

    public void setStartTime(LocalTime startTime) {
        this.startTime = startTime;
    }
}
