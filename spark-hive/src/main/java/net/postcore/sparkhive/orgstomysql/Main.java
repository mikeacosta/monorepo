package net.postcore.sparkhive.orgstomysql;

import org.apache.spark.sql.Dataset;
import org.apache.spark.sql.Row;
import org.apache.spark.sql.SparkSession;

public class Main {

    private static final String CSV_PATH = "src/main/resources/orgs.csv";

    public static void main(String[] args) {
        SparkSession spark=SparkSession.builder().master("local[*]").getOrCreate();

        Dataset<Row> csv = spark.read().format("csv")
                .option("sep", ",")
                .option("inferSchema", "true")
                .option("header", "true")
                .load(CSV_PATH);

        csv.show();
        csv.printSchema();
    }
}
