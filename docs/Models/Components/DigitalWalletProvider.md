# DigitalWalletProvider

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = DigitalWalletProvider.Apple;

// Open enum: use .Of() to create instances from custom string values
var custom = DigitalWalletProvider.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Apple`      | apple        |
| `Google`     | google       |
| `ClickToPay` | click-to-pay |
| `Paze`       | paze         |