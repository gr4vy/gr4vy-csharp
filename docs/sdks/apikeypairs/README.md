# ApiKeyPairs

## Overview

### Available Operations

* [List](#list) - List all API key pairs
* [Create](#create) - Create an API key pair
* [Get](#get) - Get an API key pair
* [Update](#update) - Update an API key pair
* [Delete](#delete) - Delete an API key pair

## List

List all API key pairs.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list_api_key_pairs" method="get" path="/api-key-pairs" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListApiKeyPairsResponse? res = await sdk.ApiKeyPairs.ListAsync(limit: 20);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                      | Type                                           | Required                                       | Description                                    | Example                                        |
| ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- | ---------------------------------------------- |
| `Cursor`                                       | *string*                                       | :heavy_minus_sign:                             | A pointer to the page of results to return.    | ZXhhbXBsZTE                                    |
| `Limit`                                        | *long*                                         | :heavy_minus_sign:                             | The maximum number of items that are returned. | 20                                             |

### Response

**[ListApiKeyPairsResponse](../../Models/Requests/ListApiKeyPairsResponse.md)**

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

Create a new API key pair.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create_api_key_pair" method="post" path="/api-key-pairs" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

APIKeyPairCreate req = new APIKeyPairCreate() {
    DisplayName = "Production key",
    RoleIds = new List<string>() {
        "8f4b8c1a-1b2c-4d3e-9f5a-6b7c8d9e0f1a",
    },
};

var res = await sdk.ApiKeyPairs.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `request`                                                       | [APIKeyPairCreate](../../Models/Components/APIKeyPairCreate.md) | :heavy_check_mark:                                              | The request object to use for the request.                      |

### Response

**[APIKeyPair](../../Models/Components/APIKeyPair.md)**

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

Fetches an API key pair by its ID.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="get_api_key_pair" method="get" path="/api-key-pairs/{api_key_pair_id}" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ApiKeyPairs.GetAsync(apiKeyPairId: "fe26475d-ec3e-4884-9553-f7356683f7f9");

// handle response
```

### Parameters

| Parameter                            | Type                                 | Required                             | Description                          | Example                              |
| ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ |
| `ApiKeyPairId`                       | *string*                             | :heavy_check_mark:                   | The ID of the API key pair.          | fe26475d-ec3e-4884-9553-f7356683f7f9 |

### Response

**[APIKeyPair](../../Models/Components/APIKeyPair.md)**

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

Updates an API key pair.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="update_api_key_pair" method="put" path="/api-key-pairs/{api_key_pair_id}" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.ApiKeyPairs.UpdateAsync(
    apiKeyPairId: "fe26475d-ec3e-4884-9553-f7356683f7f9",
    apiKeyPairUpdate: new APIKeyPairUpdate() {}
);

// handle response
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     | Example                                                         |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `ApiKeyPairId`                                                  | *string*                                                        | :heavy_check_mark:                                              | The ID of the API key pair.                                     | fe26475d-ec3e-4884-9553-f7356683f7f9                            |
| `APIKeyPairUpdate`                                              | [APIKeyPairUpdate](../../Models/Components/APIKeyPairUpdate.md) | :heavy_check_mark:                                              | N/A                                                             |                                                                 |

### Response

**[APIKeyPair](../../Models/Components/APIKeyPair.md)**

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

Permanently removes an API key pair.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete_api_key_pair" method="delete" path="/api-key-pairs/{api_key_pair_id}" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

await sdk.ApiKeyPairs.DeleteAsync(apiKeyPairId: "fe26475d-ec3e-4884-9553-f7356683f7f9");

// handle response
```

### Parameters

| Parameter                            | Type                                 | Required                             | Description                          | Example                              |
| ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ |
| `ApiKeyPairId`                       | *string*                             | :heavy_check_mark:                   | The ID of the API key pair.          | fe26475d-ec3e-4884-9553-f7356683f7f9 |

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