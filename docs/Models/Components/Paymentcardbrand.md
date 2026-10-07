# Paymentcardbrand

Card brand.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = Paymentcardbrand.Visa;

// Open enum: use .Of() to create instances from custom string values
var custom = Paymentcardbrand.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Visa`       | VISA         |
| `Mastercard` | MASTERCARD   |
| `Discover`   | DISCOVER     |