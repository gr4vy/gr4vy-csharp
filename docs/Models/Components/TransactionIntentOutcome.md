# TransactionIntentOutcome

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = TransactionIntentOutcome.Pending;

// Open enum: use .Of() to create instances from custom string values
var custom = TransactionIntentOutcome.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Pending`   | pending     |
| `Succeeded` | succeeded   |
| `Failed`    | failed      |