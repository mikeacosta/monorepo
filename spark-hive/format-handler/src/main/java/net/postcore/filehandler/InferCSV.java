package net.postcore.filehandler;

import org.apache.spark.sql.Dataset;
import org.apache.spark.sql.Row;
import org.apache.spark.sql.SparkSession;

public class InferCSV implements FormatHandler{

    @Override
    public void displaySchema() {
        String FILE_PATH = "src/main/resources/products.csv";

        SparkSession spark = SparkSession.builder()
                .appName("CSV to Dataframe")
                .master("local[*]")
                .getOrCreate();

        spark.sparkContext().setLogLevel("ERROR");

        Dataset<Row> df = spark.read().format("csv")
                .option("header", "true")
                .option("multiline", true)
                .option("sep", ";")
                .option("quote", "^") // treat carat as quotes
                .option("dateFormat", "M/d/y")
                .option("inferSchema", true)
                .load(FILE_PATH);

        System.out.println("Excerpt of the dataframe content:");
        df.show();
        System.out.println("Dataframe's schema:");
        df.printSchema();
    }
}
