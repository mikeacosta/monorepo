# create service role
aws cloudformation create-stack \
  --stack-name goal-sns-service-role \
  --template-body file://service-role.yaml \
  --capabilities CAPABILITY_NAMED_IAM

# create SNS topic
aws cloudformation create-stack \
  --stack-name goal-sns-topic \
  --template-body file://template.yaml \
  --role-arn "arn:aws:iam::489967615225:role/GoalSnsTopic-CloudFormation-ServiceRole"

# delete SNS topic
aws cloudformation delete-stack --stack-name goal-sns-topic

# delete service-role
aws cloudformation delete-stack --stack-name goal-sns-service-role