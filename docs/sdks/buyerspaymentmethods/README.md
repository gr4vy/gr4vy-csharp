# BuyersPaymentMethods
(*Buyers.PaymentMethods*)

## Overview

### Available Operations

* [List](#list) - List payment methods for a buyer

## List

List all the stored payment methods for a specific buyer.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list_buyer_payment_methods" method="get" path="/buyers/payment-methods" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
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

**[PaymentMethodSummaries](../../Models/Components/PaymentMethodSummaries.md)**

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