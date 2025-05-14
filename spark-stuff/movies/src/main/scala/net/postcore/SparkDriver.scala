package net.postcore

import org.apache.spark.SparkConf
import org.apache.spark.sql.SparkSession
import org.apache.spark.sql.functions._

import java.util.Properties
import scala.io.Source

object SparkDriver extends Serializable {

  def main(args: Array[String]): Unit = {

    val spark = SparkSession.builder()
      .master("local[3]")
      .config(readSparkConfig)
      .getOrCreate()

    val moviesDF= spark.read.option("multiline", value = true).json("data/movies.json")

    moviesDF
      .filter(!array_contains(moviesDF("genre"), "Adventure"))
      .withColumn("name", upper(col("name")))
      .groupBy("year").agg(collect_list("name"))
      .coalesce(1)
      .write.json("data/output")
  }

  private def readSparkConfig: SparkConf ={
    val conf = new SparkConf()
    val properties = new Properties()
    properties.load(Source.fromFile("spark.conf").bufferedReader())
    properties.forEach((key, value) => conf.set(key.toString, value.toString))
    conf
  }
}
