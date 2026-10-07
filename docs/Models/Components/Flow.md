# Flow

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = Flow.Checkout;

// Open enum: use .Of() to create instances from custom string values
var custom = Flow.Of("custom_value");
```


## Values

| Name                  | Value                 |
| --------------------- | --------------------- |
| `Checkout`            | checkout              |
| `CardTransaction`     | card-transaction      |
| `NonCardTransaction`  | non-card-transaction  |
| `RedirectTransaction` | redirect-transaction  |