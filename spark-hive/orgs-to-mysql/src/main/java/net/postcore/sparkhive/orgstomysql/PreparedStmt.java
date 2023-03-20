package net.postcore.sparkhive.orgstomysql;

import java.io.BufferedReader;
import java.io.FileReader;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.util.ArrayList;
import java.util.List;

public class PreparedStmt {

    private static final String CSV_PATH = "src/main/resources/orgs-million.csv";

    public void run() {
        System.out.println("importing with PreparedStatement");

        int batchSize = 25;

        try(Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3307/dev_db", "root",  "Abc12345");) {

            connection.setAutoCommit(false);
            String sql = "INSERT INTO orgs (id, organization_id, name, website, country, description, founded, industry, number_of_employees) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";

            try (PreparedStatement statement = connection.prepareStatement(sql)) {
                BufferedReader lineReader = new BufferedReader(new FileReader(CSV_PATH));
                String lineText = null;

                int count = 0;

                lineReader.readLine(); // skip header line

                while ((lineText = lineReader.readLine()) != null) {
                    List<String> data = parse(lineText);
                    String id = data.get(0);
                    String organization_id = data.get(1);
                    String name = data.get(2);
                    String website = data.get(3);
                    String country = data.get(4);
                    String description = data.get(5);
                    String founded = data.get(6);
                    String industry = data.get(7);
                    String number_of_employees = data.get(8);

                    statement.setInt(1, Integer.parseInt(id));
                    statement.setString(2, organization_id);
                    statement.setString(3, name);
                    statement.setString(4, website);
                    statement.setString(5, country);
                    statement.setString(6, description);
                    statement.setInt(7, Integer.parseInt(founded));
                    statement.setString(8, industry);
                    statement.setInt(9, Integer.parseInt(number_of_employees));

                    statement.addBatch();
                    count++;

                    if (count % batchSize == 0) {
                        System.out.println("executing batch");
                        statement.executeBatch();
                        count = 0;
                    }
                }

                lineReader.close();

                // execute the remaining queries
                statement.executeBatch();

                connection.commit();
            } catch (Exception ex) {
                System.err.println(ex);
            }
        } catch (Exception ex) {
            System.err.println(ex);
        }
    }

    // method to handle commas inside double quotes
    List<String> parse(String input) {
        List<String> tokens = new ArrayList<>();
        int startPosition = 0;
        boolean isInQuotes = false;
        for (int currentPosition = 0; currentPosition < input.length(); currentPosition++) {
            if (input.charAt(currentPosition) == '\"') {
                isInQuotes = !isInQuotes;
            }
            else if (input.charAt(currentPosition) == ',' && !isInQuotes) {
                tokens.add(input.substring(startPosition, currentPosition));
                startPosition = currentPosition + 1;
            }
        }

        String lastToken = input.substring(startPosition);
        if (lastToken.equals(",")) {
            tokens.add("");
        } else {
            tokens.add(lastToken);
        }

        return tokens;
    }
}
