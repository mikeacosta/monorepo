package net.postcore.apilist.repository;

import net.postcore.apilist.domain.ApiRecord;
import org.h2.jdbcx.JdbcDataSource;

import javax.sql.DataSource;
import java.util.List;

public class ApiJdbcRepository implements ApiRepository {

    private static final String H2_DATABASE_URL =
            "jdbc:h2:file:%s;AUTO_SERVER=TRUE;INIT=RUNSCRIPT FROM './db_init.sql'";

    private final DataSource dataSource;

    public ApiJdbcRepository(String databaseFile) {
        JdbcDataSource jdbcDataSource = new JdbcDataSource();
        jdbcDataSource.setURL(H2_DATABASE_URL);
        this.dataSource = jdbcDataSource;
    }

    @Override
    public void saveApi(ApiRecord apiRecord) {

    }

    @Override
    public List<ApiRecord> getAllApis() {
        return null;
    }
}
