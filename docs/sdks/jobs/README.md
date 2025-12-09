# AccountUpdater.Jobs

## Overview

### Available Operations

* [Create](#create) - Create account updater job

## Create

Schedule one or more stored cards for an account update.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create_account_updater_job" method="post" path="/account-updater/jobs" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.AccountUpdater.Jobs.CreateAsync(accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
    PaymentMethodIds = new List<string>() {
        "ef9496d8-53a5-4aad-8ca2-00eb68334389",
        "f29e886e-93cc-4714-b4a3-12b7a718e595",
    },
});

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   | Example                                                                       |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `AccountUpdaterJobCreate`                                                     | [AccountUpdaterJobCreate](../../Models/Components/AccountUpdaterJobCreate.md) | :heavy_check_mark:                                                            | N/A                                                                           |                                                                               |
| `MerchantAccountId`                                                           | *string*                                                                      | :heavy_minus_sign:                                                            | The ID of the merchant account to use for this request.                       | default                                                                       |

### Response

**[AccountUpdaterJob](../../Models/Components/AccountUpdaterJob.md)**

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