# MerchantAccounts
(*MerchantAccounts*)

## Overview

### Available Operations

* [List](#list) - List all merchant accounts
* [Create](#create) - Create a merchant account
* [Get](#get) - Get a merchant account
* [Update](#update) - Update a merchant account

## List

List all merchant accounts in an instance.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

ListMerchantAccountsResponse? res = await sdk.MerchantAccounts.ListAsync(
    cursor: "ZXhhbXBsZTE",
    limit: 20,
    search: "merchant-12345"
);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                         | Type                                              | Required                                          | Description                                       | Example                                           |
| ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- |
| `Cursor`                                          | *string*                                          | :heavy_minus_sign:                                | A pointer to the page of results to return.       | ZXhhbXBsZTE                                       |
| `Limit`                                           | *long*                                            | :heavy_minus_sign:                                | The maximum number of items that are at returned. | 20                                                |
| `Search`                                          | *string*                                          | :heavy_minus_sign:                                | The search term to filter merchant accounts by.   | merchant-12345                                    |

### Response

**[ListMerchantAccountsResponse](../../Models/Requests/ListMerchantAccountsResponse.md)**

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

Create a new merchant account in an instance.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.MerchantAccounts.CreateAsync(
    merchantAccountCreate: new MerchantAccountCreate() {
        AccountUpdaterRequestEncryptionKey = "key-1234",
        AccountUpdaterRequestEncryptionKeyId = "key-id-1234",
        AccountUpdaterResponseDecryptionKey = "key-1234",
        AccountUpdaterResponseDecryptionKeyId = "key-id-1234",
        OverCaptureAmount = 1299,
        OverCapturePercentage = 25,
        LoonClientKey = "client-key-1234",
        LoonSecretKey = "key-12345",
        LoonAcceptedSchemes = new List<CardScheme>() {
            CardScheme.Visa,
        },
        VisaNetworkTokensRequestorId = "id-12345",
        VisaNetworkTokensAppId = "id-12345",
        AmexNetworkTokensRequestorId = "id-12345",
        AmexNetworkTokensAppId = "id-12345",
        MastercardNetworkTokensRequestorId = "id-12345",
        MastercardNetworkTokensAppId = "id-12345",
        OutboundWebhookUrl = "https://example.com/callback",
        OutboundWebhookUsername = "user-12345",
        OutboundWebhookPassword = "password-12345",
        Id = "merchant-12345",
        DisplayName = "Example",
    },
    timeoutInSeconds: 1D
);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `MerchantAccountCreate`                                                   | [MerchantAccountCreate](../../Models/Components/MerchantAccountCreate.md) | :heavy_check_mark:                                                        | N/A                                                                       |
| `TimeoutInSeconds`                                                        | *double*                                                                  | :heavy_minus_sign:                                                        | N/A                                                                       |

### Response

**[MerchantAccount](../../Models/Components/MerchantAccount.md)**

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

Get info about a merchant account in an instance.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.MerchantAccounts.GetAsync(merchantAccountId: "merchant-12345");

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    | Example                        |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `MerchantAccountId`            | *string*                       | :heavy_check_mark:             | The ID of the merchant account | merchant-12345                 |

### Response

**[MerchantAccount](../../Models/Components/MerchantAccount.md)**

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

## Update

Update info for a merchant account in an instance.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.MerchantAccounts.UpdateAsync(
    merchantAccountId: "merchant-12345",
    merchantAccountUpdate: new MerchantAccountUpdate() {
        AccountUpdaterRequestEncryptionKey = "key-1234",
        AccountUpdaterRequestEncryptionKeyId = "key-id-1234",
        AccountUpdaterResponseDecryptionKey = "key-1234",
        AccountUpdaterResponseDecryptionKeyId = "key-id-1234",
        OverCaptureAmount = 1299,
        OverCapturePercentage = 25,
        LoonClientKey = "client-key-1234",
        LoonSecretKey = "key-12345",
        LoonAcceptedSchemes = new List<CardScheme>() {
            CardScheme.Visa,
        },
        VisaNetworkTokensRequestorId = "id-12345",
        VisaNetworkTokensAppId = "id-12345",
        AmexNetworkTokensRequestorId = "id-12345",
        AmexNetworkTokensAppId = "id-12345",
        MastercardNetworkTokensRequestorId = "id-12345",
        MastercardNetworkTokensAppId = "id-12345",
        DisplayName = "Example",
        OutboundWebhookUrl = "https://example.com/callback",
        OutboundWebhookUsername = "user-12345",
        OutboundWebhookPassword = "password-12345",
    },
    timeoutInSeconds: 1D
);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               | Example                                                                   |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `MerchantAccountId`                                                       | *string*                                                                  | :heavy_check_mark:                                                        | The ID of the merchant account                                            | merchant-12345                                                            |
| `MerchantAccountUpdate`                                                   | [MerchantAccountUpdate](../../Models/Components/MerchantAccountUpdate.md) | :heavy_check_mark:                                                        | N/A                                                                       |                                                                           |
| `TimeoutInSeconds`                                                        | *double*                                                                  | :heavy_minus_sign:                                                        | N/A                                                                       |                                                                           |

### Response

**[MerchantAccount](../../Models/Components/MerchantAccount.md)**

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