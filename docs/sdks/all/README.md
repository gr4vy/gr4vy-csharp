# All
(*Transactions.Refunds.All*)

## Overview

### Available Operations

* [Create](#create) - Create batch transaction refund

## Create

Create a refund for all instruments on a transaction.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Transactions.Refunds.All.CreateAsync(
    transactionId: "7099948d-7286-47e4-aad8-b68f7eb44591",
    timeoutInSeconds: 1D,
    merchantAccountId: "<id>",
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
| `TransactionId`                                                                     | *string*                                                                            | :heavy_check_mark:                                                                  | N/A                                                                                 | 7099948d-7286-47e4-aad8-b68f7eb44591                                                |
| `TimeoutInSeconds`                                                                  | *double*                                                                            | :heavy_minus_sign:                                                                  | N/A                                                                                 |                                                                                     |
| `MerchantAccountId`                                                                 | *string*                                                                            | :heavy_minus_sign:                                                                  | The ID of the merchant account to use for this request.                             |                                                                                     |
| `TransactionRefundAllCreate`                                                        | [TransactionRefundAllCreate](../../Models/Components/TransactionRefundAllCreate.md) | :heavy_minus_sign:                                                                  | N/A                                                                                 |                                                                                     |

### Response

**[CreateFullTransactionRefundResponse](../../Models/Requests/CreateFullTransactionRefundResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Forbidden   | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Active      | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error404            | 404                                     | application/json                        |
| gr4vy.Models.Errors.Error405            | 405                                     | application/json                        |
| gr4vy.Models.Errors.Error409            | 409                                     | application/json                        |
| gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| gr4vy.Models.Errors.Error425            | 425                                     | application/json                        |
| gr4vy.Models.Errors.Error429            | 429                                     | application/json                        |
| gr4vy.Models.Errors.Error500            | 500                                     | application/json                        |
| gr4vy.Models.Errors.Error502            | 502                                     | application/json                        |
| gr4vy.Models.Errors.Error504            | 504                                     | application/json                        |
| gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |