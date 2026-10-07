# PaymentMethodStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = PaymentMethodStatus.Processing;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentMethodStatus.Of("custom_value");
```


## Values

| Name                    | Value                   |
| ----------------------- | ----------------------- |
| `Processing`            | processing              |
| `BuyerApprovalRequired` | buyer_approval_required |
| `Succeeded`             | succeeded               |
| `Failed`                | failed                  |
| `Paused`                | paused                  |