# IncrementalAuthorizationStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = IncrementalAuthorizationStatus.Succeeded;

// Open enum: use .Of() to create instances from custom string values
var custom = IncrementalAuthorizationStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Succeeded` | succeeded   |
| `Failed`    | failed      |
| `Pending`   | pending     |