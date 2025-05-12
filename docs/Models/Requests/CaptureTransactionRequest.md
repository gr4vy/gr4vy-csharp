# CaptureTransactionRequest


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `TransactionId`                                                     | *string*                                                            | :heavy_check_mark:                                                  | N/A                                                                 |
| `TimeoutInSeconds`                                                  | *double*                                                            | :heavy_minus_sign:                                                  | N/A                                                                 |
| `MerchantAccountId`                                                 | *string*                                                            | :heavy_minus_sign:                                                  | The ID of the merchant account to use for this request.             |
| `TransactionCapture`                                                | [TransactionCapture](../../Models/Components/TransactionCapture.md) | :heavy_check_mark:                                                  | N/A                                                                 |