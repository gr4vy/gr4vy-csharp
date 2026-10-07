# Frequency

Indicates the frequency unit for the subscription. Allowed values are: `WEEKLY`, `MONTHLY`, `QUARTERLY`, `SEMI_ANNUAL`, `ANNUAL`.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = Frequency.Weekly;

// Open enum: use .Of() to create instances from custom string values
var custom = Frequency.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Weekly`     | WEEKLY       |
| `Monthly`    | MONTHLY      |
| `Quarterly`  | QUARTERLY    |
| `SemiAnnual` | SEMI_ANNUAL  |
| `Annual`     | ANNUAL       |