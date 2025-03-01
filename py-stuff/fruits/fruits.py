import awswrangler as wr
import pandas as pd

bucket_name = "a-bucket-01234"
glue_database = "default"
glue_table = "raw_fruits"
path = f"s3://{bucket_name}/{glue_table}/"
temp_path = f"s3://{bucket_name}/{glue_table}_tmp/"

wr.catalog.delete_table_if_exists(database=glue_database, table=glue_table)

df = pd.read_csv("https://huggingface.co/datasets/kestra/datasets/raw/main/csv/fruit.csv")
df = df[~df["fruit"].isin(["Blueberry", "Banana"])]
df = df.drop_duplicates(subset=["fruit"], ignore_index=True, keep="first")

wr.athena.to_iceberg(
    df=df,
    database=glue_database,
    table=glue_table,
    table_location=path,
    temp_path=temp_path,
    partition_cols=["berry"],
)