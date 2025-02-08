# build
sam build --template-file template.yaml

# package cloudformation
sam package --s3-bucket a-bucket-01234

 # deploy
sam deploy --stack-name reed-uk-stack \
  --s3-bucket a-bucket-01234 \
  --capabilities CAPABILITY_IAM

# clean up
aws cloudformation delete-stack --stack-name reed-uk-stack   