# PaymentServices
(*PaymentServices*)

## Overview

### Available Operations

* [List](#list) - List payment services
* [Create](#create) - Update a configured payment service
* [Get](#get) - Get payment service
* [Update](#update) - Configure a payment service
* [Delete](#delete) - Delete a configured payment service
* [Verify](#verify) - Verify payment service credentials
* [Session](#session) - Create a session for apayment service definition

## List

List the configured payment services.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

ListPaymentServicesRequest req = new ListPaymentServicesRequest() {
    Method = "card",
    Cursor = "ZXhhbXBsZTE",
    Deleted = true,
};

ListPaymentServicesResponse? res = await sdk.PaymentServices.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `request`                                                                         | [ListPaymentServicesRequest](../../Models/Requests/ListPaymentServicesRequest.md) | :heavy_check_mark:                                                                | The request object to use for the request.                                        |

### Response

**[ListPaymentServicesResponse](../../Models/Requests/ListPaymentServicesResponse.md)**

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

## Create

Updates the configuration of a payment service.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.PaymentServices.CreateAsync(
    paymentServiceCreate: new PaymentServiceCreate() {
        DisplayName = "Stripe",
        PaymentServiceDefinitionId = "stripe-card",
        Fields = new List<Field>() {
            new Field() {
                Key = "api_key",
                Value = "key-12345",
            },
        },
        ReportingFields = new List<Field>() {
            new Field() {
                Key = "api_key",
                Value = "key-12345",
            },
        },
        Position = 1,
        AcceptedCurrencies = new List<string>() {
            "USD",
            "EUR",
            "GBP",
        },
        AcceptedCountries = new List<string>() {
            "US",
            "DE",
            "GB",
        },
        Active = false,
        MerchantProfile = new Dictionary<string, MerchantProfileScheme>() {
            { "key", new MerchantProfileScheme() {
                MerchantAcquirerBin = "516327",
                MerchantUrl = "https://example.com",
                MerchantAcquirerId = "123456789012345",
                MerchantName = "Acme Inc.",
                MerchantCountryCode = "USD",
                MerchantCategoryCode = "1234",
            } },
        },
        PaymentMethodTokenizationEnabled = true,
        NetworkTokensEnabled = true,
        OpenLoop = true,
    },
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             | Example                                                                 |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `PaymentServiceCreate`                                                  | [PaymentServiceCreate](../../Models/Components/PaymentServiceCreate.md) | :heavy_check_mark:                                                      | N/A                                                                     |                                                                         |
| `MerchantAccountId`                                                     | *string*                                                                | :heavy_minus_sign:                                                      | The ID of the merchant account to use for this request.                 | default                                                                 |

### Response

**[PaymentService](../../Models/Components/PaymentService.md)**

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

Get the details of a configured payment service.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.PaymentServices.GetAsync(
    paymentServiceId: "fffd152a-9532-4087-9a4f-de58754210f0",
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `PaymentServiceId`                                      | *string*                                                | :heavy_check_mark:                                      | the ID of the payment service                           | fffd152a-9532-4087-9a4f-de58754210f0                    |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[PaymentService](../../Models/Components/PaymentService.md)**

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

## Update

Configures a new payment service for use by merchants.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.PaymentServices.UpdateAsync(
    paymentServiceId: "fffd152a-9532-4087-9a4f-de58754210f0",
    paymentServiceUpdate: new PaymentServiceUpdate() {
        DisplayName = "Stripe",
        Position = 1,
        AcceptedCurrencies = new List<string>() {
            "USD",
            "EUR",
            "GBP",
        },
        AcceptedCountries = new List<string>() {
            "US",
            "DE",
            "GB",
        },
        Active = false,
        ThreeDSecureEnabled = true,
        MerchantProfile = new Dictionary<string, MerchantProfileScheme>() {
            { "key", new MerchantProfileScheme() {
                MerchantAcquirerBin = "516327",
                MerchantUrl = "https://example.com",
                MerchantAcquirerId = "123456789012345",
                MerchantName = "Acme Inc.",
                MerchantCountryCode = "USD",
                MerchantCategoryCode = "1234",
            } },
        },
        PaymentMethodTokenizationEnabled = true,
        NetworkTokensEnabled = true,
        OpenLoop = true,
    },
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                                               | Type                                                                    | Required                                                                | Description                                                             | Example                                                                 |
| ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| `PaymentServiceId`                                                      | *string*                                                                | :heavy_check_mark:                                                      | the ID of the payment service                                           | fffd152a-9532-4087-9a4f-de58754210f0                                    |
| `PaymentServiceUpdate`                                                  | [PaymentServiceUpdate](../../Models/Components/PaymentServiceUpdate.md) | :heavy_check_mark:                                                      | N/A                                                                     |                                                                         |
| `MerchantAccountId`                                                     | *string*                                                                | :heavy_minus_sign:                                                      | The ID of the merchant account to use for this request.                 | default                                                                 |

### Response

**[PaymentService](../../Models/Components/PaymentService.md)**

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

Deletes all the configuration of a payment service.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.PaymentServices.DeleteAsync(
    paymentServiceId: "fffd152a-9532-4087-9a4f-de58754210f0",
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `PaymentServiceId`                                      | *string*                                                | :heavy_check_mark:                                      | the ID of the payment service                           | fffd152a-9532-4087-9a4f-de58754210f0                    |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

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

## Verify

Verify the credentials of a configured payment service

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.PaymentServices.VerifyAsync(
    verifyCredentials: new VerifyCredentials() {
        PaymentServiceDefinitionId = "stripe-card",
        PaymentServiceId = "fffd152a-9532-4087-9a4f-de58754210f0",
        Fields = new List<Field>() {
            new Field() {
                Key = "api_key",
                Value = "key-12345",
            },
        },
    },
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                                         | Type                                                              | Required                                                          | Description                                                       | Example                                                           |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `VerifyCredentials`                                               | [VerifyCredentials](../../Models/Components/VerifyCredentials.md) | :heavy_check_mark:                                                | N/A                                                               |                                                                   |
| `TimeoutInSeconds`                                                | *double*                                                          | :heavy_minus_sign:                                                | N/A                                                               |                                                                   |
| `MerchantAccountId`                                               | *string*                                                          | :heavy_minus_sign:                                                | The ID of the merchant account to use for this request.           | default                                                           |

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

## Session

Creates a session for a payment service that supports sessions.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.PaymentServices.SessionAsync(
    paymentServiceId: "fffd152a-9532-4087-9a4f-de58754210f0",
    requestBody: new Dictionary<string, object>() {
        { "key", "<value>" },
    },
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `PaymentServiceId`                                      | *string*                                                | :heavy_check_mark:                                      | the ID of the payment service                           | fffd152a-9532-4087-9a4f-de58754210f0                    |
| `RequestBody`                                           | Dictionary<String, *object*>                            | :heavy_check_mark:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

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