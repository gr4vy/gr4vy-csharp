# TransactionStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = TransactionStatus.Processing;

// Open enum: use .Of() to create instances from custom string values
var custom = TransactionStatus.Of("custom_value");
```


## Values

| Name                       | Value                      |
| -------------------------- | -------------------------- |
| `Processing`               | processing                 |
| `AuthorizationSucceeded`   | authorization_succeeded    |
| `AuthorizationDeclined`    | authorization_declined     |
| `AuthorizationFailed`      | authorization_failed       |
| `AuthorizationVoided`      | authorization_voided       |
| `AuthorizationVoidPending` | authorization_void_pending |
| `CaptureSucceeded`         | capture_succeeded          |
| `CapturePending`           | capture_pending            |
| `BuyerApprovalPending`     | buyer_approval_pending     |