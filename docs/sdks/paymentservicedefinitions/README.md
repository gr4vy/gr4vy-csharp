# PaymentServiceDefinitions
(*PaymentServiceDefinitions*)

## Overview

### Available Operations

* [List](#list) - List payment service definitions
* [Get](#get) - Get a payment service definition
* [Session](#session) - Create a session for a payment service definition

## List

List the definitions of each payment service that can be configured.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListPaymentServiceDefinitionsResponse? res = await sdk.PaymentServiceDefinitions.ListAsync(
    cursor: "ZXhhbXBsZTE",
    limit: 20
);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                         | Type                                              | Required                                          | Description                                       | Example                                           |
| ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- | ------------------------------------------------- |
| `Cursor`                                          | *string*                                          | :heavy_minus_sign:                                | A pointer to the page of results to return.       | ZXhhbXBsZTE                                       |
| `Limit`                                           | *long*                                            | :heavy_minus_sign:                                | The maximum number of items that are at returned. | 20                                                |

### Response

**[ListPaymentServiceDefinitionsResponse](../../Models/Requests/ListPaymentServiceDefinitionsResponse.md)**

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

## Get

Get the definition of a payment service that can be configured.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PaymentServiceDefinitions.GetAsync(paymentServiceDefinitionId: "adyen-ideal");

// handle response
```

### Parameters

| Parameter                    | Type                         | Required                     | Description                  | Example                      |
| ---------------------------- | ---------------------------- | ---------------------------- | ---------------------------- | ---------------------------- |
| `PaymentServiceDefinitionId` | *string*                     | :heavy_check_mark:           | N/A                          | adyen-ideal                  |

### Response

**[PaymentServiceDefinition](../../Models/Components/PaymentServiceDefinition.md)**

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

## Session

Creates a session for a payment service that supports sessions.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.PaymentServiceDefinitions.SessionAsync(
    paymentServiceDefinitionId: "adyen-ideal",
    requestBody: new Dictionary<string, object>() {

    }
);

// handle response
```

### Parameters

| Parameter                    | Type                         | Required                     | Description                  | Example                      |
| ---------------------------- | ---------------------------- | ---------------------------- | ---------------------------- | ---------------------------- |
| `PaymentServiceDefinitionId` | *string*                     | :heavy_check_mark:           | N/A                          | adyen-ideal                  |
| `RequestBody`                | Dictionary<String, *object*> | :heavy_check_mark:           | N/A                          |                              |

### Response

**[CreateSession](../../Models/Components/CreateSession.md)**

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