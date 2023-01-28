package net.postcore.ocpthings.nullobjstaticvar;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class NullObjStaticVarTest {

    @Test
    @DisplayName("Accessing instance field on null object should throw exception")
    void instanceFieldThrowsNullEx() {
        assertThrows(NullPointerException.class, () -> {
            NullObjStaticVar nullObjStaticVar = null;
            System.out.println(nullObjStaticVar.language);
        });
    }

    @Test
    @DisplayName("Accessing static field on null object should throw exception, right?")
    void staticFieldThrowsNullEx() {
        assertThrows(NullPointerException.class, () -> {
            NullObjStaticVar nullObjStaticVar = null;
            System.out.println(nullObjStaticVar.version);
        });
    }
}