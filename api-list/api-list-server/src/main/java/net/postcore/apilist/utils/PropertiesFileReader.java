package net.postcore.apilist.utils;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class PropertiesFileReader {
    private static Properties properties = null;
    private static final String propertiesFile = "/server.properties";

    private static void loadProperties() {
        try (InputStream propertiesStream = PropertiesFileReader.class.getResourceAsStream(propertiesFile)) {
            properties = new Properties();
            properties.load(propertiesStream);
        } catch (IOException e) {
            throw new IllegalStateException("Could not load properties file");
        }
    }

    public static String getValue(String key) throws IOException {
        if (properties == null)
            loadProperties();

        return properties.getProperty(key);
    }
}
