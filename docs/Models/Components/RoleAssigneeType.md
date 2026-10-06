# RoleAssigneeType

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = RoleAssigneeType.User;

// Open enum: use .Of() to create instances from custom string values
var custom = RoleAssigneeType.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `User`       | user         |
| `ApiKeyPair` | api-key-pair |