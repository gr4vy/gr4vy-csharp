# SuspendPaymentMethodNetworkTokenRequest


## Fields

| Field                                                   | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `PaymentMethodId`                                       | *string*                                                | :heavy_check_mark:                                      | The ID of the payment method                            | ef9496d8-53a5-4aad-8ca2-00eb68334389                    |
| `NetworkTokenId`                                        | *string*                                                | :heavy_check_mark:                                      | The ID of the network token                             | f8dd5cfc-7834-4847-95dc-f75a360e2298                    |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |