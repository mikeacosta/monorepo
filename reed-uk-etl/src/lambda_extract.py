import json
import os
import requests
from datetime import datetime
import math
import boto3
import logging

logger = logging.getLogger()
logger.setLevel(logging.INFO)

# REED_APP_KEY = os.getenv('REED_APP_KEY')
REED_APP_KEY = '435d9e2a-0c9a-4af1-9512-7f8294e9ce84'
BUCKET = "a-bucket-01234"

url = "https://www.reed.co.uk/api/1.0/search"
base_params = {
  'location': 'London',
  'keywords': "data engineer",
  'distancefromlocation': 15
}


def handler(event, context):
  logger.info(f'event: {json.dumps(event)}') 

  jobs = []
  response = requests.get(url, params=base_params, auth=(REED_APP_KEY, ''))

  if response.status_code != 200:
    logger.error(f"Error: {response.status_code}, {response.text}")
    return None

  data = response.json()
  jobs.extend(data['results'])
  total_results = data['totalResults'] 
  logger.info(f"Total number of jobs = {total_results}")

  current_timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
  file_name = f"reed_raw_data_{current_timestamp}.json"
  logger.info(f"File name to store raw data: {file_name}")

  client = boto3.client('s3')
  file_key = f"raw_data/to_process/{file_name}"
  items = {"items": jobs}

  try:
    client.put_object(
        Bucket=BUCKET,
        Key=file_key,
        Body=json.dumps(items)
    )
    logger.info(f"File {file_key} successfully created in bucket {BUCKET}.")
    return file_key
  except Exception as ex:
    logger.error(f"Error occurred while creating file: {str(e)}")
    return None    