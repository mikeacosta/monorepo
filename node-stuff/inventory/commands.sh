# package cloudformation
aws cloudformation package --s3-bucket a-bucket-01234 \
  --template-file template.yaml \
  --output-template-file gen/template-generated.yaml

 # deploy
aws cloudformation deploy \
  --template-file gen/template-generated.yaml \
  --stack-name inventory-api-stack \
  --capabilities CAPABILITY_IAM

# write data
aws dynamodb batch-write-item --request-items file://inventory-items.json 

# clean up
aws cloudformation delete-stack --stack-name inventory-api-stack  