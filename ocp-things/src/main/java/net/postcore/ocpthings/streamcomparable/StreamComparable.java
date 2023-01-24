package net.postcore.ocpthings.streamcomparable;

import java.time.LocalTime;
import java.util.SortedSet;
import java.util.TreeSet;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class StreamComparable {

    public static SortedSet<Presentation> sortedPresentations() {
        return Stream.of(
                new Presentation("Bugs Bunny", "Carrots Are Awesome!", LocalTime.of(11, 0)),
                new Presentation("Road Runner", "Stop Living Too Slow", LocalTime.of(9, 30)),
                new Presentation("Tweety", "Ban All Cats Off The Internet", LocalTime.of(14, 45))
        ).sorted().collect(Collectors.toCollection(TreeSet::new));
    }
}
