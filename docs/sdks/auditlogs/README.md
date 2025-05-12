# AuditLogs
(*AuditLogs*)

## Overview

### Available Operations

* [List](#list) - List audit log entries

## List

Returns a list of activity by dashboard users.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;
using gr4vy.Models.Requests;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

ListAuditLogsRequest req = new ListAuditLogsRequest() {
    Cursor = "ZXhhbXBsZTE",
    Action = AuditLogAction.Created,
    UserId = "14b7b8c5-a6ba-4fb6-bbab-52d43c7f37ef",
    ResourceType = "user",
};

ListAuditLogsResponse? res = await sdk.AuditLogs.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                             | Type                                                                  | Required                                                              | Description                                                           |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `request`                                                             | [ListAuditLogsRequest](../../Models/Requests/ListAuditLogsRequest.md) | :heavy_check_mark:                                                    | The request object to use for the request.                            |

### Response

**[ListAuditLogsResponse](../../Models/Requests/ListAuditLogsResponse.md)**

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