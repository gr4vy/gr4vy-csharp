# ShippingDetails
(*Buyers.ShippingDetails*)

## Overview

### Available Operations

* [Create](#create) - Add buyer shipping details
* [List](#list) - List a buyer's shipping details
* [Get](#get) - Get buyer shipping details
* [Update](#update) - Update a buyer's shipping details
* [Delete](#delete) - Delete a buyer's shipping details

## Create

Associate shipping details to a buyer.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Buyers.ShippingDetails.CreateAsync(
    buyerId: "fe26475d-ec3e-4884-9553-f7356683f7f9",
    shippingDetailsCreate: new ShippingDetailsCreate() {
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
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                                                 | Type                                                                      | Required                                                                  | Description                                                               | Example                                                                   |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `BuyerId`                                                                 | *string*                                                                  | :heavy_check_mark:                                                        | The ID of the buyer to add shipping details to.                           | fe26475d-ec3e-4884-9553-f7356683f7f9                                      |
| `ShippingDetailsCreate`                                                   | [ShippingDetailsCreate](../../Models/Components/ShippingDetailsCreate.md) | :heavy_check_mark:                                                        | N/A                                                                       |                                                                           |
| `TimeoutInSeconds`                                                        | *double*                                                                  | :heavy_minus_sign:                                                        | N/A                                                                       |                                                                           |
| `MerchantAccountId`                                                       | *string*                                                                  | :heavy_minus_sign:                                                        | The ID of the merchant account to use for this request.                   | default                                                                   |

### Response

**[AddBuyerShippingDetailsResponse](../../Models/Requests/AddBuyerShippingDetailsResponse.md)**

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

## List

List all the shipping details associated to a specific buyer.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Buyers.ShippingDetails.ListAsync(
    buyerId: "fe26475d-ec3e-4884-9553-f7356683f7f9",
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `BuyerId`                                               | *string*                                                | :heavy_check_mark:                                      | The ID of the buyer to retrieve shipping details for.   | fe26475d-ec3e-4884-9553-f7356683f7f9                    |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[ListBuyerShippingDetailsResponse](../../Models/Requests/ListBuyerShippingDetailsResponse.md)**

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

Get a buyer's shipping details.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Buyers.ShippingDetails.GetAsync(
    buyerId: "fe26475d-ec3e-4884-9553-f7356683f7f9",
    shippingDetailsId: "bf8c36ad-02d9-4904-b0f9-a230b149e341",
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `BuyerId`                                               | *string*                                                | :heavy_check_mark:                                      | The ID of the buyer to retrieve shipping details for.   | fe26475d-ec3e-4884-9553-f7356683f7f9                    |
| `ShippingDetailsId`                                     | *string*                                                | :heavy_check_mark:                                      | The ID of the shipping details to retrieve.             | bf8c36ad-02d9-4904-b0f9-a230b149e341                    |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[GetBuyerShippingDetailsResponse](../../Models/Requests/GetBuyerShippingDetailsResponse.md)**

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

Update the shipping details associated to a specific buyer.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;
using gr4vy.Models.Requests;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

UpdateBuyerShippingDetailsRequest req = new UpdateBuyerShippingDetailsRequest() {
    BuyerId = "fe26475d-ec3e-4884-9553-f7356683f7f9",
    ShippingDetailsId = "bf8c36ad-02d9-4904-b0f9-a230b149e341",
    ShippingDetailsUpdate = new ShippingDetailsUpdate() {
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
};

var res = await sdk.Buyers.ShippingDetails.UpdateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                       | Type                                                                                            | Required                                                                                        | Description                                                                                     |
| ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| `request`                                                                                       | [UpdateBuyerShippingDetailsRequest](../../Models/Requests/UpdateBuyerShippingDetailsRequest.md) | :heavy_check_mark:                                                                              | The request object to use for the request.                                                      |

### Response

**[UpdateBuyerShippingDetailsResponse](../../Models/Requests/UpdateBuyerShippingDetailsResponse.md)**

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

Delete the shipping details associated to a specific buyer.

### Example Usage

```csharp
using gr4vy;
using gr4vy.Models.Components;

var sdk = new Gr4vy(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.Buyers.ShippingDetails.DeleteAsync(
    buyerId: "fe26475d-ec3e-4884-9553-f7356683f7f9",
    shippingDetailsId: "bf8c36ad-02d9-4904-b0f9-a230b149e341",
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Parameters

| Parameter                                               | Type                                                    | Required                                                | Description                                             | Example                                                 |
| ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- | ------------------------------------------------------- |
| `BuyerId`                                               | *string*                                                | :heavy_check_mark:                                      | The ID of the buyer to delete shipping details for.     | fe26475d-ec3e-4884-9553-f7356683f7f9                    |
| `ShippingDetailsId`                                     | *string*                                                | :heavy_check_mark:                                      | The ID of the shipping details to delete.               | bf8c36ad-02d9-4904-b0f9-a230b149e341                    |
| `TimeoutInSeconds`                                      | *double*                                                | :heavy_minus_sign:                                      | N/A                                                     |                                                         |
| `MerchantAccountId`                                     | *string*                                                | :heavy_minus_sign:                                      | The ID of the merchant account to use for this request. | default                                                 |

### Response

**[DeleteBuyerShippingDetailsResponse](../../Models/Requests/DeleteBuyerShippingDetailsResponse.md)**

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