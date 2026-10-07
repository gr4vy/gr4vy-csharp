# RouteType

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = RouteType.RoundTrip;

// Open enum: use .Of() to create instances from custom string values
var custom = RouteType.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `RoundTrip` | round_trip  |
| `OneWay`    | one_way     |