package net.postcore.dsa.datastructures.binarysearchtree;

import net.postcore.dsa.datastructures.linkedlist.LinkedListImpl;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class BinarySearchTreeTest {

    BinarySearchTree bst;

    @BeforeEach
    void setUp() {
        bst = new BinarySearchTree();

        bst.insert(47);
        bst.insert(21);
        bst.insert(76);
        bst.insert(18);
        bst.insert(27);
        bst.insert(52);
        bst.insert(82);
    }

    @Test
    public void bfsTest() {
        ArrayList<Integer> actual = bst.bfs();
        List<Integer> expected = Arrays.asList(47, 21, 76, 18, 27, 52, 82);

        assertEquals(expected, actual);
    }

    @Test
    public void dfsPreOrderTest() {
        ArrayList<Integer> actual = bst.dfsPreOrder();
        List<Integer> expected = Arrays.asList(47, 21, 18, 27, 76, 52, 82);

        assertEquals(expected, actual);
    }

    @Test
    public void dfsInOrderTest() {
        ArrayList<Integer> actual = bst.dfsInOrder();
        List<Integer> expected = Arrays.asList(18, 21, 27, 47, 52, 76, 82);

        assertEquals(expected, actual);
    }

    @Test
    public void dfsPostOrderTest() {
        ArrayList<Integer> actual = bst.dfsPostOrder();
        List<Integer> expected = Arrays.asList(18, 27, 21, 52, 82, 76, 47);

        assertEquals(expected, actual);
    }
}
