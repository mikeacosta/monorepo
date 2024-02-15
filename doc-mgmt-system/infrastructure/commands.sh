# create service role
aws cloudformation create-stack \
  --stack-name doc-mgmt-system-service-role \
  --template-body file://service-role.yaml \
  --capabilities CAPABILITY_NAMED_IAM

# create table
aws cloudformation create-stack \
  --stack-name documents-table \
  --template-body file://database.yaml \
  --role-arn "arn:aws:iam::489967615225:role/DocMgmtSystem-CloudFormation-ServiceRole"

# delete table
aws cloudformation delete-stack --stack-name documents-table

# delete service-role
aws cloudformation delete-stack --stack-name doc-mgmt-system-service-role