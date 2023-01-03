package net.postcore.dsa.datastructures.linkedlist;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class LinkedListTest {

    LinkedList linkedList;

    @BeforeEach
    void setUp() {
        linkedList = new LinkedListImpl();
        linkedList.add(25);
        linkedList.add(31);
        linkedList.add(4);
        linkedList.add(3);
    }

    @Test
    public void toStringTest() {
        assertEquals("25, 31, 4, 3", linkedList.toString());
    }

    @Test
    public void addTest() {
        linkedList.add(100);
        assertEquals("25, 31, 4, 3, 100", linkedList.toString());
    }

    @Test
    public void removeTest() {
        Node node = linkedList.remove();
        assertEquals(25, node.getValue());
        assertEquals("31, 4, 3", linkedList.toString());
    }

    @Test
    public void insertTest() {
        linkedList.insert(50, 4);
        assertEquals("25, 31, 4, 3, 100", linkedList.toString());
    }
}

