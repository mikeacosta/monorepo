package net.postcore.ocpthings.staticinterfacemethod;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import java.time.LocalTime;

import static org.assertj.core.api.AssertionsForClassTypes.assertThat;

class StaticInterfaceMethodTest {

    @Test
    @DisplayName("Talk length description should be the right value")
    void testAccessingStaticInterfaceMethod() {
        Talk carrotsAreAwesome = new Talk("Bugs Bunny", "Carrots Are Awesome!", LocalTime.of(11, 0));

        assertThat(carrotsAreAwesome.LENGTH_IN_MINUTES).isEqualTo(50);
        assertThat(carrotsAreAwesome.lengthDescription()).isEqualTo("This slot lasts 50 minutes.");
    }

}