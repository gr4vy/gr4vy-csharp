# CancelStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = CancelStatus.Succeeded;

// Open enum: use .Of() to create instances from custom string values
var custom = CancelStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Succeeded` | succeeded   |
| `Pending`   | pending     |
| `Failed`    | failed      |