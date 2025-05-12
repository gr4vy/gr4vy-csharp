# PayoutPaymentService


## Fields

| Field                                                    | Type                                                     | Required                                                 | Description                                              | Example                                                  |
| -------------------------------------------------------- | -------------------------------------------------------- | -------------------------------------------------------- | -------------------------------------------------------- | -------------------------------------------------------- |
| `Type`                                                   | *string*                                                 | :heavy_minus_sign:                                       | Always `payment-service`.                                | payment-service                                          |
| `Id`                                                     | *string*                                                 | :heavy_minus_sign:                                       | The ID for the payout service.                           | b6c9eb12-2b62-4103-99b9-e3efc94e396d                     |
| `Method`                                                 | *string*                                                 | :heavy_minus_sign:                                       | Always `card`.                                           | card                                                     |
| `PaymentServiceDefinitionId`                             | *string*                                                 | :heavy_check_mark:                                       | The ID of the connection used for this payout.           | nuvei-card                                               |
| `DisplayName`                                            | *string*                                                 | :heavy_minus_sign:                                       | The display name of the connection used for this payout. | Nuvei                                                    |