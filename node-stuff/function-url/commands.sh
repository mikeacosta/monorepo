# package cloudformation
aws cloudformation package --s3-bucket a-bucket-01234 \
  --template-file template.yaml \
  --output-template-file gen/template-generated.yaml

 # deploy
aws cloudformation deploy \
  --template-file gen/template-generated.yaml \
  --stack-name function-url-stack \
  --parameter-overrides file://params.json \
  --capabilities CAPABILITY_IAM

# clean up
aws cloudformation delete-stack --stack-name function-url-stack 