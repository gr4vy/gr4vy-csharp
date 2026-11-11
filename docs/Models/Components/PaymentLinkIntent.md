# PaymentLinkIntent

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = PaymentLinkIntent.Authorize;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentLinkIntent.Of("custom_value");
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `Authorize`       | authorize         |
| `Capture`         | capture           |
| `PreferAuthorize` | prefer_authorize  |