# Payouts
(*Payouts*)

## Overview

### Available Operations

* [List](#list) - List payouts created.
* [Create](#create) - Create a payout.
* [Get](#get) - Get a payout.

## List

Returns a list of payouts made.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

ListPayoutsResponse? res = await sdk.Payouts.ListAsync(
    cursor: "ZXhhbXBsZTE",
    limit: 20,
    merchantAccountId: "default"
);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `Cursor`                                                | *string*                                                | :heavy_minus_sign:                                      | A pointer to the page of results to return.             | ZXhhbXBsZTE                                             |
| `Limit`                                                 | *long*                                                  | :heavy_minus_sign:                                      | The maximum number of items that are at returned.       | 20                                                      |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[ListPayoutsResponse](../../Models/Requests/ListPayoutsResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| Gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| Gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error404            | 404                                     | application/json                        |
| Gr4vy.Models.Errors.Error405            | 405                                     | application/json                        |
| Gr4vy.Models.Errors.Error409            | 409                                     | application/json                        |
| Gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| Gr4vy.Models.Errors.Error425            | 425                                     | application/json                        |
| Gr4vy.Models.Errors.Error429            | 429                                     | application/json                        |
| Gr4vy.Models.Errors.Error500            | 500                                     | application/json                        |
| Gr4vy.Models.Errors.Error502            | 502                                     | application/json                        |
| Gr4vy.Models.Errors.Error504            | 504                                     | application/json                        |
| Gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |

## Create

Creates a new payout.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Payouts.CreateAsync(
    payoutCreate: new PayoutCreate() {
        Amount = 1299,
        Currency = "USD",
        PaymentServiceId = "ed8bd87d-85ad-40cf-8e8f-007e21e55aad",
        PaymentMethod = PayoutCreatePaymentMethod.CreatePaymentMethodStoredCard(
            new PaymentMethodStoredCard() {
                Id = "852b951c-d7ea-4c98-b09e-4a1c9e97c077",
            }
        ),
        Category = PayoutCategory.OnlineGambling,
        ExternalIdentifier = "payout-12345",
        BuyerId = "fe26475d-ec3e-4884-9553-f7356683f7f9",
        Buyer = new GuestBuyerInput() {
            DisplayName = "John Doe",
            ExternalIdentifier = "buyer-12345",
            BillingDetails = new BillingDetailsInput() {
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "john@example.com",
                PhoneNumber = "+1234567890",
                Address = new Address() {
                    City = "San Jose",
                    Country = "US",
                    PostalCode = "94560",
                    State = "California",
                    StateCode = "US-CA",
                    HouseNumberOrName = "10",
                    Line1 = "Stafford Appartments",
                    Line2 = "29th Street",
                    Organization = "Gr4vy",
                },
                TaxId = new TaxId() {
                    Value = "12345678931",
                    Kind = TaxIdKind.NoVat,
                },
            },
            ShippingDetails = new ShippingDetailsCreate() {
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "john@example.com",
                PhoneNumber = "+1234567890",
                Address = new Address() {
                    City = "San Jose",
                    Country = "US",
                    PostalCode = "94560",
                    State = "California",
                    StateCode = "US-CA",
                    HouseNumberOrName = "10",
                    Line1 = "Stafford Appartments",
                    Line2 = "29th Street",
                    Organization = "Gr4vy",
                },
            },
        },
        BuyerExternalIdentifier = "buyer-12345",
        Merchant = new PayoutMerchant() {
            Name = "Acme Inc",
            IdentificationNumber = "12345",
            PhoneNumber = "+442071838750",
            Url = "https://example.com",
            StatementDescriptor = "Winnings",
            MerchantCategoryCode = "123456",
            Address = new Address() {
                City = "San Jose",
                Country = "US",
                PostalCode = "94560",
                State = "California",
                StateCode = "US-CA",
                HouseNumberOrName = "10",
                Line1 = "Stafford Appartments",
                Line2 = "29th Street",
                Organization = "Gr4vy",
            },
        },
        ConnectionOptions = new ConnectionOptions() {
            CheckoutCard = new CheckoutCardConnectionOptions() {
                ProcessingChannelId = "channel-1234",
                SourceId = "acct-1234",
            },
        },
    },
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `PayoutCreate`                                          | [PayoutCreate](../../Models/Components/PayoutCreate.md) | :heavy_check_mark:                                      | N/A                                                     |                                                         |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[PayoutSummary](../../Models/Components/PayoutSummary.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| Gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| Gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error404            | 404                                     | application/json                        |
| Gr4vy.Models.Errors.Error405            | 405                                     | application/json                        |
| Gr4vy.Models.Errors.Error409            | 409                                     | application/json                        |
| Gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| Gr4vy.Models.Errors.Error425            | 425                                     | application/json                        |
| Gr4vy.Models.Errors.Error429            | 429                                     | application/json                        |
| Gr4vy.Models.Errors.Error500            | 500                                     | application/json                        |
| Gr4vy.Models.Errors.Error502            | 502                                     | application/json                        |
| Gr4vy.Models.Errors.Error504            | 504                                     | application/json                        |
| Gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |

## Get

Retreives a payout.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Payouts.GetAsync(
    payoutId: "4344fef2-bc2f-49a6-924f-343e62f67224",
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `PayoutId`                                              | *string*                                                | :heavy_check_mark:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[PayoutSummary](../../Models/Components/PayoutSummary.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| Gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| Gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error404            | 404                                     | application/json                        |
| Gr4vy.Models.Errors.Error405            | 405                                     | application/json                        |
| Gr4vy.Models.Errors.Error409            | 409                                     | application/json                        |
| Gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| Gr4vy.Models.Errors.Error425            | 425                                     | application/json                        |
| Gr4vy.Models.Errors.Error429            | 429                                     | application/json                        |
| Gr4vy.Models.Errors.Error500            | 500                                     | application/json                        |
| Gr4vy.Models.Errors.Error502            | 502                                     | application/json                        |
| Gr4vy.Models.Errors.Error504            | 504                                     | application/json                        |
| Gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |