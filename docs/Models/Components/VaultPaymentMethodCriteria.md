# VaultPaymentMethodCriteria

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = VaultPaymentMethodCriteria.Always;

// Open enum: use .Of() to create instances from custom string values
var custom = VaultPaymentMethodCriteria.Of("custom_value");
```


## Values

| Name                      | Value                     |
| ------------------------- | ------------------------- |
| `Always`                  | ALWAYS                    |
| `OnSuccessfulTransaction` | ON_SUCCESSFUL_TRANSACTION |