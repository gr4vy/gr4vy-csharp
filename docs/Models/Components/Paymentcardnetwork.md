# Paymentcardnetwork

Card network.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = Paymentcardnetwork.Visa;

// Open enum: use .Of() to create instances from custom string values
var custom = Paymentcardnetwork.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Visa`       | VISA         |
| `Mastercard` | MASTERCARD   |
| `Discover`   | DISCOVER     |