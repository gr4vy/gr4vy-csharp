# DigitalWallets.Domains

## Overview

### Available Operations

* [Create](#create) - Register a digital wallet domain
* [Delete](#delete) - Remove a digital wallet domain

## Create

Register a digital wallet domain (Apple Pay only).

### Example Usage

<!-- UsageSnippet language="csharp" operationID="register_digital_wallet_domain" method="post" path="/digital-wallets/{digital_wallet_id}/domains" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.DigitalWallets.Domains.CreateAsync(
    digitalWalletId: "1808f5e6-b49c-4db9-94fa-22371ea352f5",
    digitalWalletDomain: new DigitalWalletDomain() {
        DomainName = "example.com",
    }
);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           | Example                                                               |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `DigitalWalletId`                                                     | *string*                                                              | :heavy_check_mark:                                                    | The ID of the digital wallet to remove a domain for.                  | 1808f5e6-b49c-4db9-94fa-22371ea352f5                                  |
| `DigitalWalletDomain`                                                 | [DigitalWalletDomain](../../Models/Components/DigitalWalletDomain.md) | :heavy_check_mark:                                                    | N/A                                                                   |                                                                       |
| `MerchantAccountId`                                                   | *string*                                                              | :heavy_minus_sign:                                                    | The ID of the merchant account to use for this request.               | default                                                               |

### Response

**[object](../../Models/.md)**

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

## Delete

Remove a digital wallet domain (Apple Pay only).

### Example Usage

<!-- UsageSnippet language="csharp" operationID="unregister_digital_wallet_domain" method="delete" path="/digital-wallets/{digital_wallet_id}/domains" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

await sdk.DigitalWallets.Domains.DeleteAsync(
    digitalWalletId: "",
    digitalWalletDomain: new DigitalWalletDomain() {
        DomainName = "example.com",
    }
);

// handle response
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           | Example                                                               |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `DigitalWalletId`                                                     | *string*                                                              | :heavy_check_mark:                                                    | N/A                                                                   |                                                                       |
| `DigitalWalletDomain`                                                 | [DigitalWalletDomain](../../Models/Components/DigitalWalletDomain.md) | :heavy_check_mark:                                                    | N/A                                                                   |                                                                       |
| `MerchantAccountId`                                                   | *string*                                                              | :heavy_minus_sign:                                                    | The ID of the merchant account to use for this request.               | default                                                               |

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