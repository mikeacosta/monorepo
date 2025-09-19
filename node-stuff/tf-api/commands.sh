# build the lambda function package
cd src
zip ../app.zip app.js
cd ..

# upload the package to s3
aws s3 cp app.zip s3://a-bucket-01234/v1.0.0/app.zip

# initialize the terraform working directory
terraform init

# plan the terraform changes
terraform plan -out tfplan

# apply the terraform changes
terraform apply tfplan

# invoke the lambda function
aws lambda invoke --function-name tf-lambda \
  --payload '{"name": "tf-lambda", "type": "lambda function"}' \
  response.json \
  --cli-binary-format raw-in-base64-out

# view the response
cat response.json

# clean up
terraform destroy -auto-approve
aws s3 rm s3://a-bucket-01234/v1.0.0/app.zip
rm -rf .terraform
rm .terraform.lock.hcl
rm app.zip response.json tfplan