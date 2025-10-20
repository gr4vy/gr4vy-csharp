# Gr4vy C# SDK

Developer-friendly & type-safe C# SDK specifically catered to leverage *Gr4vy* API.

<div align="left">  
    <a href="https://www.nuget.org/packages/Gr4vy"><img alt="NuGet Version" src="https://img.shields.io/nuget/vpre/gr4vy?style=for-the-badge"></a>
    <a href="https://www.speakeasy.com/?utm_source=gr4vy&utm_campaign=csharp"><img src="https://custom-icon-badges.demolab.com/badge/-Built%20By%20Speakeasy-212015?style=for-the-badge&logoColor=FBE331&logo=speakeasy&labelColor=545454" /></a>
</div>

## Summary

Gr4vy C# SDK

The official Gr4vy SDK for C# provides a convenient way to interact with the Gr4vy API from your server-side application. This SDK allows you to seamlessly integrate Gr4vy's powerful payment orchestration capabilities, including:

* Creating Transactions: Initiate and process payments with various payment methods and services.
* Managing Buyers: Store and manage buyer information securely.
* Storing Payment Methods: Securely store and tokenize payment methods for future use.
* Handling Webhooks: Easily process and respond to webhook events from Gr4vy.
* And much more: Access the full suite of Gr4vy API payment features.

This SDK is designed to simplify development, reduce boilerplate code, and help you get up and running with Gr4vy quickly and efficiently. It handles authentication, request signing, and provides easy-to-use methods for most API endpoints.

<!-- No Summary [summary] -->

