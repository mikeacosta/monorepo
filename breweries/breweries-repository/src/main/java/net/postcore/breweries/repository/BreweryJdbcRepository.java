package net.postcore.breweries.repository;

import net.postcore.breweries.domain.Brewery;
import org.h2.jdbcx.JdbcDataSource;

import javax.sql.DataSource;
import java.util.List;

public class BreweryJdbcRepository implements BreweryRepository {

    private static final String H2_DATABASE_URL =
            "jdbc:h2:file:%s;AUTO_SERVER=TRUE;INIT=RUNSCRIPT FROM './db_init.sql'";

    private final DataSource dataSource;

    public BreweryJdbcRepository(String databaseFile) {
        JdbcDataSource jdbcDataSource = new JdbcDataSource();
        jdbcDataSource.setURL(H2_DATABASE_URL.formatted(databaseFile));
        this.dataSource = jdbcDataSource;
    }

    @Override
    public void saveBrewery(Brewery brewery) {

    }

    @Override
    public List<Brewery> getAllBreweries() {
        return null;
    }
}
