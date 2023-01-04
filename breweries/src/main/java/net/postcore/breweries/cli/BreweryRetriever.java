package net.postcore.breweries.cli;

public class BreweryRetriever {

    public static void main(String[] args) {
        System.out.println("BreweryRetriever running...");
        if (args.length == 0) {
            System.out.println("First argument should be a city.");
            return;
        }

        try {
            retrieveBreweries(args[0]);
        } catch (Exception e) {
            System.out.println("Unexpected error!");
            e.printStackTrace();
        }
    }

    private static void retrieveBreweries(String city) {
        System.out.println("Retrieving breweries located in " + city);
    }
}
