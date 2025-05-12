# TransactionGiftCard


## Fields

| Field                                                      | Type                                                       | Required                                                   | Description                                                | Example                                                    |
| ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- | ---------------------------------------------------------- |
| `Type`                                                     | *string*                                                   | :heavy_minus_sign:                                         | Always `gift-card`.                                        | gift-card                                                  |
| `Id`                                                       | *string*                                                   | :heavy_minus_sign:                                         | The ID for the gift card.                                  | 356d56e5-fe16-42ae-97ee-8d55d846ae2e                       |
| `Bin`                                                      | *string*                                                   | :heavy_check_mark:                                         | The first 6 digits of the full gift card number.           | 412345                                                     |
| `SubBin`                                                   | *string*                                                   | :heavy_check_mark:                                         | The 3 digits after the `bin` of the full gift card number. | 554                                                        |
| `Last4`                                                    | *string*                                                   | :heavy_check_mark:                                         | The last 4 digits for the gift card.                       | 1234                                                       |