# Detokenization


## Fields

| Field                                                                      | Type                                                                       | Required                                                                   | Description                                                                | Example                                                                    |
| -------------------------------------------------------------------------- | -------------------------------------------------------------------------- | -------------------------------------------------------------------------- | -------------------------------------------------------------------------- | -------------------------------------------------------------------------- |
| `Type`                                                                     | *string*                                                                   | :heavy_minus_sign:                                                         | Always `payment-method-detokenization`.                                    | payment-method-detokenization                                              |
| `EncryptedPayload`                                                         | *string*                                                                   | :heavy_check_mark:                                                         | The card details, encrypted to the merchant's public key as a compact JWE. | eyJhbGciOiJSU0EtT0FFUC0yNTYiLCJlbmMiOi...                                  |