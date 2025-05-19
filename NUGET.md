# gr4vy


<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.AccountUpdater.Jobs.CreateAsync(
    accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
        PaymentMethodIds = new List<string>() {
            "ef9496d8-53a5-4aad-8ca2-00eb68334389",
            "f29e886e-93cc-4714-b4a3-12b7a718e595",
        },
    },
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```
<!-- End SDK Example Usage [usage] -->

<!-- Start Authentication [security] -->
## Authentication

### Per-Client Security Schemes

This SDK supports the following security scheme globally:

| Name         | Type | Scheme      |
| ------------ | ---- | ----------- |
| `BearerAuth` | http | HTTP Bearer |

To authenticate with the API the `BearerAuth` parameter must be set when initializing the SDK client instance. For example:
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.AccountUpdater.Jobs.CreateAsync(
    accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
        PaymentMethodIds = new List<string>() {
            "ef9496d8-53a5-4aad-8ca2-00eb68334389",
            "f29e886e-93cc-4714-b4a3-12b7a718e595",
        },
    },
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```
<!-- End Authentication [security] -->

<!-- Start Global Parameters [global-parameters] -->
## Global Parameters

A parameter is configured globally. This parameter may be set on the SDK client instance itself during initialization. When configured as an option during SDK initialization, This global value will be used as the default on the operations that use it. When such operations are called, there is a place in each to override the global value, if needed.

For example, you can set `merchant_account_id` to `"default"` at SDK initialization and then you do not have to pass the same value on calls to operations like `Get`. But if you want to do so you may, which will locally override the global setting. See the example code below for a demonstration.


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
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
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
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
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
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

try
{
    var res = await sdk.AccountUpdater.Jobs.CreateAsync(
        accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
            PaymentMethodIds = new List<string>() {
                "ef9496d8-53a5-4aad-8ca2-00eb68334389",
                "f29e886e-93cc-4714-b4a3-12b7a718e595",
            },
        },
        timeoutInSeconds: 1D,
        merchantAccountId: "default"
    );

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
| `production` | `https://api.{id}.gr4vy.app`         | `id`      |             |
| `sandbox`    | `https://api.sandbox.{id}.gr4vy.app` | `id`      |             |

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
    server: "sandbox",
    id: "<id>",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.AccountUpdater.Jobs.CreateAsync(
    accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
        PaymentMethodIds = new List<string>() {
            "ef9496d8-53a5-4aad-8ca2-00eb68334389",
            "f29e886e-93cc-4714-b4a3-12b7a718e595",
        },
    },
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```

### Override Server URL Per-Client

The default server can also be overridden globally by passing a URL to the `serverUrl: string` optional parameter when initializing the SDK client instance. For example:
```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
    serverUrl: "https://api.example.gr4vy.app",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>",
    merchantAccountId: "default"
);

var res = await sdk.AccountUpdater.Jobs.CreateAsync(
    accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
        PaymentMethodIds = new List<string>() {
            "ef9496d8-53a5-4aad-8ca2-00eb68334389",
            "f29e886e-93cc-4714-b4a3-12b7a718e595",
        },
    },
    timeoutInSeconds: 1D,
    merchantAccountId: "default"
);

// handle response
```
<!-- End Server Selection [server] -->

<!-- Placeholder for Future Speakeasy SDK Sections -->