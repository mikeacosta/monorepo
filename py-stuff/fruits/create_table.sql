CREATE TABLE fruits (
  id bigint,    
  fruit string,    
  berry boolean,    
  update_timestamp timestamp
)    
  PARTITIONED BY (berry)
LOCATION 's3://a-bucket-01234/fruits/'
TBLPROPERTIES ('table_type'='ICEBERG');