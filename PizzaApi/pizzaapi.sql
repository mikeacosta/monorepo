BEGIN;

SET client_encoding = 'LATIN1';

CREATE TABLE test_table (
                      id integer NOT NULL,
                      name text NOT NULL,
                      description text NOT NULL
);

INSERT INTO test_table (id, name, description) VALUES (1, 'test data', 'just testing, bro');

COMMIT;

ANALYZE test_table;