# NetworkTokenStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = NetworkTokenStatus.Active;

// Open enum: use .Of() to create instances from custom string values
var custom = NetworkTokenStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Active`    | active      |
| `Inactive`  | inactive    |
| `Suspended` | suspended   |
| `Deleted`   | deleted     |