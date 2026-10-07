# DeliveredTo

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = DeliveredTo.ShippingAddress;

// Open enum: use .Of() to create instances from custom string values
var custom = DeliveredTo.Of("custom_value");
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `ShippingAddress` | shipping_address  |
| `StorePickup`     | store_pickup      |