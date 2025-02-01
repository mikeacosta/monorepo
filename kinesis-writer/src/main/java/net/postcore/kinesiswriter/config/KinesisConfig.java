package net.postcore.kinesiswriter.config;

import com.amazonaws.auth.AWSStaticCredentialsProvider;
import com.amazonaws.auth.BasicAWSCredentials;
import com.amazonaws.services.kinesis.producer.KinesisProducer;
import com.amazonaws.services.kinesis.producer.KinesisProducerConfiguration;
import com.amazonaws.services.kinesis.producer.UserRecordFailedException;
import com.amazonaws.services.kinesis.producer.UserRecordResult;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.google.common.util.concurrent.FutureCallback;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
@Slf4j
public class KinesisConfig {

    @Value("${aws.access.key.id}")
    private String accessKeyId;

    @Value("${aws.secret.access.key}")
    private String secretKey;

    @Value("${aws.region}")
    private String region;

    @Bean
    public KinesisProducer kinesisProducer() {
        return new KinesisProducer(kinesisProducerConfiguration());
    }

    @Bean
    public KinesisProducerConfiguration kinesisProducerConfiguration() {
        BasicAWSCredentials awsCredentials = new BasicAWSCredentials(accessKeyId, secretKey);

        return new KinesisProducerConfiguration()
                .setCredentialsProvider(new AWSStaticCredentialsProvider(awsCredentials))
                .setVerifyCertificate(false)
                .setRecordMaxBufferedTime(6000)
                .setMaxConnections(1)
                .setRegion(region)
                .setRecordTtl(3000);
    }

    @Bean
    public ObjectMapper objectMapper() {
        return new ObjectMapper();
    }

    @Bean
    public FutureCallback<UserRecordResult> futureCallback() {
        return new FutureCallback<>() {
            @Override
            public void onFailure(Throwable t) {
                log.error(t.getMessage());
                if(t instanceof UserRecordFailedException) {
                    log.error("sequence number" + " " + ((UserRecordFailedException) t).getResult()
                            .getSequenceNumber());
                }
            }
            @Override
            public void onSuccess(UserRecordResult result) {
                log.info(result.getShardId() + " sequence number " + result.getSequenceNumber());
            }
        };
    }
}
