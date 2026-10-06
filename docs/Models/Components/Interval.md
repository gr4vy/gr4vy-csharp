# Interval

The cadence unit for the subscription plan.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = Interval.Day;

// Open enum: use .Of() to create instances from custom string values
var custom = Interval.Of("custom_value");
```


## Values

| Name    | Value   |
| ------- | ------- |
| `Day`   | DAY     |
| `Week`  | WEEK    |
| `Month` | MONTH   |
| `Year`  | YEAR    |