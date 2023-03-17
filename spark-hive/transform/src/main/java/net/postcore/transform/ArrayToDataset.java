package net.postcore.transform;

import org.apache.spark.api.java.function.MapFunction;
import org.apache.spark.api.java.function.ReduceFunction;
import org.apache.spark.sql.Dataset;
import org.apache.spark.sql.Encoders;
import org.apache.spark.sql.SparkSession;

import java.io.Serializable;
import java.util.Arrays;
import java.util.List;

public class ArrayToDataset {

    public void start() {
        SparkSession spark = new SparkSession.Builder()
                .appName("Array To Dataset<String>")
                .master("local[*]")
                .getOrCreate();

        spark.sparkContext().setLogLevel("ERROR");

        String [] stringList = new String[] {"Banana", "Car", "Glass", "Banana", "Computer", "Car"};

        List<String> data = Arrays.asList(stringList);

        Dataset<String> ds =  spark.createDataset(data, Encoders.STRING());
        ds = ds.map((MapFunction<String, String>) row -> "word: " + row, Encoders.STRING());
        ds.show();

        String stringValue = ds.reduce(new StringReducer());
        System.out.println(stringValue);
    }

    static class StringReducer implements ReduceFunction<String>, Serializable {

        @Override
        public String call(String s, String t1) throws Exception {
            return s + t1;
        }
    }

    static class StringMapper implements MapFunction<String, String>, Serializable {

        @Override
        public String call(String s) throws Exception {
            return "word: " + s;
        }
    }
}