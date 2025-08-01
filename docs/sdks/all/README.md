# All
(*Transactions.Refunds.All*)

## Overview

### Available Operations

* [Create](#create) - Create batch transaction refund

## Create

Create a refund for all instruments on a transaction.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create_full_transaction_refund" method="post" path="/transactions/{transaction_id}/refunds/all" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.Transactions.Refunds.All.CreateAsync(
    transactionId: "7099948d-7286-47e4-aad8-b68f7eb44591",
    transactionRefundAllCreate: new TransactionRefundAllCreate() {
        Reason = "Refund due to user request.",
        ExternalIdentifier = "refund-12345",
    }
);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         | Example                                                                             |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `TransactionId`                                                                     | *string*                                                                            | :heavy_check_mark:                                                                  | The ID of the transaction                                                           | 7099948d-7286-47e4-aad8-b68f7eb44591                                                |
| `MerchantAccountId`                                                                 | *string*                                                                            | :heavy_minus_sign:                                                                  | The ID of the merchant account to use for this request.                             | default                                                                             |
| `TransactionRefundAllCreate`                                                        | [TransactionRefundAllCreate](../../Models/Components/TransactionRefundAllCreate.md) | :heavy_minus_sign:                                                                  | N/A                                                                                 |                                                                                     |

### Response

**[Models.Components.Refunds](../../Models/Components/Refunds.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| Gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| Gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error404            | 404                                     | application/json                        |
| Gr4vy.Models.Errors.Error405            | 405                                     | application/json                        |
| Gr4vy.Models.Errors.Error409            | 409                                     | application/json                        |
| Gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| Gr4vy.Models.Errors.Error425            | 425                                     | application/json                        |
| Gr4vy.Models.Errors.Error429            | 429                                     | application/json                        |
| Gr4vy.Models.Errors.Error500            | 500                                     | application/json                        |
| Gr4vy.Models.Errors.Error502            | 502                                     | application/json                        |
| Gr4vy.Models.Errors.Error504            | 504                                     | application/json                        |
| Gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |