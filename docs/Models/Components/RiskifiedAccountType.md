# RiskifiedAccountType

The customer account types recommended by Riskified.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = RiskifiedAccountType.Guest;

// Open enum: use .Of() to create instances from custom string values
var custom = RiskifiedAccountType.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Guest`      | guest        |
| `Registered` | registered   |
| `Premium`    | premium      |
| `Business`   | business     |