# TransactionPaymentSource

The way payment method information made it to this transaction.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = TransactionPaymentSource.Ecommerce;

// Open enum: use .Of() to create instances from custom string values
var custom = TransactionPaymentSource.Of("custom_value");
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Ecommerce`   | ecommerce     |
| `Moto`        | moto          |
| `Recurring`   | recurring     |
| `Installment` | installment   |
| `CardOnFile`  | card_on_file  |