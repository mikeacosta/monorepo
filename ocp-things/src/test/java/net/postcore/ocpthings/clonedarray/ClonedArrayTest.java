package net.postcore.ocpthings.clonedarray;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

@DisplayName("Equality when dealing with cloned arrays or immutable collections")
class ClonedArrayTest {

    @Test
    @DisplayName("Presentations array should equal a cloned presentations array")
    void presentationsEquals() {
        var clonedArray = new ClonedArray();

        var presentations = clonedArray.getPresentations();
        var clonedPresentations = clonedArray.getClonedPresentations();

        assertThat(presentations == clonedPresentations).isTrue();
    }

    @Test
    @DisplayName("Presentations array should not contain a cloned presentations array")
    void presentationsContains() {
        var clonedArray = new ClonedArray();

        var presentations = clonedArray.getPresentations();
        var clonedPresentations = clonedArray.getClonedPresentations();

        assertThat(presentations).doesNotContain(clonedPresentations);
    }
}