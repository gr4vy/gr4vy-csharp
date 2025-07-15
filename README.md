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

### [AccountUpdater](docs/sdks/accountupdater/README.md)


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
* [Session](docs/sdks/paymentservicedefinitions/README.md#session) - Create a session for apayment service definition

### [PaymentServices](docs/sdks/paymentservices/README.md)

* [List](docs/sdks/paymentservices/README.md#list) - List payment services
* [Create](docs/sdks/paymentservices/README.md#create) - Update a configured payment service
* [Get](docs/sdks/paymentservices/README.md#get) - Get payment service
* [Update](docs/sdks/paymentservices/README.md#update) - Configure a payment service
* [Delete](docs/sdks/paymentservices/README.md#delete) - Delete a configured payment service
* [Verify](docs/sdks/paymentservices/README.md#verify) - Verify payment service credentials
* [Session](docs/sdks/paymentservices/README.md#session) - Create a session for apayment service definition

### [Payouts](docs/sdks/payouts/README.md)

* [List](docs/sdks/payouts/README.md#list) - List payouts created.
* [Create](docs/sdks/payouts/README.md#create) - Create a payout.
* [Get](docs/sdks/payouts/README.md#get) - Get a payout.

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

Handling errors in this SDK should largely match your expectations. All operations return a response object or throw an exception.

By default, an API error will raise a `Gr4vy.Models.Errors.APIException` exception, which has the following properties:

| Property      | Type                  | Description           |
|---------------|-----------------------|-----------------------|
| `Message`     | *string*              | The error message     |
| `StatusCode`  | *int*                 | The HTTP status code  |
| `RawResponse` | *HttpResponseMessage* | The raw HTTP response |
| `Body`        | *string*              | The response content  |

When custom error responses are specified for an operation, the SDK may also throw their associated exceptions. You can refer to respective *Errors* tables in SDK docs for more details on possible exception types for each operation. For example, the `CreateAsync` method throws the following exceptions:

| Error Type                              | Status Code | Content Type     |
| --------------------------------------- | ----------- | ---------------- |
| Gr4vy.Models.Errors.Error400            | 400         | application/json |
| Gr4vy.Models.Errors.Error401            | 401         | application/json |
| Gr4vy.Models.Errors.Error403            | 403         | application/json |
| Gr4vy.Models.Errors.Error404            | 404         | application/json |
| Gr4vy.Models.Errors.Error405            | 405         | application/json |
| Gr4vy.Models.Errors.Error409            | 409         | application/json |
| Gr4vy.Models.Errors.HTTPValidationError | 422         | application/json |
| Gr4vy.Models.Errors.Error425            | 425         | application/json |
| Gr4vy.Models.Errors.Error429            | 429         | application/json |
| Gr4vy.Models.Errors.Error500            | 500         | application/json |
| Gr4vy.Models.Errors.Error502            | 502         | application/json |
| Gr4vy.Models.Errors.Error504            | 504         | application/json |
| Gr4vy.Models.Errors.APIException        | 4XX, 5XX    | \*/\*            |

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
catch (Exception ex)
{
    if (ex is Error400)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error401)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error403)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error404)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error405)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error409)
    {
        // Handle exception data
        throw;
    }
    else if (ex is HTTPValidationError)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error425)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error429)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error500)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error502)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Error504)
    {
        // Handle exception data
        throw;
    }
    else if (ex is Gr4vy.Models.Errors.APIException)
    {
        // Handle default exception
        throw;
    }
}
```
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
