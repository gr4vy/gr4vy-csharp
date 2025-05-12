# Buyers
(*Buyers*)

## Overview

### Available Operations

* [List](#list) - List all buyers
* [Create](#create) - Add a buyer
* [Get](#get) - Get a buyer
* [Update](#update) - Update a buyer
* [Delete](#delete) - Delete a buyer

## List

List all buyers or search for a specific buyer.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;
using gr4vy.Models.Requests;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

ListBuyersRequest req = new ListBuyersRequest() {
    Cursor = "ZXhhbXBsZTE",
    Search = "John",
    ExternalIdentifier = "buyer-12345",
};

ListBuyersResponse? res = await sdk.Buyers.ListAsync(req);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

### Parameters

| Parameter                                                       | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `request`                                                       | [ListBuyersRequest](../../Models/Requests/ListBuyersRequest.md) | :heavy_check_mark:                                              | The request object to use for the request.                      |

### Response

**[ListBuyersResponse](../../Models/Requests/ListBuyersResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Forbidden   | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Active      | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error404            | 404                                     | application/json                        |
| gr4vy.Models.Errors.Error405            | 405                                     | application/json                        |
| gr4vy.Models.Errors.Error409            | 409                                     | application/json                        |
| gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| gr4vy.Models.Errors.Error425            | 425                                     | application/json                        |
| gr4vy.Models.Errors.Error429            | 429                                     | application/json                        |
| gr4vy.Models.Errors.Error500            | 500                                     | application/json                        |
| gr4vy.Models.Errors.Error502            | 502                                     | application/json                        |
| gr4vy.Models.Errors.Error504            | 504                                     | application/json                        |
| gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |

## Create

Create a new buyer record.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Buyers.CreateAsync(
    buyerCreate: new BuyerCreate() {
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
                Kind = TaxIdKind.JpCn,
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
| `BuyerCreate`                                           | [BuyerCreate](../../Models/Components/BuyerCreate.md)   | :heavy_check_mark:                                      | N/A                                                     |                                                         |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[AddBuyerResponse](../../Models/Requests/AddBuyerResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Forbidden   | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Active      | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error404            | 404                                     | application/json                        |
| gr4vy.Models.Errors.Error405            | 405                                     | application/json                        |
| gr4vy.Models.Errors.Error409            | 409                                     | application/json                        |
| gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| gr4vy.Models.Errors.Error425            | 425                                     | application/json                        |
| gr4vy.Models.Errors.Error429            | 429                                     | application/json                        |
| gr4vy.Models.Errors.Error500            | 500                                     | application/json                        |
| gr4vy.Models.Errors.Error502            | 502                                     | application/json                        |
| gr4vy.Models.Errors.Error504            | 504                                     | application/json                        |
| gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |

## Get

Fetches a buyer by its ID.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Buyers.GetAsync(
    buyerId: "fe26475d-ec3e-4884-9553-f7356683f7f9",
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `BuyerId`                                               | *string*                                                | :heavy_check_mark:                                      | The ID of the buyer to retrieve.                        | fe26475d-ec3e-4884-9553-f7356683f7f9                    |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[GetBuyerResponse](../../Models/Requests/GetBuyerResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Forbidden   | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Active      | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error404            | 404                                     | application/json                        |
| gr4vy.Models.Errors.Error405            | 405                                     | application/json                        |
| gr4vy.Models.Errors.Error409            | 409                                     | application/json                        |
| gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| gr4vy.Models.Errors.Error425            | 425                                     | application/json                        |
| gr4vy.Models.Errors.Error429            | 429                                     | application/json                        |
| gr4vy.Models.Errors.Error500            | 500                                     | application/json                        |
| gr4vy.Models.Errors.Error502            | 502                                     | application/json                        |
| gr4vy.Models.Errors.Error504            | 504                                     | application/json                        |
| gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |

## Update

Updates a buyer record.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Buyers.UpdateAsync(
    buyerId: "fe26475d-ec3e-4884-9553-f7356683f7f9",
    buyerUpdate: new BuyerUpdate() {
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
                Kind = TaxIdKind.ThId,
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
| `BuyerId`                                               | *string*                                                | :heavy_check_mark:                                      | The ID of the buyer to edit.                            | fe26475d-ec3e-4884-9553-f7356683f7f9                    |
| `BuyerUpdate`                                           | [BuyerUpdate](../../Models/Components/BuyerUpdate.md)   | :heavy_check_mark:                                      | N/A                                                     |                                                         |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[UpdateBuyerResponse](../../Models/Requests/UpdateBuyerResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Forbidden   | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Active      | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error404            | 404                                     | application/json                        |
| gr4vy.Models.Errors.Error405            | 405                                     | application/json                        |
| gr4vy.Models.Errors.Error409            | 409                                     | application/json                        |
| gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| gr4vy.Models.Errors.Error425            | 425                                     | application/json                        |
| gr4vy.Models.Errors.Error429            | 429                                     | application/json                        |
| gr4vy.Models.Errors.Error500            | 500                                     | application/json                        |
| gr4vy.Models.Errors.Error502            | 502                                     | application/json                        |
| gr4vy.Models.Errors.Error504            | 504                                     | application/json                        |
| gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |

## Delete

Permanently removes a buyer record.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Buyers.DeleteAsync(
    buyerId: "fe26475d-ec3e-4884-9553-f7356683f7f9",
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `BuyerId`                                               | *string*                                                | :heavy_check_mark:                                      | The ID of the buyer to delete.                          | fe26475d-ec3e-4884-9553-f7356683f7f9                    |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[DeleteBuyerResponse](../../Models/Requests/DeleteBuyerResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| gr4vy.Models.Errors.Error400            | 400                                     | application/json                        |
| gr4vy.Models.Errors.Error401            | 401                                     | application/json                        |
| gr4vy.Models.Errors.Error403            | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Forbidden   | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error403Active      | 403                                     | application/json                        |
| gr4vy.Models.Errors.Error404            | 404                                     | application/json                        |
| gr4vy.Models.Errors.Error405            | 405                                     | application/json                        |
| gr4vy.Models.Errors.Error409            | 409                                     | application/json                        |
| gr4vy.Models.Errors.HTTPValidationError | 422                                     | application/json                        |
| gr4vy.Models.Errors.Error425            | 425                                     | application/json                        |
| gr4vy.Models.Errors.Error429            | 429                                     | application/json                        |
| gr4vy.Models.Errors.Error500            | 500                                     | application/json                        |
| gr4vy.Models.Errors.Error502            | 502                                     | application/json                        |
| gr4vy.Models.Errors.Error504            | 504                                     | application/json                        |
| gr4vy.Models.Errors.APIException        | 4XX, 5XX                                | \*/\*                                   |