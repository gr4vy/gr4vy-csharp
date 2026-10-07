# CardType

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = CardType.Credit;

// Open enum: use .Of() to create instances from custom string values
var custom = CardType.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Credit`  | credit    |
| `Debit`   | debit     |
| `Prepaid` | prepaid   |