<!-- Start Table of Contents [toc] -->
## Table of Contents
<!-- $toc-max-depth=2 -->
* [Gr4vy C# SDK](#gr4vy-c-sdk)
  * [SDK Installation](#sdk-installation)
  * [SDK Example Usage](#sdk-example-usage)
  * [Bearer token generation](#bearer-token-generation)
  * [Embed token generation](#embed-token-generation)
  * [Merchant account ID selection](#merchant-account-id-selection)
  * [Webhooks verification](#webhooks-verification)
  * [Available Resources and Operations](#available-resources-and-operations)
  * [Global Parameters](#global-parameters)
  * [Pagination](#pagination)
  * [Retries](#retries)
  * [Error Handling](#error-handling)
  * [Server Selection](#server-selection)
  * [Custom HTTP Client](#custom-http-client)
* [Development](#development)
  * [Testing](#testing)
  * [Contributions](#contributions)

<!-- End Table of Contents [toc] -->

<!-- Start SDK Installation [installation] -->
## SDK Installation

### NuGet

To add the [NuGet](https://www.nuget.org/) package to a .NET project:
```bash
dotnet add package Gr4vy
```

### Locally

To add a reference to a local instance of the SDK in a .NET project:
```bash
dotnet add reference src/Gr4vy/Gr4vy.csproj
```
<!-- End SDK Installation [installation] -->

## SDK Example Usage

### Example

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

// Loaded the key from a file, env variable, 
// or anywhere else
var privateKey = "..."; 

var sdk = new Gr4vySDK(
    id: "example",
    server: SDKConfig.Server.Sandbox,
    bearerAuthSource: Auth.WithToken(privateKey),
    merchantAccountId: "default"
);

var res = await sdk.Transactions.ListAsync();

// handle response
```

<br /><br />
> [!IMPORTANT]
> Please use `bearerAuthSource: Auth.WithToken()` where the documentation mentions `bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",`.


<!-- No SDK Example Usage [usage] -->

## Bearer token generation

Alternatively, you can create a token for use with the SDK or with your own client library.

```csharp
using Gr4vy;

var token = Auth.GetToken(privateKey),
```

> **Note:** This will only create a token once. Use `Auth.WithToken` to dynamically generate a token
> for every request.


## Embed token generation

Alternatively, you can create a token for use with Embed as follows.

```csharp
using Gr4vy;

// Loaded the key from a file, env variable, 
// or anywhere else
var privateKey = "..."; 

var sdk = new Gr4vySDK(
    id: "example",
    server: SDKConfig.Server.Sandbox,
    bearerAuthSource: Auth.WithToken(privateKey),
    merchantAccountId: "default"
);

var checkoutSession = await sdk.CheckoutSessions.CreateAsync()

auth.get_embed_token(
    privatekey,
    embedParams=new Dictionary<string, object>
    {
        ["amount"]: 1299,
        ["currency"]: 'USD',
        ["buyer_external_identifier"]: 'user-1234',
    },
    checkoutSessionId=checkoutSession.ID
)
```

> **Note:** This will only create a token once. Use `Auth.WithToken()` to dynamically generate a token
> for every request.

## Merchant account ID selection

Depending on the key used, you might need to explicitly define a merchant account ID to use. In our API, 
this uses the `X-GR4VY-MERCHANT-ACCOUNT-ID` header. When using the SDK, you can set the `merchantAccountId`
when initializing the SDK.

```csharp
var sdk = new Gr4vySDK(
    id: "example",
    server: SDKConfig.Server.Sandbox,
    bearerAuthSource: Auth.WithToken(privateKey),
    merchantAccountId: "my-merchant-id"
);
```

## Webhooks verification

The SDK makes it easy to verify that incoming webhooks were actually sent by Gr4vy. Once you have configured the webhook subscription with its corresponding secret, that can be verified the following way:

```csharp
using Gr4vy;

// Webhook payload and headers
string payload = "your-webhook-payload";
string secret = "your-webhook-secret";
string signatureHeader = "signatures-from-header";
string timestampHeader = "timestamp-from-header";
int timestampTolerance = 300; // optional, in seconds (default: 0)

try {
    Webhooks.Verify(Payload, Secret, signatureHeader, timestampHeader, timestampTolerance);
    
}
catch(ArgumentException ex) {
    // handle the exception
}
```

### Parameters

- **`payload`**: The raw payload string received in the webhook request.
- **`secret`**: The secret used to sign the webhook. This is provided in your Gr4vy dashboard.
- **`signatureHeader`**: The `X-Gr4vy-Signature` header from the webhook request.
- **`timestampHeader`**: The `X-Gr4vy-Timestamp` header from the webhook request.
- **`timestampTolerance`**: _(Optional)_ The maximum allowed difference (in seconds) between the current time and the timestamp in the webhook. Defaults to `0` (no tolerance).

<!-- No Authentication [security] -->

<!-- Start Available Resources and Operations [operations] -->
## Available Resources and Operations

<details open>
<summary>Available methods</summary>

#### [AccountUpdater.Jobs](docs/sdks/jobs/README.md)

* [Create](docs/sdks/jobs/README.md#create) - Create account updater job

### [AuditLogs](docs/sdks/auditlogs/README.md)

* [List](docs/sdks/auditlogs/README.md#list) - List audit log entries

### [Buyers](docs/sdks/buyers/README.md)

* [List](docs/sdks/buyers/README.md#list) - List all buyers
* [Create](docs/sdks/buyers/README.md#create) - Add a buyer
* [Get](docs/sdks/buyers/README.md#get) - Get a buyer
* [Update](docs/sdks/buyers/README.md#update) - Update a buyer
* [Delete](docs/sdks/buyers/README.md#delete) - Delete a buyer

#### [Buyers.GiftCards](docs/sdks/buyersgiftcards/README.md)

* [List](docs/sdks/buyersgiftcards/README.md#list) - List gift cards for a buyer

#### [Buyers.PaymentMethods](docs/sdks/buyerspaymentmethods/README.md)

* [List](docs/sdks/buyerspaymentmethods/README.md#list) - List payment methods for a buyer

#### [Buyers.ShippingDetails](docs/sdks/shippingdetails/README.md)

* [Create](docs/sdks/shippingdetails/README.md#create) - Add buyer shipping details
* [List](docs/sdks/shippingdetails/README.md#list) - List a buyer's shipping details
* [Get](docs/sdks/shippingdetails/README.md#get) - Get buyer shipping details
* [Update](docs/sdks/shippingdetails/README.md#update) - Update a buyer's shipping details
* [Delete](docs/sdks/shippingdetails/README.md#delete) - Delete a buyer's shipping details

### [CardSchemeDefinitions](docs/sdks/cardschemedefinitions/README.md)

* [List](docs/sdks/cardschemedefinitions/README.md#list) - List card scheme definitions

### [CheckoutSessions](docs/sdks/checkoutsessions/README.md)

* [Create](docs/sdks/checkoutsessions/README.md#create) - Create checkout session
* [Update](docs/sdks/checkoutsessions/README.md#update) - Update checkout session
* [Get](docs/sdks/checkoutsessions/README.md#get) - Get checkout session
* [Delete](docs/sdks/checkoutsessions/README.md#delete) - Delete checkout session

### [DigitalWallets](docs/sdks/digitalwallets/README.md)

* [Create](docs/sdks/digitalwallets/README.md#create) - Register digital wallet
* [List](docs/sdks/digitalwallets/README.md#list) - List digital wallets
* [Get](docs/sdks/digitalwallets/README.md#get) - Get digital wallet
* [Delete](docs/sdks/digitalwallets/README.md#delete) - Delete digital wallet
* [Update](docs/sdks/digitalwallets/README.md#update) - Update digital wallet

#### [DigitalWallets.Domains](docs/sdks/domains/README.md)

* [Create](docs/sdks/domains/README.md#create) - Register a digital wallet domain
* [Delete](docs/sdks/domains/README.md#delete) - Remove a digital wallet domain

#### [DigitalWallets.Sessions](docs/sdks/sessions/README.md)

* [GooglePay](docs/sdks/sessions/README.md#googlepay) - Create a Google Pay session
* [ApplePay](docs/sdks/sessions/README.md#applepay) - Create a Apple Pay session
* [ClickToPay](docs/sdks/sessions/README.md#clicktopay) - Create a Click to Pay session

### [GiftCards](docs/sdks/giftcards/README.md)

* [Get](docs/sdks/giftcards/README.md#get) - Get gift card
* [Delete](docs/sdks/giftcards/README.md#delete) - Delete a gift card
* [Create](docs/sdks/giftcards/README.md#create) - Create gift card
* [List](docs/sdks/giftcards/README.md#list) - List gift cards

#### [GiftCards.Balances](docs/sdks/balances/README.md)

* [List](docs/sdks/balances/README.md#list) - List gift card balances

### [MerchantAccounts](docs/sdks/merchantaccounts/README.md)

* [List](docs/sdks/merchantaccounts/README.md#list) - List all merchant accounts
* [Create](docs/sdks/merchantaccounts/README.md#create) - Create a merchant account
* [Get](docs/sdks/merchantaccounts/README.md#get) - Get a merchant account
* [Update](docs/sdks/merchantaccounts/README.md#update) - Update a merchant account

### [PaymentLinks](docs/sdks/paymentlinks/README.md)

* [Create](docs/sdks/paymentlinks/README.md#create) - Add a payment link
* [List](docs/sdks/paymentlinks/README.md#list) - List all payment links
* [Expire](docs/sdks/paymentlinks/README.md#expire) - Expire a payment link
* [Get](docs/sdks/paymentlinks/README.md#get) - Get payment link

### [PaymentMethods](docs/sdks/paymentmethods/README.md)

* [List](docs/sdks/paymentmethods/README.md#list) - List all payment methods
* [Create](docs/sdks/paymentmethods/README.md#create) - Create payment method
* [Get](docs/sdks/paymentmethods/README.md#get) - Get payment method
* [Delete](docs/sdks/paymentmethods/README.md#delete) - Delete payment method

#### [PaymentMethods.NetworkTokens](docs/sdks/networktokens/README.md)

* [List](docs/sdks/networktokens/README.md#list) - List network tokens
* [Create](docs/sdks/networktokens/README.md#create) - Provision network token
* [Suspend](docs/sdks/networktokens/README.md#suspend) - Suspend network token
* [Resume](docs/sdks/networktokens/README.md#resume) - Resume network token
* [Delete](docs/sdks/networktokens/README.md#delete) - Delete network token

#### [PaymentMethods.NetworkTokens.Cryptogram](docs/sdks/cryptogram/README.md)

* [Create](docs/sdks/cryptogram/README.md#create) - Provision network token cryptogram

#### [PaymentMethods.PaymentServiceTokens](docs/sdks/paymentservicetokens/README.md)

* [List](docs/sdks/paymentservicetokens/README.md#list) - List payment service tokens
* [Create](docs/sdks/paymentservicetokens/README.md#create) - Create payment service token
* [Delete](docs/sdks/paymentservicetokens/README.md#delete) - Delete payment service token

### [PaymentOptions](docs/sdks/paymentoptions/README.md)

* [List](docs/sdks/paymentoptions/README.md#list) - List payment options

### [PaymentServiceDefinitions](docs/sdks/paymentservicedefinitions/README.md)

* [List](docs/sdks/paymentservicedefinitions/README.md#list) - List payment service definitions
* [Get](docs/sdks/paymentservicedefinitions/README.md#get) - Get a payment service definition
* [Session](docs/sdks/paymentservicedefinitions/README.md#session) - Create a session for a payment service definition

### [PaymentServices](docs/sdks/paymentservices/README.md)

* [List](docs/sdks/paymentservices/README.md#list) - List payment services
* [Create](docs/sdks/paymentservices/README.md#create) - Update a configured payment service
* [Get](docs/sdks/paymentservices/README.md#get) - Get payment service
* [Update](docs/sdks/paymentservices/README.md#update) - Configure a payment service
* [Delete](docs/sdks/paymentservices/README.md#delete) - Delete a configured payment service
* [Verify](docs/sdks/paymentservices/README.md#verify) - Verify payment service credentials
* [Session](docs/sdks/paymentservices/README.md#session) - Create a session for a payment service definition

### [Payouts](docs/sdks/payouts/README.md)

* [List](docs/sdks/payouts/README.md#list) - List payouts created
* [Create](docs/sdks/payouts/README.md#create) - Create a payout
* [Get](docs/sdks/payouts/README.md#get) - Get a payout

### [Refunds](docs/sdks/refunds/README.md)

* [Get](docs/sdks/refunds/README.md#get) - Get refund

### [ReportExecutions](docs/sdks/reportexecutions/README.md)

* [List](docs/sdks/reportexecutions/README.md#list) - List executed reports

### [Reports](docs/sdks/reports/README.md)

* [List](docs/sdks/reports/README.md#list) - List configured reports
* [Create](docs/sdks/reports/README.md#create) - Add a report
* [Get](docs/sdks/reports/README.md#get) - Get a report
* [Put](docs/sdks/reports/README.md#put) - Update a report

#### [Reports.Executions](docs/sdks/executions/README.md)

* [List](docs/sdks/executions/README.md#list) - List executions for report
* [Url](docs/sdks/executions/README.md#url) - Create URL for executed report
* [Get](docs/sdks/executions/README.md#get) - Get executed report

### [Transactions](docs/sdks/transactions/README.md)

* [List](docs/sdks/transactions/README.md#list) - List transactions
* [Create](docs/sdks/transactions/README.md#create) - Create transaction
* [Get](docs/sdks/transactions/README.md#get) - Get transaction
* [Update](docs/sdks/transactions/README.md#update) - Manually update a transaction
* [Capture](docs/sdks/transactions/README.md#capture) - Capture transaction
* [Void](docs/sdks/transactions/README.md#void) - Void transaction
* [Cancel](docs/sdks/transactions/README.md#cancel) - Cancel transaction
* [Sync](docs/sdks/transactions/README.md#sync) - Sync transaction

#### [Transactions.Events](docs/sdks/events/README.md)

* [List](docs/sdks/events/README.md#list) - List transaction events

#### [Transactions.Refunds](docs/sdks/transactionsrefunds/README.md)

* [List](docs/sdks/transactionsrefunds/README.md#list) - List transaction refunds
* [Create](docs/sdks/transactionsrefunds/README.md#create) - Create transaction refund
* [Get](docs/sdks/transactionsrefunds/README.md#get) - Get transaction refund

#### [Transactions.Refunds.All](docs/sdks/all/README.md)

* [Create](docs/sdks/all/README.md#create) - Create batch transaction refund

#### [Transactions.Settlements](docs/sdks/settlements/README.md)

* [Get](docs/sdks/settlements/README.md#get) - Get transaction settlement
* [List](docs/sdks/settlements/README.md#list) - List transaction settlements

</details>
<!-- End Available Resources and Operations [operations] -->

<!-- Start Global Parameters [global-parameters] -->
## Global Parameters

A parameter is configured globally. This parameter may be set on the SDK client instance itself during initialization. When configured as an option during SDK initialization, This global value will be used as the default on the operations that use it. When such operations are called, there is a place in each to override the global value, if needed.

For example, you can set `merchant_account_id` to `` at SDK initialization and then you do not have to pass the same value on calls to operations like `Get`. But if you want to do so you may, which will locally override the global setting. See the example code below for a demonstration.


### Available Globals

The following global parameter is available.

| Name              | Type   | Description                                             |
| ----------------- | ------ | ------------------------------------------------------- |
| merchantAccountId | string | The ID of the merchant account to use for this request. |

### Example

```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.MerchantAccounts.GetAsync(merchantAccountId: "merchant-12345");

// handle response
```
<!-- End Global Parameters [global-parameters] -->

<!-- Start Pagination [pagination] -->
## Pagination

Some of the endpoints in this SDK support pagination. To use pagination, you make your SDK calls as usual, but the
returned response object will have a `Next` method that can be called to pull down the next group of results. If the
return value of `Next` is `null`, then there are no more pages to be fetched.

Here's an example of one such pagination call:
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
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
<!-- End Pagination [pagination] -->

<!-- Start Retries [retries] -->
## Retries

Some of the endpoints in this SDK support retries. If you use the SDK without any configuration, it will fall back to the default retry strategy provided by the API. However, the default retry strategy can be overridden on a per-operation basis, or across the entire SDK.

To change the default retry strategy for a single API call, simply pass a `RetryConfig` to the call:
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

ListBuyersRequest req = new ListBuyersRequest() {
    Cursor = "ZXhhbXBsZTE",
    Search = "John",
    ExternalIdentifier = "buyer-12345",
};

ListBuyersResponse? res = await sdk.Buyers.ListAsync(
    retryConfig: new RetryConfig(
        strategy: RetryConfig.RetryStrategy.BACKOFF,
        backoff: new BackoffStrategy(
            initialIntervalMs: 1L,
            maxIntervalMs: 50L,
            maxElapsedTimeMs: 100L,
            exponent: 1.1
        ),
        retryConnectionErrors: false
    ),
    request: req
);

while(res != null)
{
    // handle items

    res = await res.Next!();
}
```

If you'd like to override the default retry strategy for all operations that support retries, you can use the `RetryConfig` optional parameter when intitializing the SDK:
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Requests;

var sdk = new Gr4vySDK(
    retryConfig: new RetryConfig(
        strategy: RetryConfig.RetryStrategy.BACKOFF,
        backoff: new BackoffStrategy(
            initialIntervalMs: 1L,
            maxIntervalMs: 50L,
            maxElapsedTimeMs: 100L,
            exponent: 1.1
        ),
        retryConnectionErrors: false
    ),
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
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
<!-- End Retries [retries] -->

<!-- Start Error Handling [errors] -->
## Error Handling

[`BaseException`](./src/Gr4vy/Models/Errors/BaseException.cs) is the base exception class for all HTTP error responses. It has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | Error message         |
| `StatusCode`  | *int*                 | HTTP status code      |
| `Headers`     | *HttpResponseHeaders* | HTTP headers          |
| `ContentType` | *string?*             | HTTP content type     |
| `RawResponse` | *HttpResponseMessage* | HTTP response object  |
| `Body`        | *string*              | HTTP response body    |

Some exceptions in this SDK include an additional `Payload` field, which will contain deserialized custom error data when present. Possible exceptions are listed in the [Error Classes](#error-classes) section.

### Example

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using Gr4vy.Models.Errors;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

try
{
    var res = await sdk.AccountUpdater.Jobs.CreateAsync(accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
        PaymentMethodIds = new List<string>() {
            "ef9496d8-53a5-4aad-8ca2-00eb68334389",
            "f29e886e-93cc-4714-b4a3-12b7a718e595",
        },
    });

    // handle response
}
catch (BaseException ex)  // all SDK exceptions inherit from BaseException
{
    // ex.ToString() provides a detailed error message
    System.Console.WriteLine(ex);

    // Base exception fields
    HttpResponseMessage rawResponse = ex.RawResponse;
    HttpResponseHeaders headers = ex.Headers;
    int statusCode = ex.StatusCode;
    string? contentType = ex.ContentType;
    var responseBody = ex.Body;

    if (ex is Error400) // different exceptions may be thrown depending on the method
    {
        // Check error data fields
        Error400Payload payload = ex.Payload;
        string Type = payload.Type;
        string Code = payload.Code;
        // ...
    }

    // An underlying cause may be provided
    if (ex.InnerException != null)
    {
        Exception cause = ex.InnerException;
    }
}
catch (System.Net.Http.HttpRequestException ex)
{
    // Check ex.InnerException for Network connectivity errors
}
```

### Error Classes

**Primary exceptions:**
* [`BaseException`](./src/Gr4vy/Models/Errors/BaseException.cs): The base class for HTTP error responses.
  * [`Error400`](./src/Gr4vy/Models/Errors/Error400.cs): The request was invalid. Status code `400`.
  * [`Error401`](./src/Gr4vy/Models/Errors/Error401.cs): The request was unauthorized. Status code `401`.
  * [`Error403`](./src/Gr4vy/Models/Errors/Error403.cs): The credentials were invalid or the caller did not have permission to act on the resource. Status code `403`.
  * [`Error404`](./src/Gr4vy/Models/Errors/Error404.cs): The resource was not found. Status code `404`.
  * [`Error405`](./src/Gr4vy/Models/Errors/Error405.cs): The request method was not allowed. Status code `405`.
  * [`Error409`](./src/Gr4vy/Models/Errors/Error409.cs): A duplicate record was found. Status code `409`.
  * [`Error425`](./src/Gr4vy/Models/Errors/Error425.cs): The request was too early. Status code `425`.
  * [`Error429`](./src/Gr4vy/Models/Errors/Error429.cs): Too many requests were made. Status code `429`.
  * [`Error500`](./src/Gr4vy/Models/Errors/Error500.cs): The server encountered an error. Status code `500`.
  * [`Error502`](./src/Gr4vy/Models/Errors/Error502.cs): The server encountered an error. Status code `502`.
  * [`Error504`](./src/Gr4vy/Models/Errors/Error504.cs): The server encountered an error. Status code `504`.
  * [`HTTPValidationError`](./src/Gr4vy/Models/Errors/HTTPValidationError.cs): Validation Error. Status code `422`. *

<details><summary>Less common exceptions (2)</summary>

* [`System.Net.Http.HttpRequestException`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httprequestexception): Network connectivity error. For more details about the underlying cause, inspect the `ex.InnerException`.

* Inheriting from [`BaseException`](./src/Gr4vy/Models/Errors/BaseException.cs):
  * [`ResponseValidationError`](./src/Gr4vy/Models/Errors/ResponseValidationError.cs): Thrown when the response data could not be deserialized into the expected type.
</details>

\* Refer to the [relevant documentation](#available-resources-and-operations) to determine whether an exception applies to a specific operation.
<!-- End Error Handling [errors] -->

<!-- Start Server Selection [server] -->
## Server Selection

### Select Server by Name

You can override the default server globally by passing a server name to the `server: string` optional parameter when initializing the SDK client instance. The selected server will then be used as the default on the operations that use it. This table lists the names associated with the available servers:

| Name         | Server                               | Variables | Description |
| ------------ | ------------------------------------ | --------- | ----------- |
| `sandbox`    | `https://api.sandbox.{id}.gr4vy.app` | `id`      |             |
| `production` | `https://api.{id}.gr4vy.app`         | `id`      |             |

If the selected server has variables, you may override its default values through the additional parameters made available in the SDK constructor:

| Variable | Parameter    | Default     | Description                            |
| -------- | ------------ | ----------- | -------------------------------------- |
| `id`     | `id: string` | `"example"` | The subdomain for your Gr4vy instance. |

#### Example

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    server: SDKConfig.Server.Production,
    id: "<id>",
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.AccountUpdater.Jobs.CreateAsync(accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
    PaymentMethodIds = new List<string>() {
        "ef9496d8-53a5-4aad-8ca2-00eb68334389",
        "f29e886e-93cc-4714-b4a3-12b7a718e595",
    },
});

// handle response
```

### Override Server URL Per-Client

The default server can also be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    serverUrl: "https://api.sandbox.example.gr4vy.app",
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.AccountUpdater.Jobs.CreateAsync(accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
    PaymentMethodIds = new List<string>() {
        "ef9496d8-53a5-4aad-8ca2-00eb68334389",
        "f29e886e-93cc-4714-b4a3-12b7a718e595",
    },
});

// handle response
```
<!-- End Server Selection [server] -->

<!-- Start Custom HTTP Client [http-client] -->
## Custom HTTP Client

The C# SDK makes API calls using an `ISpeakeasyHttpClient` that wraps the native
[HttpClient](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient). This
client provides the ability to attach hooks around the request lifecycle that can be used to modify the request or handle
errors and response.

The `ISpeakeasyHttpClient` interface allows you to either use the default `SpeakeasyHttpClient` that comes with the SDK,
or provide your own custom implementation with customized configuration such as custom message handlers, timeouts,
connection pooling, and other HTTP client settings.

The following example shows how to create a custom HTTP client with request modification and error handling:

```csharp
using Gr4vy;
using Gr4vy.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Create a custom HTTP client
public class CustomHttpClient : ISpeakeasyHttpClient
{
    private readonly ISpeakeasyHttpClient _defaultClient;

    public CustomHttpClient()
    {
        _defaultClient = new SpeakeasyHttpClient();
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        // Add custom header and timeout
        request.Headers.Add("x-custom-header", "custom value");
        request.Headers.Add("x-request-timeout", "30");
        
        try
        {
            var response = await _defaultClient.SendAsync(request, cancellationToken);
            // Log successful response
            Console.WriteLine($"Request successful: {response.StatusCode}");
            return response;
        }
        catch (Exception error)
        {
            // Log error
            Console.WriteLine($"Request failed: {error.Message}");
            throw;
        }
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
        _defaultClient?.Dispose();
    }
}

// Use the custom HTTP client with the SDK
var customHttpClient = new CustomHttpClient();
var sdk = new Gr4vy(client: customHttpClient);
```

<details>
<summary>You can also provide a completely custom HTTP client with your own configuration:</summary>

```csharp
using Gr4vy.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// Custom HTTP client with custom configuration
public class AdvancedHttpClient : ISpeakeasyHttpClient
{
    private readonly HttpClient _httpClient;

    public AdvancedHttpClient()
    {
        var handler = new HttpClientHandler()
        {
            MaxConnectionsPerServer = 10,
            // ServerCertificateCustomValidationCallback = customCertValidation, // Custom SSL validation if needed
        };

        _httpClient = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        return await _httpClient.SendAsync(request, cancellationToken ?? CancellationToken.None);
    }

    public void Dispose()
    {
        _httpClient?.Dispose();
    }
}

var sdk = Gr4vy.Builder()
    .WithClient(new AdvancedHttpClient())
    .Build();
```
</details>

<details>
<summary>For simple debugging, you can enable request/response logging by implementing a custom client:</summary>

```csharp
public class LoggingHttpClient : ISpeakeasyHttpClient
{
    private readonly ISpeakeasyHttpClient _innerClient;

    public LoggingHttpClient(ISpeakeasyHttpClient innerClient = null)
    {
        _innerClient = innerClient ?? new SpeakeasyHttpClient();
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken? cancellationToken = null)
    {
        // Log request
        Console.WriteLine($"Sending {request.Method} request to {request.RequestUri}");
        
        var response = await _innerClient.SendAsync(request, cancellationToken);
        
        // Log response
        Console.WriteLine($"Received {response.StatusCode} response");
        
        return response;
    }

    public void Dispose() => _innerClient?.Dispose();
}

var sdk = new Gr4vy(client: new LoggingHttpClient());
```
</details>

The SDK also provides built-in hook support through the `SDKConfiguration.Hooks` system, which automatically handles
`BeforeRequestAsync`, `AfterSuccessAsync`, and `AfterErrorAsync` hooks for advanced request lifecycle management.
<!-- End Custom HTTP Client [http-client] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->

# Development


## Testing

To run the tests, install .NET and run the following.

```sh
dotnet test src/Gr4vy.Tests
```

## Contributions

While we value open-source contributions to this SDK, this library is generated programmatically. Any manual changes added to internal files will be overwritten on the next generation. 
We look forward to hearing your feedback. Feel free to open a PR or an issue with a proof of concept and we'll do our best to include it in a future release. 

### SDK Created by [Speakeasy](https://www.speakeasy.com/?utm_source=gr4vy&utm_campaign=csharp)
