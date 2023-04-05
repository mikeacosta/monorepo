# create DynamoDB table
aws cloudformation deploy --template-file dynamodb.yaml --stack-name MovieRankDynamoDB

# add items to table
aws dynamodb batch-write-item --request-items file://items.json

# delete stack
aws cloudformation delete-stack --stack-name MovieRankDynamoDB