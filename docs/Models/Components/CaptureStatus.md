# CaptureStatus

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = CaptureStatus.Succeeded;

// Open enum: use .Of() to create instances from custom string values
var custom = CaptureStatus.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Succeeded` | succeeded   |
| `Pending`   | pending     |
| `Declined`  | declined    |
| `Failed`    | failed      |
| `Canceled`  | canceled    |