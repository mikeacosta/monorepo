package net.postcore.ocpthings.methodoverloadpriority;

import java.util.Arrays;

public class MethodOverloadPriority {

    public static void main(String[] args) {
        printSum(2, 7);
    }

    public static void printSum(Integer a, Integer b){
        System.out.format("In printSum(Integer): %d%n", a + b);
    }

    public static void printSum(double a, double b){
        System.out.format("In printSum(double): %f%n", a + b);
    }

    public static void printSum(int... ints){
        System.out.format("In printSum(int...): %d%n", Arrays.stream(ints).sum());
    }
}
