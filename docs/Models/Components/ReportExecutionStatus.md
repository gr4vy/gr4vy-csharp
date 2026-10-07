# ReportExecutionStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = ReportExecutionStatus.Dispatched;

// Open enum: use .Of() to create instances from custom string values
var custom = ReportExecutionStatus.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Dispatched` | dispatched   |
| `Failed`     | failed       |
| `Pending`    | pending      |
| `Processing` | processing   |
| `Succeeded`  | succeeded    |