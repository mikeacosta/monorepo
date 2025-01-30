# package data stream
aws cloudformation package --s3-bucket a-bucket-01234 \
  --template-file template.yaml \
  --output-template-file gen/template_generated.yaml

# deploy data stream
aws cloudformation deploy --template-file gen/template_generated.yaml \
  --stack-name aws-data-stream-stack

# delete data stream
aws cloudformation delete-stack --stack-name aws-data-stream-stack
