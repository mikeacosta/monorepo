# package cloudformation
aws cloudformation package --s3-bucket a-bucket-01234 \
  --template-file template.yaml \
  --output-template-file gen/template-generated.yaml  

 # deploy
aws cloudformation deploy \
  --template-file gen/template-generated.yaml \
  --stack-name sqs-lambda-stack \
  --capabilities CAPABILITY_IAM

# delete SQS
aws cloudformation delete-stack --stack-name sqs-lambda-stack  