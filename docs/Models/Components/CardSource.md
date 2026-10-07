# CardSource

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = CardSource.ApplePay;

// Open enum: use .Of() to create instances from custom string values
var custom = CardSource.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `ApplePay`  | apple-pay   |
| `GooglePay` | google-pay  |