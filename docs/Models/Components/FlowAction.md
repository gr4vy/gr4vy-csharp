# FlowAction

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = FlowAction.SelectPaymentOptions;

// Open enum: use .Of() to create instances from custom string values
var custom = FlowAction.Of("custom_value");
```


## Values

| Name                   | Value                  |
| ---------------------- | ---------------------- |
| `SelectPaymentOptions` | select-payment-options |
| `RouteTransaction`     | route-transaction      |
| `DeclineEarly`         | decline-early          |
| `Skip3ds`              | skip-3ds               |