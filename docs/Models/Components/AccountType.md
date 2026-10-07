# AccountType

Specify whether this is a `checking` or `savings` account. Defaults to `checking`.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = AccountType.Checking;

// Open enum: use .Of() to create instances from custom string values
var custom = AccountType.Of("custom_value");
```


## Values

| Name       | Value      |
| ---------- | ---------- |
| `Checking` | checking   |
| `Savings`  | savings    |