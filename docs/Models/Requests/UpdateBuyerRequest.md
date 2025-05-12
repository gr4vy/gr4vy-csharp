# UpdateBuyerRequest


## Fields

| Field                                                   | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `BuyerId`                                               | *string*                                                | :heavy_check_mark:                                      | The ID of the buyer to edit.                            | fe26475d-ec3e-4884-9553-f7356683f7f9                    |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |
| `BuyerUpdate`                                           | [BuyerUpdate](../../Models/Components/BuyerUpdate.md)   | :heavy_check_mark:                                      | N/A                                                     |                                                         |