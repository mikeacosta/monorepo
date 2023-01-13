CREATE TABLE IF NOT EXISTS BREWERIES(ID VARCHAR PRIMARY KEY NOT NULL,
                                NAME VARCHAR NOT NULL,
                                BREWERY_TYPE VARCHAR NOT NULL,
                                STREET VARCHAR,
                                CITY VARCHAR NOT NULL,
                                STATE VARCHAR NOT NULL,
                                POSTAL_CODE VARCHAR,
                                PHONE VARCHAR,
                                WEBSITE_URL VARCHAR,
                                NOTES VARCHAR);