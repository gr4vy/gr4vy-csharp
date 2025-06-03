# Balances
(*GiftCards.Balances*)

## Overview

### Available Operations

* [List](#list) - List gift card balances

## List

Fetch the balances for one or more gift cards.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.GiftCards.Balances.ListAsync(
    giftCardBalanceRequest: new GiftCardBalanceRequest() {
        Items = new List<Item>() {
            Item.CreateGiftCardStoredRequest(
                new GiftCardStoredRequest() {
                    Id = "356d56e5-fe16-42ae-97ee-8d55d846ae2e",
                }
            ),
        },
    },
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 | Example                                                                     |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `GiftCardBalanceRequest`                                                    | [GiftCardBalanceRequest](../../Models/Components/GiftCardBalanceRequest.md) | :heavy_check_mark:                                                          | N/A                                                                         |                                                                             |
| `MerchantAccountId`                                                         | *string*                                                                    | :heavy_minus_sign:                                                          | The ID of the merchant account to use for this request.                     | default                                                                     |

### Response

**[CollectionNoCursorGiftCardSummary](../../Models/Components/CollectionNoCursorGiftCardSummary.md)**

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