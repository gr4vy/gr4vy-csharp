# ProductType

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = ProductType.Physical;

// Open enum: use .Of() to create instances from custom string values
var custom = ProductType.Of("custom_value");
```


## Values

| Name          | Value         |
| ------------- | ------------- |
| `Physical`    | physical      |
| `Discount`    | discount      |
| `ShippingFee` | shipping_fee  |
| `SalesTax`    | sales_tax     |
| `Digital`     | digital       |
| `GiftCard`    | gift_card     |
| `StoreCredit` | store_credit  |
| `Surcharge`   | surcharge     |