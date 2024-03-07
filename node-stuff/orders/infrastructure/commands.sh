# create service role
aws cloudformation create-stack \
  --stack-name orders-service-role \
  --template-body file://service-role.yaml \
  --capabilities CAPABILITY_NAMED_IAM

# create table
aws cloudformation create-stack \
  --stack-name orders-table \
  --template-body file://table.yaml \
  --role-arn "arn:aws:iam::489967615225:role/Orders-CloudFormation-ServiceRole"

# delete table
aws cloudformation delete-stack --stack-name orders-table

# delete service-role
aws cloudformation delete-stack --stack-name orders-service-role