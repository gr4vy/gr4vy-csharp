# AcceptedPaymentCardNetwork

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = AcceptedPaymentCardNetwork.Visa;

// Open enum: use .Of() to create instances from custom string values
var custom = AcceptedPaymentCardNetwork.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Visa`       | VISA         |
| `Mastercard` | MASTERCARD   |