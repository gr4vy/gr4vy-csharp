# ErrorLocation

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = ErrorLocation.Query;

// Open enum: use .Of() to create instances from custom string values
var custom = ErrorLocation.Of("custom_value");
```


## Values

| Name      | Value     |
| --------- | --------- |
| `Query`   | query     |
| `Body`    | body      |
| `Path`    | path      |
| `Header`  | header    |
| `Unknown` | unknown   |