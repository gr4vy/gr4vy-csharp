# Gr4vy SDK

## Overview

Gr4vy: The Gr4vy API.

### Available Operations

* [BrowsePaymentMethodDefinitionsGet](#browsepaymentmethoddefinitionsget) - Browse

## BrowsePaymentMethodDefinitionsGet

Browse

### Example Usage

<!-- UsageSnippet language="csharp" operationID="browse_payment_method_definitions_get" method="get" path="/payment-method-definitions" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.BrowsePaymentMethodDefinitionsGetAsync();

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[object](../../Models/.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| Gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |