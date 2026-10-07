# CreateSessionStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = CreateSessionStatus.Succeeded;

// Open enum: use .Of() to create instances from custom string values
var custom = CreateSessionStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Succeeded` | succeeded   |
| `Failed`    | failed      |