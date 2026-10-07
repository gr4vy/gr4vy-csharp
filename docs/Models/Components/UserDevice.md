# UserDevice

The platform that is being used to access the website.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = UserDevice.Desktop;

// Open enum: use .Of() to create instances from custom string values
var custom = UserDevice.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Desktop` | desktop   |
| `Mobile`  | mobile    |