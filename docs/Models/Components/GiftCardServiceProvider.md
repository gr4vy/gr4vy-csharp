# GiftCardServiceProvider

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = GiftCardServiceProvider.MockGiftCard;

// Open enum: use .Of() to create instances from custom string values
var custom = GiftCardServiceProvider.Of("custom_value");
```


## Values

| Name                 | Value                |
| -------------------- | -------------------- |
| `MockGiftCard`       | mock-gift-card       |
| `QwikcilverGiftCard` | qwikcilver-gift-card |
| `ValuelinkGiftCard`  | valuelink-gift-card  |