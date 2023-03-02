package net.postcore.filehandler;

public class Main {

    public static void main(String[] args) {

        FormatHandler inferCSV = new InferCSV();
        inferCSV.displaySchema();
    }
}
