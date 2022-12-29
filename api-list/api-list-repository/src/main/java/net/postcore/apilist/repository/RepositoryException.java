package net.postcore.apilist.repository;

import java.sql.SQLException;

public class RepositoryException extends RuntimeException {
    public RepositoryException(String message, SQLException e) {
        super(message);
    }
}
