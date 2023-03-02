package net.postcore.dsa.datastructures.binarysearchtree;

import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class BinarySearchTreeTest {

    @Test
    public void bfsTest() {
        BinarySearchTree bst = new BinarySearchTree();

        bst.insert(47);
        bst.insert(21);
        bst.insert(76);
        bst.insert(18);
        bst.insert(27);
        bst.insert(52);
        bst.insert(82);

        ArrayList<Integer> actual = bst.BFS();
        List<Integer> expected = Arrays.asList(47, 21, 76, 18, 27, 52, 82);

        assertEquals(expected, actual);
    }
}
