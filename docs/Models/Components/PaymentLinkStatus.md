# PaymentLinkStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = PaymentLinkStatus.Active;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentLinkStatus.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Active`     | active       |
| `Completed`  | completed    |
| `Expired`    | expired      |
| `Processing` | processing   |