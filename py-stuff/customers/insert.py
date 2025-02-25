import mysql.connector

mydb = mysql.connector.connect(
  host="localhost",
  port=3307,
  user="root",
  password="Abc12345",
  database="dev_db"
)

mycursor = mydb.cursor()

sql = "INSERT INTO customers (name, address) VALUES (%s, %s)"
val = [
  ('Joe', 'High St'),
  ('Peter', 'Lowstreet 4'),
  ('Amy', 'Apple St 652'),
  ('Hannah', 'Mountain 21'),
  ('Michael', 'Valley 345'),
  ('Sandy', 'Ocean Blvd 2'),
  ('Betty', 'Green Grass 1'),
  ('Richard', 'Sky St 331'),
  ('Susan', 'One Way 98'),
  ('Vicky', 'Yellow Garden 2'),
  ('Ben', 'Park Lane 38'),
  ('William', 'Central St 954'),
  ('Chuck', 'Main Road 989'),
  ('Viola', 'Sideway 1633')
]

mycursor.executemany(sql, val)

mydb.commit()

print(mycursor.rowcount, "was inserted.") 

print("last record inserted, ID:", mycursor.lastrowid) 