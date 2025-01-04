# package cloudformation
aws cloudformation package --s3-bucket a-bucket-01234 \
  --template-file template.yaml \
  --output-template-file gen/template-generated.yaml

# deploy
aws cloudformation deploy \
  --template-file gen/template-generated.yaml \
  --stack-name checklist-api-stack \
  --capabilities CAPABILITY_IAM  

# write data
aws dynamodb batch-write-item --request-items file://list-items.json 

# get API Gateway URL
aws cloudformation describe-stacks --stack-name checklist-api-stack \
  --query 'Stacks[0].Outputs[?OutputKey==`ApiInvokeUrl`].OutputValue' \
  --output text  

# clean up
aws cloudformation delete-stack --stack-name checklist-api-stack  