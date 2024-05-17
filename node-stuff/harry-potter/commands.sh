# create service role
aws cloudformation create-stack \
  --stack-name hp-service-role-stack \
  --template-body file://service-role.yaml \
  --capabilities CAPABILITY_NAMED_IAM

# get stack status
aws cloudformation describe-stacks --stack-name hp-service-role-stack

# get service role ARN
aws iam get-role --role-name HarryPotter-CloudFormation-ServiceRole

# create table
aws cloudformation create-stack \
  --stack-name hp-table-stack \
  --template-body file://table.yaml \
  --role-arn "arn:aws:iam::489967615225:role/HarryPotter-CloudFormation-ServiceRole"

# delete table
aws cloudformation delete-stack --stack-name hp-table-stack

# delete service-role
aws cloudformation delete-stack --stack-name hp-service-role-stack