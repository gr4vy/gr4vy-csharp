# Intent

Primary intent of the checkout session.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = Intent.ReviewAndPay;

// Open enum: use .Of() to create instances from custom string values
var custom = Intent.Of("custom_value");
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `ReviewAndPay`    | REVIEW_AND_PAY    |
| `ExpressCheckout` | EXPRESS_CHECKOUT  |
| `AddCard`         | ADD_CARD          |