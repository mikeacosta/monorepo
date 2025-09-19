provider "aws" {
  region = "us-west-2"
}

resource "aws_lambda_function" "app_lambda" {
  function_name = "tf-lambda"

  s3_bucket = "a-bucket-01234"
  s3_key    = "v1.0.0/app.zip"

  handler = "app.handler"
  runtime = "nodejs22.x"

  role = data.aws_iam_role.existing_lambda_role_data.arn
}

data "aws_iam_role" "existing_lambda_role_data" {
  name = "lambda-basic-execution-role"
}