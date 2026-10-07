# RefundTargetType

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = RefundTargetType.PaymentMethod;

// Open enum: use .Of() to create instances from custom string values
var custom = RefundTargetType.Of("custom_value");
```


## Values

| Name                 | Value                |
| -------------------- | -------------------- |
| `PaymentMethod`      | payment-method       |
| `GiftCardRedemption` | gift-card-redemption |