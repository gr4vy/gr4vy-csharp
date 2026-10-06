# PaypalShippingOptionsItemType

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = PaypalShippingOptionsItemType.Shipping;

// Open enum: use .Of() to create instances from custom string values
var custom = PaypalShippingOptionsItemType.Of("custom_value");
```


## Values

| Name               | Value              |
| ------------------ | ------------------ |
| `Shipping`         | SHIPPING           |
| `Pickup`           | PICKUP             |
| `PickupInStore`    | PICKUP_IN_STORE    |
| `PickupFromPerson` | PICKUP_FROM_PERSON |