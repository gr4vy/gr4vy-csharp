# Events
(*Transactions.Events*)

## Overview

### Available Operations

* [List](#list) - List transaction events

## List

Fetch a list of events for a transaction.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Transactions.Events.ListAsync(
    transactionId: "7099948d-7286-47e4-aad8-b68f7eb44591",
    cursor: "ZXhhbXBsZTE",
    limit: 100,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `TransactionId`                                         | *string*                                                | :heavy_check_mark:                                      | N/A                                                     | 7099948d-7286-47e4-aad8-b68f7eb44591                    |
| `Cursor`                                                | *string*                                                | :heavy_minus_sign:                                      | A pointer to the page of results to return.             | ZXhhbXBsZTE                                             |
| `Limit`                                                 | *long*                                                  | :heavy_minus_sign:                                      | The maximum number of items that are at returned.       | 100                                                     |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[CollectionTransactionEvent](../../Models/Components/CollectionTransactionEvent.md)**

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