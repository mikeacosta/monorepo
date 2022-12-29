package net.postcore.apilist.repository;

import net.postcore.apilist.domain.ApiRecord;
import org.h2.jdbcx.JdbcDataSource;

import javax.sql.DataSource;
import java.sql.*;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Optional;

class ApiJdbcRepository implements ApiRepository {

    private static final String H2_DATABASE_URL =
            "jdbc:h2:file:%s;AUTO_SERVER=TRUE;INIT=RUNSCRIPT FROM './db_init.sql'";

    private static final String INSERT_API = """
            MERGE INTO APIS (api, description, auth, https, cors, link, category)
            VALUES (?, ?, ?, ?, ?, ?, ?)
            """;

    private static final String ADD_NOTES = """
            UPDATE APIS SET notes = ?
            WHERE api = ?
            """;

    private final DataSource dataSource;

    public ApiJdbcRepository(String databaseFile) {
        JdbcDataSource jdbcDataSource = new JdbcDataSource();
        jdbcDataSource.setURL(H2_DATABASE_URL.formatted(databaseFile));
        this.dataSource = jdbcDataSource;
    }

    @Override
    public void saveApi(ApiRecord apiRecord) {
        try (Connection connection = dataSource.getConnection()) {
            PreparedStatement stmt = connection.prepareStatement(INSERT_API);
            stmt.setString(1, apiRecord.api());
            stmt.setString(2, apiRecord.description());
            stmt.setString(3, apiRecord.auth());
            stmt.setBoolean(4, apiRecord.https());
            stmt.setString(5, apiRecord.cors());
            stmt.setString(6, apiRecord.link());
            stmt.setString(7, apiRecord.category());
            stmt.execute();
        } catch (SQLException e) {
            throw new RepositoryException("Failed to save " + apiRecord, e);
        }
    }

    @Override
    public List<ApiRecord> getAllApis() {
        try (Connection connection = dataSource.getConnection()) {
            Statement stmt = connection.createStatement();
            ResultSet resultSet = stmt.executeQuery("SELECT * FROM APIS");

            List<ApiRecord> apis = new ArrayList<>();
            while (resultSet.next()) {
                ApiRecord apiRecord = new ApiRecord(resultSet.getString(1),
                        resultSet.getString(2),
                        resultSet.getString(3),
                        resultSet.getBoolean(4),
                        resultSet.getString(5),
                        resultSet.getString(6),
                        resultSet.getString(7),
                        Optional.ofNullable(resultSet.getString(8)));
                apis.add(apiRecord);
            }

            return Collections.unmodifiableList(apis);
        }catch (SQLException e) {
            throw new RepositoryException("Failed to retrieve APIs", e);
        }
    }

    @Override
    public void addNotes(String api, String notes) {
        try (Connection connection = dataSource.getConnection()) {
            PreparedStatement stmt = connection.prepareStatement(ADD_NOTES);
            stmt.setString(1, notes);
            stmt.setString(2, api);
            stmt.execute();
        } catch (SQLException e) {
            throw new RepositoryException("Failed to add notes to " + api, e);
        }
    }
}
