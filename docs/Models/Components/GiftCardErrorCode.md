# GiftCardErrorCode

Gift card error codes.

Gr4vy normalised gift card error codes. Keep the naming and style in line with
those in the connectors framework.

If new codes are added, append them at the end or amend public simulator
documentation: https://docs.gr4vy.com/guides/features/gift-cards/simulator

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = GiftCardErrorCode.InvalidGiftCard;

// Open enum: use .Of() to create instances from custom string values
var custom = GiftCardErrorCode.Of("custom_value");
```


## Values

| Name                          | Value                         |
| ----------------------------- | ----------------------------- |
| `InvalidGiftCard`             | invalid_gift_card             |
| `ExpiredCard`                 | expired_card                  |
| `InactiveCard`                | inactive_card                 |
| `InvalidServiceCredentials`   | invalid_service_credentials   |
| `InvalidAmount`               | invalid_amount                |
| `IncorrectCurrency`           | incorrect_currency            |
| `InsufficientFunds`           | insufficient_funds            |
| `InvalidServiceConfiguration` | invalid_service_configuration |
| `OperationCanceled`           | operation_canceled            |
| `ServiceError`                | service_error                 |
| `ServiceNetworkError`         | service_network_error         |
| `UnknownError`                | unknown_error                 |
| `MaxGiftCardsReached`         | max_gift_cards_reached        |
| `SuspectedFraud`              | suspected_fraud               |
| `CanceledPaymentMethod`       | canceled_payment_method       |
| `DuplicateTransaction`        | duplicate_transaction         |
| `UnexpectedState`             | unexpected_state              |