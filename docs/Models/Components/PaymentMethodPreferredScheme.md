# PaymentMethodPreferredScheme

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = PaymentMethodPreferredScheme.Bancontact;

// Open enum: use .Of() to create instances from custom string values
var custom = PaymentMethodPreferredScheme.Of("custom_value");
```


## Values

| Name              | Value             |
| ----------------- | ----------------- |
| `Bancontact`      | bancontact        |
| `CarteBancaire`   | carte-bancaire    |
| `Dankort`         | dankort           |
| `Mastercard`      | mastercard        |
| `Visa`            | visa              |
| `EftposAustralia` | eftpos-australia  |