# Cryptogram
(*PaymentMethods.NetworkTokens.Cryptogram*)

## Overview

### Available Operations

* [Create](#create) - Provision network token cryptogram

## Create

Provision a cryptogram for a network token.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.PaymentMethods.NetworkTokens.Cryptogram.CreateAsync(
    paymentMethodId: "ef9496d8-53a5-4aad-8ca2-00eb68334389",
    networkTokenId: "f8dd5cfc-7834-4847-95dc-f75a360e2298",
    cryptogramCreate: new CryptogramCreate() {
        MerchantInitiated = false,
    }
);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     | Example                                                         |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `PaymentMethodId`                                               | *string*                                                        | :heavy_check_mark:                                              | The ID of the payment method                                    | ef9496d8-53a5-4aad-8ca2-00eb68334389                            |
| `NetworkTokenId`                                                | *string*                                                        | :heavy_check_mark:                                              | The ID of the network token                                     | f8dd5cfc-7834-4847-95dc-f75a360e2298                            |
| `CryptogramCreate`                                              | [CryptogramCreate](../../Models/Components/CryptogramCreate.md) | :heavy_check_mark:                                              | N/A                                                             |                                                                 |
| `MerchantAccountId`                                             | *string*                                                        | :heavy_minus_sign:                                              | The ID of the merchant account to use for this request.         | default                                                         |

### Response

**[Models.Components.Cryptogram](../../Models/Components/Cryptogram.md)**

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