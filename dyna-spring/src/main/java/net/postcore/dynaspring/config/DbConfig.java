package net.postcore.dynaspring.config;

import com.amazonaws.auth.AWSCredentialsProvider;
import com.amazonaws.auth.profile.ProfileCredentialsProvider;
import com.amazonaws.services.dynamodbv2.AmazonDynamoDB;
import com.amazonaws.services.dynamodbv2.AmazonDynamoDBClientBuilder;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class DbConfig {

    @Bean
    public AmazonDynamoDB amazonDynamoDB() {

        AWSCredentialsProvider credentials = new ProfileCredentialsProvider("default");
        AmazonDynamoDB amazonDynamoDB = AmazonDynamoDBClientBuilder
                .standard()
                .withCredentials(credentials)
                .build();

        return amazonDynamoDB;
    }
}
