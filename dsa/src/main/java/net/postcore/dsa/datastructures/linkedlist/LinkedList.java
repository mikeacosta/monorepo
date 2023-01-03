package net.postcore.dsa.datastructures.linkedlist;

public interface LinkedList {

    int size();                 // number of nodes
    void add(int value);        // add to end
    Node remove();              // remove from front
    void insert(int value, int position);
    Node removeAt(int position);
    void reverse();
    String toString();
}
