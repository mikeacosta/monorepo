# create SQS
aws cloudformation create-stack \
  --stack-name sqs-stack \
  --template-body file://queue.yaml

# delete SQS
aws cloudformation delete-stack --stack-name sqs-stack  