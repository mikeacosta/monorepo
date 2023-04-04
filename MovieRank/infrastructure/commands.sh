# deploy DynamoDB
aws cloudformation deploy --template-file dynamodb.yaml --stack-name MovieRankDynamoDB

# delete stack
aws cloudformation delete-stack --stack-name MovieRankDynamoDB