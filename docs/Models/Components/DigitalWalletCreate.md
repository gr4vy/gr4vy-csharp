# DigitalWalletCreate

Request body for registering a new digital wallet


## Fields

| Field                      | Type                       | Required                   | Description                | Example                    |
| -------------------------- | -------------------------- | -------------------------- | -------------------------- | -------------------------- |
| `Provider`                 | *string*                   | :heavy_check_mark:         | N/A                        |                            |
| `MerchantName`             | *string*                   | :heavy_check_mark:         | N/A                        |                            |
| `MerchantDisplayName`      | *string*                   | :heavy_minus_sign:         | N/A                        |                            |
| `MerchantUrl`              | *string*                   | :heavy_minus_sign:         | N/A                        |                            |
| `MerchantCountryCode`      | *string*                   | :heavy_minus_sign:         | N/A                        | DE                         |
| `DomainNames`              | List<*string*>             | :heavy_minus_sign:         | N/A                        |                            |
| `AcceptTermsAndConditions` | *bool*                     | :heavy_check_mark:         | N/A                        |                            |