# CallbackEvent

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = CallbackEvent.ShippingAddress;

// Open enum: use .Of() to create instances from custom string values
var custom = CallbackEvent.Of("custom_value");
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `ShippingAddress` | SHIPPING_ADDRESS  |
| `ShippingOptions` | SHIPPING_OPTIONS  |