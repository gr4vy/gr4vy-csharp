# RefundStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = RefundStatus.Processing;

// Open enum: use .Of() to create instances from custom string values
var custom = RefundStatus.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Processing` | processing   |
| `Succeeded`  | succeeded    |
| `Failed`     | failed       |
| `Declined`   | declined     |
| `Voided`     | voided       |