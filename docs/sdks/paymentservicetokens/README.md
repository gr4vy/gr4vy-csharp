# PaymentServiceTokens
(*PaymentMethods.PaymentServiceTokens*)

## Overview

### Available Operations

* [List](#list) - List payment service tokens
* [Create](#create) - Create payment service token
* [Delete](#delete) - Delete payment service token

## List

List all gateway tokens stored for a payment method.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PaymentMethods.PaymentServiceTokens.ListAsync(
    paymentMethodId: "ef9496d8-53a5-4aad-8ca2-00eb68334389",
    paymentServiceId: "fffd152a-9532-4087-9a4f-de58754210f0",
    merchantAccountId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `PaymentMethodId`                                       | *string*                                                | :heavy_check_mark:                                      | The ID of the payment method                            | ef9496d8-53a5-4aad-8ca2-00eb68334389                    |
| `PaymentServiceId`                                      | *string*                                                | :heavy_minus_sign:                                      | The ID of the payment service                           | fffd152a-9532-4087-9a4f-de58754210f0                    |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. |                                                         |

### Response

**[ListPaymentMethodPaymentServiceTokensResponse](../../Models/Requests/ListPaymentMethodPaymentServiceTokensResponse.md)**

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

## Create

Create a gateway tokens for a payment method.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PaymentMethods.PaymentServiceTokens.CreateAsync(
    paymentMethodId: "ef9496d8-53a5-4aad-8ca2-00eb68334389",
    paymentServiceTokenCreate: new PaymentServiceTokenCreate() {
        SecurityCode = "123",
        PaymentServiceId = "fffd152a-9532-4087-9a4f-de58754210f0",
        RedirectUrl = "https://probable-heating.com/",
    },
    timeoutInSeconds: 1D,
    merchantAccountId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       | Example                                                                           |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `PaymentMethodId`                                                                 | *string*                                                                          | :heavy_check_mark:                                                                | The ID of the payment method                                                      | ef9496d8-53a5-4aad-8ca2-00eb68334389                                              |
| `PaymentServiceTokenCreate`                                                       | [PaymentServiceTokenCreate](../../Models/Components/PaymentServiceTokenCreate.md) | :heavy_check_mark:                                                                | N/A                                                                               |                                                                                   |
| `TimeoutInSeconds`                                                                | *double*                                                                          | :heavy_minus_sign:                                                                | N/A                                                                               |                                                                                   |
| `MerchantAccountId`                                                               | *string*                                                                          | :heavy_minus_sign:                                                                | The ID of the merchant account to use for this request.                           |                                                                                   |

### Response

**[CreatePaymentMethodPaymentServiceTokenResponse](../../Models/Requests/CreatePaymentMethodPaymentServiceTokenResponse.md)**

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

## Delete

Delete a gateway tokens for a payment method.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PaymentMethods.PaymentServiceTokens.DeleteAsync(
    paymentMethodId: "ef9496d8-53a5-4aad-8ca2-00eb68334389",
    paymentServiceTokenId: "703f2d99-3fd1-44bc-9cbd-a25a2d597886",
    timeoutInSeconds: 1D,
    merchantAccountId: "<id>"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `PaymentMethodId`                                       | *string*                                                | :heavy_check_mark:                                      | The ID of the payment method                            | ef9496d8-53a5-4aad-8ca2-00eb68334389                    |
| `PaymentServiceTokenId`                                 | *string*                                                | :heavy_check_mark:                                      | The ID of the payment service token                     | 703f2d99-3fd1-44bc-9cbd-a25a2d597886                    |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. |                                                         |

### Response

**[DeletePaymentMethodPaymentServiceTokenResponse](../../Models/Requests/DeletePaymentMethodPaymentServiceTokenResponse.md)**

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