# GiftCards.Issuances

## Overview

### Available Operations

* [Create](#create) - Issue a gift card

## Create

Issue a new virtual gift card through the primary gift card service.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="issue_gift_card" method="post" path="/gift-cards/issuances" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.GiftCards.Issuances.CreateAsync(giftCardIssuanceCreate: new GiftCardIssuanceCreate() {
    Theme = "031111372",
    Amount = 5000,
    Currency = "EUR",
});

// handle response
```

### Parameters

| Parameter                                                                        | Type                                                                             | Required                                                                         | Description                                                                      | Example                                                                          |
| -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| `GiftCardIssuanceCreate`                                                         | [GiftCardIssuanceCreate](../../Models/Components/GiftCardIssuanceCreate.md)      | :heavy_check_mark:                                                               | N/A                                                                              |                                                                                  |
| `IdempotencyKey`                                                                 | *string*                                                                         | :heavy_minus_sign:                                                               | A unique key forwarded to the gift card service to make the issuance idempotent. |                                                                                  |
| `MerchantAccountId`                                                              | *string*                                                                         | :heavy_minus_sign:                                                               | The ID of the merchant account to use for this request.                          | default                                                                          |

### Response

**[GiftCardIssuance](../../Models/Components/GiftCardIssuance.md)**

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