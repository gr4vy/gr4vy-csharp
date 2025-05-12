# CardSchemeDefinitions
(*CardSchemeDefinitions*)

## Overview

### Available Operations

* [List](#list) - List card scheme definitions

## List

Fetch a list of the definitions of each card scheme.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.CardSchemeDefinitions.ListAsync(merchantAccountId: "default");

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[CollectionNoCursorCardSchemeDefinition](../../Models/Components/CollectionNoCursorCardSchemeDefinition.md)**

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