# PayoutStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = PayoutStatus.Declined;

// Open enum: use .Of() to create instances from custom string values
var custom = PayoutStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Declined`  | declined    |
| `Failed`    | failed      |
| `Pending`   | pending     |
| `Succeeded` | succeeded   |