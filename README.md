# Dotnet
* Uses 6.0

# AWS

## Deployment
use a local profile called 'pickles'
api and message handler projects have a shell script that does the deployment

## API Gateway

When creating the integration, the Route Details should be:  ANY /{proxy+} (ID: 4chq3d7) pointing to the lambda

## Lambda

## DynamoDb
User, PK, SK

## Execution Role
* For API Lambda
* For Message Handler lambda

# Research and Integrate
* Xray

# Infra
* Lambda role
* Lambda function
* Api Gateway using Http2
* Integration using ANY/{proxy+}
* Created custom messaging bus called pickles-app-messagebus-dev
* Created event rule to route to the MessageHandler lambda

# Open Items
* See if we can wire in FluentValidation into the pipeline instead of explicitly calling it out.
