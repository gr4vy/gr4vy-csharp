# CheckoutSessionPaymentMethodDetails


## Fields

| Field                                           | Type                                            | Required                                        | Description                                     | Example                                         |
| ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- |
| `Bin`                                           | *string*                                        | :heavy_minus_sign:                              | The first 6 digit of the card.                  | 411111                                          |
| `CardCountry`                                   | *string*                                        | :heavy_minus_sign:                              | The country of the card issuer.                 | US                                              |
| `CardType`                                      | [CardType](../../Models/Components/CardType.md) | :heavy_minus_sign:                              | The payment scheme of the card.                 |                                                 |
| `CardIssuerName`                                | *string*                                        | :heavy_minus_sign:                              | The card issuer.                                | Bank of America NA                              |