# PaymentOptions
(*PaymentOptions*)

## Overview

### Available Operations

* [List](#list) - List payment options

## List

List the payment options available at checkout. filtering by country, currency, and additional fields passed to Flow rules.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list_payment_options" method="post" path="/payment-options" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.PaymentOptions.ListAsync(paymentOptionRequest: new PaymentOptionRequest() {});

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             | Example                                                                 |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `PaymentOptionRequest`                                                  | [PaymentOptionRequest](../../Models/Components/PaymentOptionRequest.md) | :heavy_check_mark:                                                      | N/A                                                                     |                                                                         |
| `MerchantAccountId`                                                     | *string*                                                                | :heavy_minus_sign:                                                      | The ID of the merchant account to use for this request.                 | default                                                                 |

### Response

**[Models.Components.PaymentOptions](../../Models/Components/PaymentOptions.md)**

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