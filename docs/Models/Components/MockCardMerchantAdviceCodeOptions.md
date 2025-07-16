# MockCardMerchantAdviceCodeOptions


## Fields

| Field                                                                              | Type                                                                               | Required                                                                           | Description                                                                        |
| ---------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| `Result`                                                                           | *string*                                                                           | :heavy_minus_sign:                                                                 | The MAC to return for this request.                                                |
| `AccountNumber`                                                                    | *string*                                                                           | :heavy_check_mark:                                                                 | When set, the MAC is only returned if the card number matches this account number. |