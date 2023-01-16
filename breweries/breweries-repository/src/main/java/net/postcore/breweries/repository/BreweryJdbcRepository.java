package net.postcore.breweries.repository;

import net.postcore.breweries.domain.Brewery;
import org.h2.jdbcx.JdbcDataSource;

import javax.sql.DataSource;
import java.sql.*;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class BreweryJdbcRepository implements BreweryRepository {

    private static final String H2_DATABASE_URL =
            "jdbc:h2:file:%s;AUTO_SERVER=TRUE;INIT=RUNSCRIPT FROM './db_init.sql'";

    private static final String INSERT_BREWERY = """
            MERGE INTO Breweries (id, name, brewery_type, street, city, state, postal_code, phone, website_url)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)
            """;

    private final DataSource dataSource;

    public BreweryJdbcRepository(String databaseFile) {
        JdbcDataSource jdbcDataSource = new JdbcDataSource();
        jdbcDataSource.setURL(H2_DATABASE_URL.formatted(databaseFile));
        this.dataSource = jdbcDataSource;
    }

    @Override
    public void saveBrewery(Brewery brewery) {
        try (Connection connection = dataSource.getConnection()) {
            PreparedStatement statement = connection.prepareStatement(INSERT_BREWERY);
            statement.setString(1, brewery.id());
            statement.setString(2, brewery.name());
            statement.setString(3, brewery.brewery_type());
            statement.setString(4, brewery.street());
            statement.setString(5, brewery.city());
            statement.setString(6, brewery.street());
            statement.setString(7, brewery.postal_code());
            statement.setString(8, brewery.phone());
            statement.setString(9, brewery.website_url());
            statement.execute();
        } catch (SQLException e) {
            throw new RepositoryException("Failed to save: " + brewery, e);
        }
    }

    @Override
    public List<Brewery> getAllBreweries() {
        try (Connection connection = dataSource.getConnection()) {
            Statement stmt = connection.createStatement();
            ResultSet resultSet = stmt.executeQuery("SELECT * FROM BREWERIES");

            List<Brewery> breweries = new ArrayList<>();
            while (resultSet.next()) {
                Brewery brewery = new Brewery(resultSet.getString(1),
                        resultSet.getString(2),
                        resultSet.getString(3),
                        resultSet.getString(4),
                        resultSet.getString(5),
                        resultSet.getString(6),
                        resultSet.getString(7),
                        resultSet.getString(8),
                        resultSet.getString(9));
                breweries.add(brewery);
            }

            return Collections.unmodifiableList(breweries);
        }catch (SQLException e) {
            throw new RepositoryException("Failed to retrieve breweries", e);
        }
    }
}
