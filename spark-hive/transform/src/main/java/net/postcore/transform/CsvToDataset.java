package net.postcore.transform;

import net.postcore.transform.mappers.HouseMapper;
import net.postcore.transform.models.House;
import org.apache.spark.sql.Dataset;
import org.apache.spark.sql.Encoders;
import org.apache.spark.sql.Row;
import org.apache.spark.sql.SparkSession;

import static org.apache.spark.sql.functions.*;

public class CsvToDataset {

    public void start() {

        SparkSession spark = SparkSession.builder()
                .appName("CSV to dataframe to Dataset<House> and back")
                .master("local")
                .getOrCreate();


        Dataset<Row> df = spark.read().format("csv")
                .option("inferSchema", "true") // Make sure to use string version of true
                .option("header", true)
                .option("sep", ";")
                .load("src/main/resources/houses.csv");

        Dataset<House> houseDataset = df.map(new HouseMapper(), Encoders.bean(House.class));

        Dataset<Row> df2 = houseDataset.toDF();
        df2 = df2.withColumn("formattedDate", concat(df2.col("vacantBy.year"), lit("-"), df2.col("vacantBy.month")));
        df2.show();
    }
}
