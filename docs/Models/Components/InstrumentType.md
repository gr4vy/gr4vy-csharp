# InstrumentType

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = InstrumentType.Pan;

// Open enum: use .Of() to create instances from custom string values
var custom = InstrumentType.Of("custom_value");
```


## Values

| Name            | Value           |
| --------------- | --------------- |
| `Pan`           | pan             |
| `CardToken`     | card_token      |
| `Redirect`      | redirect        |
| `RedirectToken` | redirect_token  |
| `Googlepay`     | googlepay       |
| `Applepay`      | applepay        |
| `NetworkToken`  | network_token   |
| `Plaid`         | plaid           |
| `Bank`          | bank            |