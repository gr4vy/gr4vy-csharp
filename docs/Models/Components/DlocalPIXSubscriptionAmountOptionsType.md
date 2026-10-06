# DlocalPIXSubscriptionAmountOptionsType

Indicates the amount type unit for the subscription. Allowed values are: `FIXED`, `VARIABLE`.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = DlocalPIXSubscriptionAmountOptionsType.Fixed;

// Open enum: use .Of() to create instances from custom string values
var custom = DlocalPIXSubscriptionAmountOptionsType.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Fixed`    | FIXED      |
| `Variable` | VARIABLE   |