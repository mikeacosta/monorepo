package net.postcore.ocpthings.declarearrays;

import java.util.List;

public class DeclareArrays {

    static int[] varArray() {
        var elements = new int[5];
        return elements;
    }

    static List<int[]> likeCLang() {
//        int arr1[];
//        int arr2[];

        int[] arr1, arr2;
        arr1 = new int[2];
        arr2 = new int[10];
        return List.of(arr1, arr2);
    }
}
