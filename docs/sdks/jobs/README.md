# Jobs
(*AccountUpdater.Jobs*)

## Overview

### Available Operations

* [Create](#create) - Create account updater job

## Create

Schedule one or more stored cards for an account update.

### Example Usage

```csharp
using System.Collections.Generic;
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.AccountUpdater.Jobs.CreateAsync(
    accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
        PaymentMethodIds = new List<string>() {
            "ef9496d8-53a5-4aad-8ca2-00eb68334389",
            "f29e886e-93cc-4714-b4a3-12b7a718e595",
        },
    },
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   | Example                                                                       |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `AccountUpdaterJobCreate`                                                     | [AccountUpdaterJobCreate](../../Models/Components/AccountUpdaterJobCreate.md) | :heavy_check_mark:                                                            | N/A                                                                           |                                                                               |
| `TimeoutInSeconds`                                                            | *double*                                                                      | :heavy_minus_sign:                                                            | N/A                                                                           |                                                                               |
| `MerchantAccountId`                                                           | *string*                                                                      | :heavy_minus_sign:                                                            | The ID of the merchant account to use for this request.                       | default                                                                       |

### Response

**[CreateAccountUpdaterJobResponse](../../Models/Requests/CreateAccountUpdaterJobResponse.md)**

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