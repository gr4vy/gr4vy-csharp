# UpdateTransactionRequest


## Fields

| Field                                                             | Type                                                              | Required                                                          | Description                                                       | Example                                                           |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `TransactionId`                                                   | *string*                                                          | :heavy_check_mark:                                                | The ID of the transaction                                         | 7099948d-7286-47e4-aad8-b68f7eb44591                              |
| `MerchantAccountId`                                               | *string*                                                          | :heavy_minus_sign:                                                | The ID of the merchant account to use for this request.           | default                                                           |
| `TransactionUpdate`                                               | [TransactionUpdate](../../Models/Components/TransactionUpdate.md) | :heavy_check_mark:                                                | N/A                                                               |                                                                   |