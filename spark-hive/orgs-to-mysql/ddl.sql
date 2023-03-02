CREATE DATABASE IF NOT EXISTS dev_db;

USE dev_db;

CREATE TABLE orgs (
                      id INT,
                      organization_id VARCHAR(255),
                      name VARCHAR(255),
                      website VARCHAR(255),
                      country VARCHAR(255),
                      description VARCHAR(255),
                      founded INT,
                      industry VARCHAR(255),
                      number_of_employees INT
);