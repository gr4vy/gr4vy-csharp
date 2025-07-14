# Transactions
(*Transactions*)

## Overview

### Available Operations

* [List](#list) - List transactions
* [Create](#create) - Create transaction
* [Get](#get) - Get transaction
* [Capture](#capture) - Capture transaction
* [Void](#void) - Void transaction
* [Sync](#sync) - Sync transaction

## List

Returns a paginated list of transactions for the merchant account, sorted by most recently updated. You can filter, sort, and search transactions using query parameters.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;
using System;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

ListTransactionsRequest req = new ListTransactionsRequest() {
    Cursor = "ZXhhbXBsZTE",
    CreatedAtLte = System.DateTime.Parse("2022-01-01T12:00:00+08:00"),
    CreatedAtGte = System.DateTime.Parse("2022-01-01T12:00:00+08:00"),
    UpdatedAtLte = System.DateTime.Parse("2022-01-01T12:00:00+08:00"),
    UpdatedAtGte = System.DateTime.Parse("2022-01-01T12:00:00+08:00"),
    Search = "transaction-12345",
    BuyerExternalIdentifier = "buyer-12345",
    BuyerId = "fe26475d-ec3e-4884-9553-f7356683f7f9",
    BuyerEmailAddress = "john@example.com",
    BuyerSearch = new List<string>() {
        "J",
        "o",
        "h",
        "n",
    },
    IpAddress = "8.214.133.47",
    Status = new List<string>() {
        "authorization_succeeded",
    },
    Id = "7099948d-7286-47e4-aad8-b68f7eb44591",
    PaymentServiceTransactionId = "tx-12345",
    ExternalIdentifier = "transaction-12345",
    Metadata = new List<string>() {
        "{\"first_key\":\"first_value\",\"second_key\":\"second_value\"}",
    },
    AmountEq = 1299,
    AmountLte = 1299,
    AmountGte = 1299,
    Currency = new List<string>() {
        "USD",
    },
    Country = new List<string>() {
        "US",
    },
    PaymentServiceId = new List<string>() {
        "fffd152a-9532-4087-9a4f-de58754210f0",
    },
    PaymentMethodId = "ef9496d8-53a5-4aad-8ca2-00eb68334389",
    PaymentMethodLabel = "1234",
    PaymentMethodScheme = new List<string>() {
        "[",
        "\"",
        "v",
        "i",
        "s",
        "a",
        "\"",
        "]",
    },
    PaymentMethodCountry = "[\"US\"]",
    PaymentMethodFingerprint = "a50b85c200ee0795d6fd33a5c66f37a4564f554355c5b46a756aac485dd168a4",
    Method = new List<string>() {
        "card",
    },
    ErrorCode = new List<string>() {
        "insufficient_funds",
    },
    HasRefunds = true,
    PendingReview = true,
    CheckoutSessionId = "4137b1cf-39ac-42a8-bad6-1c680d5dab6b",
    ReconciliationId = "7jZXl4gBUNl0CnaLEnfXbt",
    HasGiftCardRedemptions = true,
    GiftCardId = "356d56e5-fe16-42ae-97ee-8d55d846ae2e",
    GiftCardLast4 = "7890",
    HasSettlements = true,
    PaymentMethodBin = "411111",
    PaymentSource = new List<string>() {
        "recurring",
    },
    IsSubsequentPayment = true,
    MerchantInitiated = true,
    Used3ds = true,
};

ListTransactionsResponse? res = await sdk.Transactions.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `request`                                                                   | [ListTransactionsRequest](../../Models/Requests/ListTransactionsRequest.md) | :heavy_check_mark:                                                          | The request object to use for the request.                                  |

### Response

**[ListTransactionsResponse](../../Models/Requests/ListTransactionsResponse.md)**

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

## Create

Create a new transaction using a supported payment method. If additional buyer authorization is required, an approval URL will be returned. Duplicated gift card numbers are not supported.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.Transactions.CreateAsync(
    transactionCreate: new TransactionCreate() {
        Amount = 1299,
        Currency = "EUR",
        Store = true,
        IsSubsequentPayment = true,
        MerchantInitiated = true,
        AsyncCapture = true,
        AccountFundingTransaction = true,
    },
    idempotencyKey: "request-12345"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                             | Type                                                                                                                                                                                                  | Required                                                                                                                                                                                              | Description                                                                                                                                                                                           | Example                                                                                                                                                                                               |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `TransactionCreate`                                                                                                                                                                                   | [TransactionCreate](../../Models/Components/TransactionCreate.md)                                                                                                                                     | :heavy_check_mark:                                                                                                                                                                                    | N/A                                                                                                                                                                                                   |                                                                                                                                                                                                       |
| `MerchantAccountId`                                                                                                                                                                                   | *string*                                                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                                                    | The ID of the merchant account to use for this request.                                                                                                                                               | default                                                                                                                                                                                               |
| `IdempotencyKey`                                                                                                                                                                                      | *string*                                                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                                                    | A unique key that identifies this request. Providing this header will make this an idempotent request. We recommend using V4 UUIDs, or another random string with enough entropy to avoid collisions. | request-12345                                                                                                                                                                                         |
| `XForwardedFor`                                                                                                                                                                                       | *string*                                                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                                                    | The IP address to forward from the customer. Use this when calling<br/>our API from the server side to ensure the customer's address is<br/>passed to downstream services, rather than your server IP. | 192.168.0.2                                                                                                                                                                                           |

### Response

**[Transaction](../../Models/Components/Transaction.md)**

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

## Get

Retrieve the details of a transaction by its unique identifier.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.Transactions.GetAsync(transactionId: "7099948d-7286-47e4-aad8-b68f7eb44591");

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `TransactionId`                                         | *string*                                                | :heavy_check_mark:                                      | The ID of the transaction                               | 7099948d-7286-47e4-aad8-b68f7eb44591                    |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[Transaction](../../Models/Components/Transaction.md)**

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

## Capture

Captures a previously authorized transaction. You can capture the full or a partial amount, as long as it does not exceed the authorized amount (unless over-capture is enabled).

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.Transactions.CaptureAsync(
    transactionId: "7099948d-7286-47e4-aad8-b68f7eb44591",
    transactionCapture: new TransactionCapture() {}
);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `TransactionId`                                                     | *string*                                                            | :heavy_check_mark:                                                  | The ID of the transaction                                           | 7099948d-7286-47e4-aad8-b68f7eb44591                                |
| `TransactionCapture`                                                | [TransactionCapture](../../Models/Components/TransactionCapture.md) | :heavy_check_mark:                                                  | N/A                                                                 |                                                                     |
| `MerchantAccountId`                                                 | *string*                                                            | :heavy_minus_sign:                                                  | The ID of the merchant account to use for this request.             | default                                                             |

### Response

**[Transaction](../../Models/Components/Transaction.md)**

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

## Void

Voids a previously authorized transaction. If the transaction was not yet successfully authorized, or was already captured, the void will not be processed. This operation releases the hold on the buyer's funds. Captured transactions can be refunded instead.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.Transactions.VoidAsync(transactionId: "7099948d-7286-47e4-aad8-b68f7eb44591");

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `TransactionId`                                         | *string*                                                | :heavy_check_mark:                                      | The ID of the transaction                               | 7099948d-7286-47e4-aad8-b68f7eb44591                    |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[Transaction](../../Models/Components/Transaction.md)**

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

## Sync

Synchronizes the status of a transaction with the underlying payment service provider. This is useful for transactions in a pending state to check if they've been completed or failed. Only available for some payment service providers.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.Transactions.SyncAsync(transactionId: "2ee546e0-3b11-478e-afec-fdb362611e22");

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `TransactionId`                                         | *string*                                                | :heavy_check_mark:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[Transaction](../../Models/Components/Transaction.md)**

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