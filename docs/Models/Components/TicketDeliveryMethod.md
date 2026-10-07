# TicketDeliveryMethod

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = TicketDeliveryMethod.Electronic;

// Open enum: use .Of() to create instances from custom string values
var custom = TicketDeliveryMethod.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Electronic` | electronic   |
| `Other`      | other        |