# create service role
aws cloudformation create-stack \
  --stack-name album-rank-service-role \
  --template-body file://service-role.yaml \
  --capabilities CAPABILITY_NAMED_IAM

# create table
aws cloudformation create-stack \
  --stack-name album-rank-table \
  --template-body file://table.yaml \
  --role-arn "arn:aws:iam::489967615225:role/AlbumRank-Cloudformation-ServiceRole"