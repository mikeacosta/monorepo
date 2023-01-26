package net.postcore.ocpthings.methodref;

public class School {

    final String name;
    final int capacity;

    final static String DEFAULT_NAME = "Random school";
    final static int DEFAULT_CAPACITY = 0;

    School() {
        this(DEFAULT_NAME, DEFAULT_CAPACITY);
    }

    School(String name) {
        this(name, DEFAULT_CAPACITY);
    }

    School(int capacity) {
        this(DEFAULT_NAME, capacity);
    }

    School(String name, int capacity) {
        this.name = name;
        this.capacity = capacity;
    }

    public String getName() {
        return name;
    }

    public int getCapacity() {
        return capacity;
    }
}
