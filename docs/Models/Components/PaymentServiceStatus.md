# PaymentServiceStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = PaymentServiceStatus.Pending;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentServiceStatus.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Pending` | pending   |
| `Created` | created   |
| `Failed`  | failed    |