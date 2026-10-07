# CVVResponseCode

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = CVVResponseCode.Match;

// Open enum: use .Of() to create instances from custom string values
var custom = CVVResponseCode.Of("custom_value");
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Match`       | match         |
| `NoMatch`     | no_match      |
| `Unavailable` | unavailable   |
| `NotProvided` | not_provided  |