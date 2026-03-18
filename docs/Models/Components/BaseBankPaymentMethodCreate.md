# BaseBankPaymentMethodCreate

Base class for Bank Payment Methods.


## Fields

| Field                                                             | Type                                                              | Required                                                          | Description                                                       | Example                                                           |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `Method`                                                          | *string*                                                          | :heavy_minus_sign:                                                | Always `bank`.                                                    | bank                                                              |
| `AccountHolder`                                                   | [BankAccountHolder](../../Models/Components/BankAccountHolder.md) | :heavy_check_mark:                                                | N/A                                                               |                                                                   |
| `BuyerId`                                                         | *string*                                                          | :heavy_minus_sign:                                                | The ID of the buyer to attach the method to.                      | fe26475d-ec3e-4884-9553-f7356683f7f9                              |
| `BuyerExternalIdentifier`                                         | *string*                                                          | :heavy_minus_sign:                                                | The merchant reference for this payment method.                   | payment-method-12345                                              |
| `ExternalIdentifier`                                              | *string*                                                          | :heavy_minus_sign:                                                | The merchant identifier for this payment method.                  | payment-method-12345                                              |