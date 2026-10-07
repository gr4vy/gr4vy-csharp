# IntegrationClient

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = IntegrationClient.Redirect;

// Open enum: use .Of() to create instances from custom string values
var custom = IntegrationClient.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Redirect` | redirect   |
| `Web`      | web        |
| `Android`  | android    |
| `Ios`      | ios        |