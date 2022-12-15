package net.postcore.apilist.cli;

public class ApiRetriever {

    public static void main(String[] args) {
        System.out.println("ApiRetriever started!");
        if (args.length == 0) {
            System.out.println("First argument should be API category.");
            return;
        }

        try {
            retrieveApis(args[0]);
        } catch (Exception e) {
            System.out.println("Unexpected error");
            e.printStackTrace();
        }
    }

    private static void retrieveApis(String category) {
        System.out.println("Retrieving APIs for category \"" + category + "\"");
    }
}
