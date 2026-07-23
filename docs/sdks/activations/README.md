# GiftCards.Activations

## Overview

### Available Operations

* [Create](#create) - Activate a gift card

## Create

Activate a physical gift card through the primary gift card service.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="activate_gift_card" method="post" path="/gift-cards/activations" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.GiftCards.Activations.CreateAsync(giftCardActivationCreate: new GiftCardActivationCreate() {
    Number = "4123455541234561234",
});

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                                                                       | Type                                                                                                                                                                                                                                            | Required                                                                                                                                                                                                                                        | Description                                                                                                                                                                                                                                     | Example                                                                                                                                                                                                                                         |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `GiftCardActivationCreate`                                                                                                                                                                                                                      | [GiftCardActivationCreate](../../Models/Components/GiftCardActivationCreate.md)                                                                                                                                                                 | :heavy_check_mark:                                                                                                                                                                                                                              | N/A                                                                                                                                                                                                                                             |                                                                                                                                                                                                                                                 |
| `IdempotencyKey`                                                                                                                                                                                                                                | *string*                                                                                                                                                                                                                                        | :heavy_minus_sign:                                                                                                                                                                                                                              | A unique key that identifies this request. If supported by the gift card service, the value will be forwarded to make the activation idempotent. We recommend using V4 UUIDs, or another random string with enough entropy to avoid collisions. |                                                                                                                                                                                                                                                 |
| `MerchantAccountId`                                                                                                                                                                                                                             | *string*                                                                                                                                                                                                                                        | :heavy_minus_sign:                                                                                                                                                                                                                              | The ID of the merchant account to use for this request.                                                                                                                                                                                         | default                                                                                                                                                                                                                                         |

### Response

**[GiftCard](../../Models/Components/GiftCard.md)**

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