# VoidStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = VoidStatus.Succeeded;

// Open enum: use .Of() to create instances from custom string values
var custom = VoidStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Succeeded` | succeeded   |
| `Pending`   | pending     |
| `Declined`  | declined    |
| `Failed`    | failed      |