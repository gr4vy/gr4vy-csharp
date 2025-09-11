# gr4vy


<!-- Start SDK Example Usage [usage] -->
## SDK Example Usage

### Example

```csharp
using Gr4vy;
using Gr4vy.Models.Components;
using System.Collections.Generic;

var sdk = new Gr4vySDK(
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

var res = await sdk.AccountUpdater.Jobs.CreateAsync(accountUpdaterJobCreate: new AccountUpdaterJobCreate() {
    PaymentMethodIds = new List<string>() {
        "ef9496d8-53a5-4aad-8ca2-00eb68334389",
        "f29e886e-93cc-4714-b4a3-12b7a718e595",
    },
});

// handle response
```
<!-- End Authentication [security] -->

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

<!-- Placeholder for Future Speakeasy SDK Sections -->