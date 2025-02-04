import json
import boto3
import botocore
import logging

logger = logging.getLogger()
logger.setLevel(logging.INFO)

def handler(event, context):
  print(json.dumps(event))
  logger.info(f'boto3 version: {boto3.__version__}')
  logger.info(f'botocore version: {botocore.__version__}')  