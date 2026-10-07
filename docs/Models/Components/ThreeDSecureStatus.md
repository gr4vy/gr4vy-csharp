# ThreeDSecureStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = ThreeDSecureStatus.SetupError;

// Open enum: use .Of() to create instances from custom string values
var custom = ThreeDSecureStatus.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `SetupError` | setup_error  |
| `Error`      | error        |
| `Declined`   | declined     |
| `Cancelled`  | cancelled    |
| `Complete`   | complete     |