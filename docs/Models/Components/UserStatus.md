# UserStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = UserStatus.Active;

// Open enum: use .Of() to create instances from custom string values
var custom = UserStatus.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Active`  | active    |
| `Pending` | pending   |
| `Deleted` | deleted   |