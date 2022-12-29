CREATE TABLE IF NOT EXISTS APIS(API VARCHAR PRIMARY KEY NOT NULL,
                                   DESCRIPTION VARCHAR NOT NULL,
                                   AUTH VARCHAR,
                                   HTTPS BOOLEAN NOT NULL,
                                   CORS VARCHAR,
                                   LINK VARCHAR NOT NULL,
                                   CATEGORY VARCHAR NOT NULL,
                                   NOTES VARCHAR);
