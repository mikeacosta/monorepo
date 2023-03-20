package net.postcore.sparkhive.orgstomysql;

public class Main {

    public static void main(String[] args) {
        System.out.println("import started");

        boolean useSpark = false;

        if (useSpark) {
            SparkImport sparkImport = new SparkImport();
            sparkImport.run();
        } else {
            PreparedStmt preparedStmt = new PreparedStmt();
            preparedStmt.run();
        }

        System.out.println("import complete");
    }
}
