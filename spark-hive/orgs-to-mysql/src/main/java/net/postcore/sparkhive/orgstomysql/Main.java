package net.postcore.sparkhive.orgstomysql;

import org.apache.spark.sql.Dataset;
import org.apache.spark.sql.Row;
import org.apache.spark.sql.SaveMode;
import org.apache.spark.sql.SparkSession;

import java.util.Properties;

public class Main {

    private static final String CSV_PATH = "src/main/resources/orgs.csv";

    public static void main(String[] args) {
        SparkSession spark=SparkSession.builder().master("local[*]").getOrCreate();

        Dataset<Row> df = spark.read().format("csv")
                .option("sep", ",")
                .option("inferSchema", "true")
                .option("header", "true")
                .load(CSV_PATH);

        df.show();
        df.printSchema();

        String jdbcUrl = "jdbc:mysql://localhost:3307/dev_db";
        Properties props = new Properties();
        props.setProperty("driver", "com.mysql.cj.jdbc.Driver");
        props.setProperty("user", "root");
        props.setProperty("password", "Abc12345");

        df.write()
                .mode(SaveMode.Overwrite)
                .jdbc(jdbcUrl, "orgs", props);
    }
}
