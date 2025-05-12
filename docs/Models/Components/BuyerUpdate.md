# BuyerUpdate

Request body for updating an existing buyer


## Fields

| Field                                                                 | Type                                                                  | Required                                                              | Description                                                           | Example                                                               |
| --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- | --------------------------------------------------------------------- |
| `DisplayName`                                                         | *string*                                                              | :heavy_minus_sign:                                                    | The display name for the buyer.                                       | John Doe                                                              |
| `ExternalIdentifier`                                                  | *string*                                                              | :heavy_minus_sign:                                                    | The merchant identifier for this buyer.                               | buyer-12345                                                           |
| `AccountNumber`                                                       | *string*                                                              | :heavy_minus_sign:                                                    | The buyer account number                                              |                                                                       |
| `BillingDetails`                                                      | [BillingDetailsInput](../../Models/Components/BillingDetailsInput.md) | :heavy_minus_sign:                                                    | The billing name, address, email, and other fields for this buyer.    |                                                                       |