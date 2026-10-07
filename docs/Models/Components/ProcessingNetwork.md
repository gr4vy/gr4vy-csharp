# ProcessingNetwork

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = ProcessingNetwork.Visa;

// Open enum: use .Of() to create instances from custom string values
var custom = ProcessingNetwork.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Visa`       | VISA         |
| `Mastercard` | MASTERCARD   |
| `Discover`   | DISCOVER     |