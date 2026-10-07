# DefinitionFieldFormat

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = DefinitionFieldFormat.Text;

// Open enum: use .Of() to create instances from custom string values
var custom = DefinitionFieldFormat.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Text`      | text        |
| `Multiline` | multiline   |
| `File`      | file        |
| `Number`    | number      |
| `Timezone`  | timezone    |
| `Boolean`   | boolean     |