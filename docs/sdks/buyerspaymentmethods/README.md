# BuyersPaymentMethods
(*Buyers.PaymentMethods*)

## Overview

### Available Operations

* [List](#list) - List payment methods for a buyer

## List

List all the stored payment methods for a specific buyer.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;
using gr4vy.Models.Requests;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

ListBuyerPaymentMethodsRequest req = new ListBuyerPaymentMethodsRequest() {
    BuyerId = "fe26475d-ec3e-4884-9553-f7356683f7f9",
    BuyerExternalIdentifier = "buyer-12345",
    Country = "US",
    Currency = "USD",
};

var res = await sdk.Buyers.PaymentMethods.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                 | Type                                                                                      | Required                                                                                  | Description                                                                               |
| ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| `request`                                                                                 | [ListBuyerPaymentMethodsRequest](../../Models/Requests/ListBuyerPaymentMethodsRequest.md) | :heavy_check_mark:                                                                        | The request object to use for the request.                                                |

### Response

**[ListBuyerPaymentMethodsResponse](../../Models/Requests/ListBuyerPaymentMethodsResponse.md)**

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