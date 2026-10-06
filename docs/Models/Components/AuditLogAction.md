# AuditLogAction

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = AuditLogAction.Created;

// Open enum: use .Of() to create instances from custom string values
var custom = AuditLogAction.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Created`  | created    |
| `Updated`  | updated    |
| `Deleted`  | deleted    |
| `Voided`   | voided     |
| `Canceled` | canceled   |
| `Captured` | captured   |