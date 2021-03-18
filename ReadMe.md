# Publishing and Sharing

This repository shows how services can be published and shared across accounts.

## Bitcoin.Topic

The _Bitcoin.Topic_ module creates a Lambda function that publishes the most recent bitcoin price on an SNS topic. The SNS topic is exported from the CloudFormation stack so that other stacks can subscribe to it.

## Bitcoin.Table

The _Bitcoin.Table_ module creates a Lambda function that subscribes to the SNS topic from the _BitcoinTopic_ stack and stores the received value in a DynamoDB table. Stored values are automatically forgotten after 15 minutes to minimize the number of stored rows. The DynamoDB table is exported for other stacks to query against.

## Bitcoin.Activity

The _Bitcoin.Activity_ module creates a REST API for recording buy/sell activity. It imports the table from the _BitcoinTable_ stack to fetch the most recently recorded price.

A Postman collection is provided to easily interact with the REST API.

## Deploy

```bash
lash deploy \
    Bitcoin.Topic:1.0@serverlesspatterns \
    Bitcoin.Table:1.0@serverlesspatterns \
    Bitcoin.Activity:1.0@serverlesspatterns
```