# ReportSchedule

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = ReportSchedule.Daily;

// Open enum: use .Of() to create instances from custom string values
var custom = ReportSchedule.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Daily`   | daily     |
| `Monthly` | monthly   |
| `Once`    | once      |
| `Weekly`  | weekly    |