# SubscriptionFrequencyUnit

Indicates the frequency unit for the subscription. Allowed values are: `DAY`, `WEEK`, `MONTH`, `BI_MONTHLY`, `QUARTER`, `SEMI_ANNUALLY`, `YEAR`, `ONDEMAND`.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = SubscriptionFrequencyUnit.Month;

// Open enum: use .Of() to create instances from custom string values
var custom = SubscriptionFrequencyUnit.Of("custom_value");
```


## Values

| Name           | Value          |
| -------------- | -------------- |
| `Month`        | MONTH          |
| `Week`         | WEEK           |
| `BiMonthly`    | BI_MONTHLY     |
| `Ondemand`     | ONDEMAND       |
| `Quarter`      | QUARTER        |
| `Year`         | YEAR           |
| `SemiAnnually` | SEMI_ANNUALLY  |
| `Day`          | DAY            |