# GiftCardRedemptionStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = GiftCardRedemptionStatus.Created;

// Open enum: use .Of() to create instances from custom string values
var custom = GiftCardRedemptionStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Created`   | created     |
| `Succeeded` | succeeded   |
| `Failed`    | failed      |
| `Skipped`   | skipped     |