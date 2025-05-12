# CheckoutSessions
(*CheckoutSessions*)

## Overview

### Available Operations

* [Create](#create) - Create checkout session
* [Update](#update) - Update checkout session
* [Get](#get) - Get checkout session
* [Delete](#delete) - Delete checkout session

## Create

Create a new checkout session.

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

var res = await sdk.CheckoutSessions.CreateAsync(
    timeoutInSeconds: 1D,
    merchantAccountId: "default",
    checkoutSessionCreate: new CheckoutSessionCreate() {
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
                ProductType = ProductType.Physical,
                SellerCountry = "US",
            },
        },
        Metadata = new Dictionary<string, string>() {
            { "cohort", "cohort-a" },
            { "order_id", "order-12345" },
        },
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
                    Kind = TaxIdKind.MyNric,
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
        Airline = new Airline() {
            BookingCode = "X36Q9C",
            IssuedAddress = "123 Broadway, New York",
            IssuedAt = System.DateTime.Parse("2013-07-16T19:23:00.000+00:00"),
            IssuingCarrierCode = "649",
            Legs = new List<AirlineLeg>() {
                new AirlineLeg() {
                    ArrivalAirport = "LAX",
                    ArrivalAt = System.DateTime.Parse("2013-07-16T19:23:00.000+00:00"),
                    ArrivalCity = "Los Angeles",
                    ArrivalCountry = "US",
                    CarrierCode = "649",
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
                    RouteType = RouteType.RoundTrip,
                    StopOver = false,
                    TaxAmount = 1200,
                },
            },
            PassengerNameRecord = "JOHN L",
            Passengers = new List<AirlinePassenger>() {
                new AirlinePassenger() {
                    AgeGroup = AgeGroup.Adult,
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
            TicketDeliveryMethod = TicketDeliveryMethod.Electronic,
            TicketNumber = "123-1234-151555",
            TravelAgencyCode = "12345",
            TravelAgencyInvoiceNumber = "EG15555155",
            TravelAgencyName = "ACME Agency",
            TravelAgencyPlanName = "B733",
        },
    }
);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               | Example                                                                   |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `TimeoutInSeconds`                                                        | *double*                                                                  | :heavy_minus_sign:                                                        | N/A                                                                       |                                                                           |
| `MerchantAccountId`                                                       | *string*                                                                  | :heavy_minus_sign:                                                        | The ID of the merchant account to use for this request.                   | default                                                                   |
| `CheckoutSessionCreate`                                                   | [CheckoutSessionCreate](../../Models/Components/CheckoutSessionCreate.md) | :heavy_minus_sign:                                                        | N/A                                                                       |                                                                           |

### Response

**[CheckoutSession](../../Models/Components/CheckoutSession.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| Gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| Gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error403Forbidden   | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error403Active      | 403                                     | application/json                        |
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

## Update

Update the information stored on a checkout session.

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

var res = await sdk.CheckoutSessions.UpdateAsync(
    sessionId: "4137b1cf-39ac-42a8-bad6-1c680d5dab6b",
    checkoutSessionCreate: new CheckoutSessionCreate() {
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
                ProductType = ProductType.Physical,
                SellerCountry = "GB",
            },
        },
        Metadata = new Dictionary<string, string>() {
            { "cohort", "cohort-a" },
            { "order_id", "order-12345" },
        },
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
                    Kind = TaxIdKind.MyFrp,
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
        Airline = new Airline() {
            BookingCode = "X36Q9C",
            IssuedAddress = "123 Broadway, New York",
            IssuedAt = System.DateTime.Parse("2013-07-16T19:23:00.000+00:00"),
            IssuingCarrierCode = "649",
            Legs = new List<AirlineLeg>() {
                new AirlineLeg() {
                    ArrivalAirport = "LAX",
                    ArrivalAt = System.DateTime.Parse("2013-07-16T19:23:00.000+00:00"),
                    ArrivalCity = "Los Angeles",
                    ArrivalCountry = "US",
                    CarrierCode = "649",
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
                    RouteType = RouteType.RoundTrip,
                    StopOver = false,
                    TaxAmount = 1200,
                },
            },
            PassengerNameRecord = "JOHN L",
            Passengers = new List<AirlinePassenger>() {
                new AirlinePassenger() {
                    AgeGroup = AgeGroup.Adult,
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
            TicketDeliveryMethod = TicketDeliveryMethod.Electronic,
            TicketNumber = "123-1234-151555",
            TravelAgencyCode = "12345",
            TravelAgencyInvoiceNumber = "EG15555155",
            TravelAgencyName = "ACME Agency",
            TravelAgencyPlanName = "B733",
        },
    },
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               | Example                                                                   |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `SessionId`                                                               | *string*                                                                  | :heavy_check_mark:                                                        | The ID of the checkout session.                                           | 4137b1cf-39ac-42a8-bad6-1c680d5dab6b                                      |
| `CheckoutSessionCreate`                                                   | [CheckoutSessionCreate](../../Models/Components/CheckoutSessionCreate.md) | :heavy_check_mark:                                                        | N/A                                                                       |                                                                           |
| `TimeoutInSeconds`                                                        | *double*                                                                  | :heavy_minus_sign:                                                        | N/A                                                                       |                                                                           |
| `MerchantAccountId`                                                       | *string*                                                                  | :heavy_minus_sign:                                                        | The ID of the merchant account to use for this request.                   | default                                                                   |

### Response

**[CheckoutSession](../../Models/Components/CheckoutSession.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| Gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| Gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error403Forbidden   | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error403Active      | 403                                     | application/json                        |
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

Retrieve the information stored on a checkout session.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.CheckoutSessions.GetAsync(
    sessionId: "4137b1cf-39ac-42a8-bad6-1c680d5dab6b",
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `SessionId`                                             | *string*                                                | :heavy_check_mark:                                      | The ID of the checkout session.                         | 4137b1cf-39ac-42a8-bad6-1c680d5dab6b                    |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[CheckoutSession](../../Models/Components/CheckoutSession.md)**

### Errors

| Error Type                            | Status Code                           | Content Type                          |
| ------------------------------------- | ------------------------------------- | ------------------------------------- |
| Gr4vy.Models.Errors.Error400          | 400                                   | application/json                      |
| Gr4vy.Models.Errors.Error401          | 401                                   | application/json                      |
| Gr4vy.Models.Errors.Error403          | 403                                   | application/json                      |
| Gr4vy.Models.Errors.Error403Forbidden | 403                                   | application/json                      |
| Gr4vy.Models.Errors.Error403Active    | 403                                   | application/json                      |
| Gr4vy.Models.Errors.Error404          | 404                                   | application/json                      |
| Gr4vy.Models.Errors.Error405          | 405                                   | application/json                      |
| Gr4vy.Models.Errors.Error409          | 409                                   | application/json                      |
| Gr4vy.Models.Errors.Error425          | 425                                   | application/json                      |
| Gr4vy.Models.Errors.Error429          | 429                                   | application/json                      |
| Gr4vy.Models.Errors.Error500          | 500                                   | application/json                      |
| Gr4vy.Models.Errors.Error502          | 502                                   | application/json                      |
| Gr4vy.Models.Errors.Error504          | 504                                   | application/json                      |
| Gr4vy.Models.Errors.APIException      | 4XX, 5XX                              | \*/\*                                 |

## Delete

Deleta a checkout session and all of its (PCI) data.

### Example Usage

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

await sdk.CheckoutSessions.DeleteAsync(
    sessionId: "4137b1cf-39ac-42a8-bad6-1c680d5dab6b",
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `SessionId`                                             | *string*                                                | :heavy_check_mark:                                      | The ID of the checkout session.                         | 4137b1cf-39ac-42a8-bad6-1c680d5dab6b                    |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| Gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| Gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error403Forbidden   | 403                                     | application/json                        |
| Gr4vy.Models.Errors.Error403Active      | 403                                     | application/json                        |
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