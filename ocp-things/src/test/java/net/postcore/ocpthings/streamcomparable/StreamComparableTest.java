package net.postcore.ocpthings.streamcomparable;

import net.postcore.ocpthings.streamcomparable.StreamComparable;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

@DisplayName("Stream elements that don't implement Comparable but must be sorted can cause an unexpected kind of RuntimeException")
class StreamComparableTest {

    @Test
    @DisplayName("sortedTalks() should return a SortedSet of Talks without any Exception")
    void sortedPresentations() {
        StreamComparable.sortedPresentations();
    }
}