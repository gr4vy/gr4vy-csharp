# AVSResponseCode

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = AVSResponseCode.Match;

// Open enum: use .Of() to create instances from custom string values
var custom = AVSResponseCode.Of("custom_value");
```


## Values

| Name                   | Value                  |
| ---------------------- | ---------------------- |
| `Match`                | match                  |
| `NoMatch`              | no_match               |
| `PartialMatchAddress`  | partial_match_address  |
| `PartialMatchPostcode` | partial_match_postcode |
| `PartialMatchName`     | partial_match_name     |
| `Unavailable`          | unavailable            |