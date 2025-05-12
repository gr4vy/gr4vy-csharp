# PaymentOptions
(*PaymentOptions*)

## Overview

### Available Operations

* [List](#list) - List payment options

## List

List the payment options available at checkout. filtering by country, currency, and additional fields passed to Flow rules.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.PaymentOptions.ListAsync(
    paymentOptionRequest: new PaymentOptionRequest() {
        Metadata = new Dictionary<string, string>() {
            { "cohort", "a" },
        },
        Country = "US",
        Currency = "USD",
        Amount = 1299,
        CartItems = new List<CartItem>() {
            new CartItem() {
                Name = "GoPro HD",
                Quantity = 2,
                UnitAmount = 1299,
                DiscountAmount = 0,
                TaxAmount = 0,
                ExternalIdentifier = "goprohd",
                Sku = "GPHD1078",
                ProductUrl = "https://example.com/catalog/go-pro-hd",
                ImageUrl = "https://example.com/images/go-pro-hd.jpg",
                Categories = new List<string>() {
                    "camera",
                    "travel",
                    "gear",
                },
                ProductType = ProductType.Physical,
                SellerCountry = "GB",
            },
        },
    },
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             | Example                                                                 |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `PaymentOptionRequest`                                                  | [PaymentOptionRequest](../../Models/Components/PaymentOptionRequest.md) | :heavy_check_mark:                                                      | N/A                                                                     |                                                                         |
| `MerchantAccountId`                                                     | *string*                                                                | :heavy_minus_sign:                                                      | The ID of the merchant account to use for this request.                 | default                                                                 |

### Response

**[CollectionNoCursorPaymentOption](../../Models/Components/CollectionNoCursorPaymentOption.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| Gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| Gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error403Forbidden   | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error403Active      | 403                                     | application/json                        |
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