# Source

The platform that the Paze session is being created for. Defaults to `web`.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = Source.Web;

// Open enum: use .Of() to create instances from custom string values
var custom = Source.Of("custom_value");
```


## Values

| Name     | Value    |
| -------- | -------- |
| `Web`    | web      |
| `Mobile` | mobile   |