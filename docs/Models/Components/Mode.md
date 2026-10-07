# Mode

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = Mode.Card;

// Open enum: use .Of() to create instances from custom string values
var custom = Mode.Of("custom_value");
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `Card`            | card              |
| `Redirect`        | redirect          |
| `Applepay`        | applepay          |
| `Googlepay`       | googlepay         |
| `CheckoutSession` | checkout-session  |
| `ClickToPay`      | click-to-pay      |
| `GiftCard`        | gift-card         |
| `Bank`            | bank              |
| `Paze`            | paze              |