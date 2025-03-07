MERGE INTO fruits f USING raw_fruits r
  ON f.fruit = r.fruit
  WHEN MATCHED
    THEN UPDATE
      SET id = r.id, berry = r.berry, update_timestamp = current_timestamp
  WHEN NOT MATCHED
    THEN INSERT (id, fruit, berry, update_timestamp)
      VALUES(r.id, r.fruit, r.berry, current_timestamp);