package net.postcore.languagesapi.domain;

import jakarta.persistence.*;

@Entity
@Table(name="languages")
public class Language extends BaseEntity {

    private String name;
    private String family;
    private Integer speakers;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getFamily() {
        return family;
    }

    public void setFamily(String family) {
        this.family = family;
    }

    public Integer getSpeakers() {
        return speakers;
    }

    public void setSpeakers(Integer speakers) {
        this.speakers = speakers;
    }
}
