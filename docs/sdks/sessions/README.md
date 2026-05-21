# DigitalWallets.Sessions

## Overview

### Available Operations

* [GooglePay](#googlepay) - Create a Google Pay session
* [ApplePay](#applepay) - Create a Apple Pay session
* [Paze](#paze) - Create a Paze session
* [PazeMobileSessionReview](#pazemobilesessionreview) - Review a Paze session
* [ClickToPay](#clicktopay) - Create a Click to Pay session

## GooglePay

Create a session for use with Google Pay.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create_google_pay_digital_wallet_session" method="post" path="/digital-wallets/google/session" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.DigitalWallets.Sessions.GooglePayAsync(googlePaySessionRequest: new GooglePaySessionRequest() {
    OriginDomain = "example.com",
});

// handle response
```

### Parameters

| Parameter                                                                     | Type                                                                          | Required                                                                      | Description                                                                   | Example                                                                       |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| `GooglePaySessionRequest`                                                     | [GooglePaySessionRequest](../../Models/Components/GooglePaySessionRequest.md) | :heavy_check_mark:                                                            | N/A                                                                           |                                                                               |
| `MerchantAccountId`                                                           | *string*                                                                      | :heavy_minus_sign:                                                            | The ID of the merchant account to use for this request.                       | default                                                                       |

### Response

**[GooglePaySession](../../Models/Components/GooglePaySession.md)**

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

## ApplePay

Create a session for use with Apple Pay.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create_apple_pay_digital_wallet_session" method="post" path="/digital-wallets/apple/session" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.DigitalWallets.Sessions.ApplePayAsync(applePaySessionRequest: new ApplePaySessionRequest() {
    ValidationUrl = "https://apple-pay-gateway-cert.apple.com",
    DomainName = "example.com",
});

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 | Example                                                                     |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `ApplePaySessionRequest`                                                    | [ApplePaySessionRequest](../../Models/Components/ApplePaySessionRequest.md) | :heavy_check_mark:                                                          | N/A                                                                         |                                                                             |
| `MerchantAccountId`                                                         | *string*                                                                    | :heavy_minus_sign:                                                          | The ID of the merchant account to use for this request.                     | default                                                                     |

### Response

**[Dictionary<string, object>](../../Models/.md)**

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

## Paze

Create a session for use with Paze.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create_paze_digital_wallet_session" method="post" path="/digital-wallets/paze/session" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.DigitalWallets.Sessions.PazeAsync(pazeSessionRequest: new PazeSessionRequest() {});

// handle response
```

### Parameters

| Parameter                                                           | Type                                                                | Required                                                            | Description                                                         | Example                                                             |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `PazeSessionRequest`                                                | [PazeSessionRequest](../../Models/Components/PazeSessionRequest.md) | :heavy_check_mark:                                                  | N/A                                                                 |                                                                     |
| `MerchantAccountId`                                                 | *string*                                                            | :heavy_minus_sign:                                                  | The ID of the merchant account to use for this request.             | default                                                             |

### Response

**[ResponseCreatePazeDigitalWalletSession](../../Models/Requests/ResponseCreatePazeDigitalWalletSession.md)**

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

## PazeMobileSessionReview

Review a Paze checkout session and retrieve the selected card, consumer, and shipping address details.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="review_paze_mobile_session" method="post" path="/digital-wallets/paze/session/review" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.DigitalWallets.Sessions.PazeMobileSessionReviewAsync(pazeSessionReviewRequest: new PazeSessionReviewRequest() {
    SessionId = "7c1cba03-d20e-4a3f-9d77-e5dc23a39ac2",
    Code = "eyJhdWQiOm51bGwsImtpZCI6IjE3...",
    AccessToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9...",
});

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     | Example                                                                         |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `PazeSessionReviewRequest`                                                      | [PazeSessionReviewRequest](../../Models/Components/PazeSessionReviewRequest.md) | :heavy_check_mark:                                                              | N/A                                                                             |                                                                                 |
| `MerchantAccountId`                                                             | *string*                                                                        | :heavy_minus_sign:                                                              | The ID of the merchant account to use for this request.                         | default                                                                         |

### Response

**[PazeSessionReview](../../Models/Components/PazeSessionReview.md)**

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

## ClickToPay

Create a session for use with Click to Pay.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="create_click_to_pay_digital_wallet_session" method="post" path="/digital-wallets/click-to-pay/session" -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ClickToPaySessionRequest req = new ClickToPaySessionRequest() {
    CheckoutSessionId = "4137b1cf-39ac-42a8-bad6-1c680d5dab6b",
};

var res = await sdk.DigitalWallets.Sessions.ClickToPayAsync(req);

// handle response
```

### Parameters

| Parameter                                                                       | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `request`                                                                       | [ClickToPaySessionRequest](../../Models/Components/ClickToPaySessionRequest.md) | :heavy_check_mark:                                                              | The request object to use for the request.                                      |

### Response

**[ClickToPaySession](../../Models/Components/ClickToPaySession.md)**

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