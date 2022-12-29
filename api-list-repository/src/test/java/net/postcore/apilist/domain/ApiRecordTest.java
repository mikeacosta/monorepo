package net.postcore.apilist.domain;

import org.junit.jupiter.api.Test;

import java.util.Optional;

import static org.junit.jupiter.api.Assertions.*;

class ApiRecordTest {

    @Test
    void rejectNullComponents() {
        assertThrows(IllegalArgumentException.class, () ->
                new ApiRecord(null, null, null, null, null, null, null,
                        Optional.empty()));
    }
}