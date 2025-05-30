# Transactions
(*Transactions*)

## Overview

### Available Operations

* [List](#list) - List transactions
* [Create](#create) - Create transaction
* [Get](#get) - Get transaction
* [Capture](#capture) - Capture transaction
* [Void](#void) - Void transaction
* [Sync](#sync) - Sync transaction

## List

List all transactions for a specific merchant account sorted by most recently created.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;
using System;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

ListTransactionsRequest req = new ListTransactionsRequest() {
    Cursor = "ZXhhbXBsZTE",
    CreatedAtLte = System.DateTime.Parse("2022-01-01T12:00:00+08:00"),
    CreatedAtGte = System.DateTime.Parse("2022-01-01T12:00:00+08:00"),
    UpdatedAtLte = System.DateTime.Parse("2022-01-01T12:00:00+08:00"),
    UpdatedAtGte = System.DateTime.Parse("2022-01-01T12:00:00+08:00"),
    Search = "transaction-12345",
    BuyerExternalIdentifier = "buyer-12345",
    BuyerId = "fe26475d-ec3e-4884-9553-f7356683f7f9",
    BuyerEmailAddress = "john@example.com",
    BuyerSearch = "John",
    IpAddress = "8.214.133.47",
    Status = new List<string>() {
        "authorization_succeeded",
    },
    Id = "7099948d-7286-47e4-aad8-b68f7eb44591",
    PaymentServiceTransactionId = "tx-12345",
    ExternalIdentifier = "transaction-12345",
    Metadata = new List<string>() {
        "{\"first_key\":\"first_value\",\"second_key\":\"second_value\"}",
    },
    AmountEq = 1299,
    AmountLte = 1299,
    AmountGte = 1299,
    Currency = new List<string>() {
        "USD",
    },
    Country = new List<string>() {
        "US",
    },
    PaymentServiceId = new List<string>() {
        "fffd152a-9532-4087-9a4f-de58754210f0",
    },
    PaymentMethodId = "ef9496d8-53a5-4aad-8ca2-00eb68334389",
    PaymentMethodLabel = "1234",
    PaymentMethodScheme = "[\"visa\"]",
    PaymentMethodCountry = "[\"US\"]",
    PaymentMethodFingerprint = "a50b85c200ee0795d6fd33a5c66f37a4564f554355c5b46a756aac485dd168a4",
    Method = new List<string>() {
        "card",
    },
    ErrorCode = new List<string>() {
        "insufficient_funds",
    },
    HasRefunds = true,
    PendingReview = true,
    CheckoutSessionId = "4137b1cf-39ac-42a8-bad6-1c680d5dab6b",
    ReconciliationId = "7jZXl4gBUNl0CnaLEnfXbt",
    HasGiftCardRedemptions = true,
    GiftCardId = "356d56e5-fe16-42ae-97ee-8d55d846ae2e",
    GiftCardLast4 = "7890",
    HasSettlements = true,
    PaymentMethodBin = "411111",
    PaymentSource = new List<string>() {
        "recurring",
    },
    IsSubsequentPayment = true,
    MerchantInitiated = true,
    Used3ds = true,
};

ListTransactionsResponse? res = await sdk.Transactions.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `request`                                                                   | [ListTransactionsRequest](../../Models/Requests/ListTransactionsRequest.md) | :heavy_check_mark:                                                          | The request object to use for the request.                                  |

### Response

**[ListTransactionsResponse](../../Models/Requests/ListTransactionsResponse.md)**

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

Create a transaction.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using NodaTime;
using System;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Transactions.CreateAsync(
    transactionCreate: new TransactionCreate() {
        Amount = 1299,
        Currency = "EUR",
        Country = "US",
        PaymentMethod = TransactionCreatePaymentMethod.CreateCardWithUrlPaymentMethodCreate(
            new CardWithUrlPaymentMethodCreate() {
                ExpirationDate = "12/30",
                Number = "4111111111111111",
                BuyerExternalIdentifier = "buyer-12345",
                BuyerId = "fe26475d-ec3e-4884-9553-f7356683f7f9",
                ExternalIdentifier = "payment-method-12345",
                CardType = "credit",
                SecurityCode = "123",
            }
        ),
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
                    Kind = "<value>",
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
        BuyerId = "fe26475d-ec3e-4884-9553-f7356683f7f9",
        BuyerExternalIdentifier = "buyer-12345",
        GiftCards = new List<GiftCardUnion>() {
            GiftCardUnion.CreateGiftCardTransactionCreate(
                new GiftCardTransactionCreate() {
                    Number = "4123455541234561234",
                    Pin = "1234",
                    Amount = 1299,
                }
            ),
        },
        ExternalIdentifier = "transaction-12345",
        ThreeDSecureData = ThreeDSecureData.CreateThreeDSecureDataV2(
            new ThreeDSecureDataV2() {
                Cavv = "3q2+78r+ur7erb7vyv66vv8=",
                Eci = "05",
                Version = "2.1.0",
                DirectoryResponse = "C",
                Scheme = "visa",
                AuthenticationResponse = "Y",
                DirectoryTransactionId = "c4e59ceb-a382-4d6a-bc87-385d591fa09d",
            }
        ),
        Metadata = new Dictionary<string, string>() {
            { "cohort", "cohort-12345" },
            { "order", "order-12345" },
        },
        Airline = new Airline() {
            BookingCode = "X36Q9C",
            IsCardholderTraveling = true,
            IssuedAddress = "123 Broadway, New York",
            IssuedAt = System.DateTime.Parse("2013-07-16T19:23:00.000+00:00"),
            IssuingCarrierCode = "649",
            IssuingCarrierName = "Air Transat A.T. Inc",
            IssuingIataDesignator = "TS",
            IssuingIcaoCode = "TSC",
            Legs = new List<AirlineLeg>() {
                new AirlineLeg() {
                    ArrivalAirport = "LAX",
                    ArrivalAt = System.DateTime.Parse("2013-07-16T19:23:00.000+00:00"),
                    ArrivalCity = "Los Angeles",
                    ArrivalCountry = "US",
                    CarrierCode = "649",
                    CarrierName = "Air Transat A.T. Inc",
                    IataDesignator = "TS",
                    IcaoCode = "TSC",
                    CouponNumber = "15885566",
                    DepartureAirport = "LHR",
                    DepartureAt = System.DateTime.Parse("2013-07-16T19:23:00.000+00:00"),
                    DepartureCity = "London",
                    DepartureCountry = "GB",
                    DepartureTaxAmount = 1200,
                    FareAmount = 129900,
                    FareBasisCode = "FY",
                    FeeAmount = 1200,
                    FlightClass = "E",
                    FlightNumber = "101",
                    RouteType = "round_trip",
                    SeatClass = "F",
                    StopOver = false,
                    TaxAmount = 1200,
                },
            },
            PassengerNameRecord = "JOHN L",
            Passengers = new List<AirlinePassenger>() {
                new AirlinePassenger() {
                    AgeGroup = "adult",
                    DateOfBirth = LocalDate.FromDateTime(System.DateTime.Parse("2013-07-16")),
                    EmailAddress = "john@example.com",
                    FirstName = "John",
                    FrequentFlyerNumber = "15885566",
                    LastName = "Luhn",
                    PassportNumber = "11117700225",
                    PhoneNumber = "+1234567890",
                    TicketNumber = "BA1236699999",
                    Title = "Mr.",
                    CountryCode = "US",
                },
            },
            ReservationSystem = "Amadeus",
            RestrictedTicket = false,
            TicketDeliveryMethod = "electronic",
            TicketNumber = "123-1234-151555",
            TravelAgencyCode = "12345",
            TravelAgencyInvoiceNumber = "EG15555155",
            TravelAgencyName = "ACME Agency",
            TravelAgencyPlanName = "B733",
        },
        CartItems = new List<CartItem>() {
            new CartItem() {
                Name = "GoPro HD",
                Quantity = 2,
                UnitAmount = 1299,
                DiscountAmount = 0,
                TaxAmount = 0,
                ExternalIdentifier = "goprohd",
                Sku = "GPHD1078",
                ProductUrl = "https://example.com/catalog/go-pro-hd",
                ImageUrl = "https://example.com/images/go-pro-hd.jpg",
                Categories = new List<string>() {
                    "camera",
                    "travel",
                    "gear",
                },
                ProductType = "physical",
                SellerCountry = "GB",
            },
        },
        StatementDescriptor = new StatementDescriptor() {
            Name = "ACME",
            Description = "ACME San Jose Electronics",
            City = "San Jose",
            Country = "US",
            PhoneNumber = "+1234567890",
            Url = "www.example.com",
        },
        PreviousSchemeTransactionId = "123456789012345",
        BrowserInfo = new BrowserInfo() {
            JavascriptEnabled = false,
            JavaEnabled = false,
            Language = "<value>",
            ColorDepth = 836800,
            ScreenHeight = 233026,
            ScreenWidth = 285144,
            TimeZoneOffset = 702825,
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36",
            UserDevice = "desktop",
            AcceptHeader = "*/*",
        },
        ShippingDetailsId = "bf8c36ad-02d9-4904-b0f9-a230b149e341",
        AntiFraudFingerprint = "yGeBAFYgFmM=",
        PaymentServiceId = "fffd152a-9532-4087-9a4f-de58754210f0",
        Recipient = new Recipient() {
            FirstName = "",
            LastName = "",
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
            AccountNumber = "act12345",
            DateOfBirth = LocalDate.FromDateTime(System.DateTime.Parse("1995-12-23")),
        },
    },
    merchantAccountId: "default",
    idempotencyKey: "request-12345"
);

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                             | Type                                                                                                                                                                                                  | Required                                                                                                                                                                                              | Description                                                                                                                                                                                           | Example                                                                                                                                                                                               |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `TransactionCreate`                                                                                                                                                                                   | [TransactionCreate](../../Models/Components/TransactionCreate.md)                                                                                                                                     | :heavy_check_mark:                                                                                                                                                                                    | N/A                                                                                                                                                                                                   |                                                                                                                                                                                                       |
| `MerchantAccountId`                                                                                                                                                                                   | *string*                                                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                                                    | The ID of the merchant account to use for this request.                                                                                                                                               | default                                                                                                                                                                                               |
| `IdempotencyKey`                                                                                                                                                                                      | *string*                                                                                                                                                                                              | :heavy_minus_sign:                                                                                                                                                                                    | A unique key that identifies this request. Providing this header will make this an idempotent request. We recommend using V4 UUIDs, or another random string with enough entropy to avoid collisions. | request-12345                                                                                                                                                                                         |

### Response

**[Transaction](../../Models/Components/Transaction.md)**

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

Fetch a single transaction by its ID.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Transactions.GetAsync(
    transactionId: "7099948d-7286-47e4-aad8-b68f7eb44591",
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `TransactionId`                                         | *string*                                                | :heavy_check_mark:                                      | N/A                                                     | 7099948d-7286-47e4-aad8-b68f7eb44591                    |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[Transaction](../../Models/Components/Transaction.md)**

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

## Capture

Capture a previously authorized transaction.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using NodaTime;
using System;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Transactions.CaptureAsync(
    transactionId: "7099948d-7286-47e4-aad8-b68f7eb44591",
    transactionCapture: new TransactionCapture() {
        Amount = 1299,
        Airline = new Airline() {
            BookingCode = "X36Q9C",
            IsCardholderTraveling = true,
            IssuedAddress = "123 Broadway, New York",
            IssuedAt = System.DateTime.Parse("2013-07-16T19:23:00.000+00:00"),
            IssuingCarrierCode = "649",
            IssuingCarrierName = "Air Transat A.T. Inc",
            IssuingIataDesignator = "TS",
            IssuingIcaoCode = "TSC",
            Legs = new List<AirlineLeg>() {
                new AirlineLeg() {
                    ArrivalAirport = "LAX",
                    ArrivalAt = System.DateTime.Parse("2013-07-16T19:23:00.000+00:00"),
                    ArrivalCity = "Los Angeles",
                    ArrivalCountry = "US",
                    CarrierCode = "649",
                    CarrierName = "Air Transat A.T. Inc",
                    IataDesignator = "TS",
                    IcaoCode = "TSC",
                    CouponNumber = "15885566",
                    DepartureAirport = "LHR",
                    DepartureAt = System.DateTime.Parse("2013-07-16T19:23:00.000+00:00"),
                    DepartureCity = "London",
                    DepartureCountry = "GB",
                    DepartureTaxAmount = 1200,
                    FareAmount = 129900,
                    FareBasisCode = "FY",
                    FeeAmount = 1200,
                    FlightClass = "E",
                    FlightNumber = "101",
                    RouteType = "round_trip",
                    SeatClass = "F",
                    StopOver = false,
                    TaxAmount = 1200,
                },
            },
            PassengerNameRecord = "JOHN L",
            Passengers = new List<AirlinePassenger>() {
                new AirlinePassenger() {
                    AgeGroup = "adult",
                    DateOfBirth = LocalDate.FromDateTime(System.DateTime.Parse("2013-07-16")),
                    EmailAddress = "john@example.com",
                    FirstName = "John",
                    FrequentFlyerNumber = "15885566",
                    LastName = "Luhn",
                    PassportNumber = "11117700225",
                    PhoneNumber = "+1234567890",
                    TicketNumber = "BA1236699999",
                    Title = "Mr.",
                    CountryCode = "US",
                },
            },
            ReservationSystem = "Amadeus",
            RestrictedTicket = false,
            TicketDeliveryMethod = "electronic",
            TicketNumber = "123-1234-151555",
            TravelAgencyCode = "12345",
            TravelAgencyInvoiceNumber = "EG15555155",
            TravelAgencyName = "ACME Agency",
            TravelAgencyPlanName = "B733",
        },
    },
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `TransactionId`                                                     | *string*                                                            | :heavy_check_mark:                                                  | N/A                                                                 | 7099948d-7286-47e4-aad8-b68f7eb44591                                |
| `TransactionCapture`                                                | [TransactionCapture](../../Models/Components/TransactionCapture.md) | :heavy_check_mark:                                                  | N/A                                                                 |                                                                     |
| `MerchantAccountId`                                                 | *string*                                                            | :heavy_minus_sign:                                                  | The ID of the merchant account to use for this request.             | default                                                             |

### Response

**[Transaction](../../Models/Components/Transaction.md)**

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

## Void

Void a previously authorized transaction.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Transactions.VoidAsync(
    transactionId: "7099948d-7286-47e4-aad8-b68f7eb44591",
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `TransactionId`                                         | *string*                                                | :heavy_check_mark:                                      | N/A                                                     | 7099948d-7286-47e4-aad8-b68f7eb44591                    |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[Transaction](../../Models/Components/Transaction.md)**

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

## Sync

Fetch the latest status for a transaction.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Transactions.SyncAsync(
    transactionId: "2ee546e0-3b11-478e-afec-fdb362611e22",
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `TransactionId`                                         | *string*                                                | :heavy_check_mark:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[Transaction](../../Models/Components/Transaction.md)**

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