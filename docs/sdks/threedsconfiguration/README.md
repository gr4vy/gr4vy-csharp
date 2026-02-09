# MerchantAccounts.ThreeDsConfiguration

## Overview

### Available Operations

* [Create](#create) - Create 3DS configuration for merchant
* [List](#list) - List 3DS configurations for merchant
* [Update](#update) - Edit 3DS configuration
* [Delete](#delete) - Delete 3DS configuration for a merchant

## Create

Create a new 3DS configuration for a merchant account.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create_three_ds_configuration" method="post" path="/merchant-accounts/{merchant_account_id}/three-ds-configurations" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.MerchantAccounts.ThreeDsConfiguration.CreateAsync(
    merchantAccountId: "merchant-12345",
    merchantAccountThreeDSConfigurationCreate: new MerchantAccountThreeDSConfigurationCreate() {
        MerchantAcquirerBin = "516327",
        MerchantAcquirerId = "123456789012345",
        MerchantName = "Acme Inc.",
        MerchantCountryCode = "840",
        MerchantCategoryCode = "1234",
        MerchantUrl = "https://example.com",
        Scheme = "<value>",
        Metadata = new Dictionary<string, string>() {
            { "key", "<value>" },
            { "key1", "<value>" },
            { "key2", "<value>" },
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       | Example                                                                                                           |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `MerchantAccountId`                                                                                               | *string*                                                                                                          | :heavy_check_mark:                                                                                                | The ID of the merchant account.                                                                                   | merchant-12345                                                                                                    |
| `MerchantAccountThreeDSConfigurationCreate`                                                                       | [MerchantAccountThreeDSConfigurationCreate](../../Models/Components/MerchantAccountThreeDSConfigurationCreate.md) | :heavy_check_mark:                                                                                                | N/A                                                                                                               |                                                                                                                   |

### Response

**[MerchantAccountThreeDSConfiguration](../../Models/Components/MerchantAccountThreeDSConfiguration.md)**

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

## List

List all 3DS configurations for a merchant account.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="list_three_ds_configurations" method="get" path="/merchant-accounts/{merchant_account_id}/three-ds-configurations" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.MerchantAccounts.ThreeDsConfiguration.ListAsync(merchantAccountId: "merchant-12345");

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `MerchantAccountId`                                                 | *string*                                                            | :heavy_check_mark:                                                  | The ID of the merchant account.                                     | merchant-12345                                                      |
| `Currency`                                                          | *string*                                                            | :heavy_minus_sign:                                                  | ISO 4217 currency code (3 characters) to filter 3DS configurations. | **Example 1:** USD<br/>**Example 2:** EUR<br/>**Example 3:** GBP    |

### Response

**[MerchantAccountThreeDSConfigurations](../../Models/Components/MerchantAccountThreeDSConfigurations.md)**

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

Update the 3DS configuration for a merchant account.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="edit_three_ds_configuration" method="put" path="/merchant-accounts/{merchant_account_id}/three-ds-configurations/{three_ds_configuration_id}" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.MerchantAccounts.ThreeDsConfiguration.UpdateAsync(
    merchantAccountId: "merchant-12345",
    threeDsConfigurationId: "1808f5e6-b49c-4db9-94fa-22371ea352f5",
    merchantAccountThreeDSConfigurationUpdate: new MerchantAccountThreeDSConfigurationUpdate() {}
);

// handle response
```

### Parameters

| Parameter                                                                                                         | Type                                                                                                              | Required                                                                                                          | Description                                                                                                       | Example                                                                                                           |
| ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------- |
| `MerchantAccountId`                                                                                               | *string*                                                                                                          | :heavy_check_mark:                                                                                                | The ID of the merchant account.                                                                                   | merchant-12345                                                                                                    |
| `ThreeDsConfigurationId`                                                                                          | *string*                                                                                                          | :heavy_check_mark:                                                                                                | The ID of the 3DS configuration for a merchant account.                                                           | 1808f5e6-b49c-4db9-94fa-22371ea352f5                                                                              |
| `MerchantAccountThreeDSConfigurationUpdate`                                                                       | [MerchantAccountThreeDSConfigurationUpdate](../../Models/Components/MerchantAccountThreeDSConfigurationUpdate.md) | :heavy_check_mark:                                                                                                | N/A                                                                                                               |                                                                                                                   |

### Response

**[MerchantAccountThreeDSConfiguration](../../Models/Components/MerchantAccountThreeDSConfiguration.md)**

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

Delete a 3DS configuration for a merchant account.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="delete_three_ds_configuration" method="delete" path="/merchant-accounts/{merchant_account_id}/three-ds-configurations/{three_ds_configuration_id}" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

await sdk.MerchantAccounts.ThreeDsConfiguration.DeleteAsync(
    merchantAccountId: "merchant-12345",
    threeDsConfigurationId: "1808f5e6-b49c-4db9-94fa-22371ea352f5"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `MerchantAccountId`                                     | *string*                                                | :heavy_check_mark:                                      | The ID of the merchant account.                         | merchant-12345                                          |
| `ThreeDsConfigurationId`                                | *string*                                                | :heavy_check_mark:                                      | The ID of the 3DS configuration for a merchant account. | 1808f5e6-b49c-4db9-94fa-22371ea352f5                    |

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