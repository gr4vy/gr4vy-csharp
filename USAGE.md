<!-- Start SDK Example Usage [usage] -->
```csharp
using Gr4vy;
using Gr4vy.Models.Components;

var sdk = new Gr4vySDK(
    merchantAccountId: "default",
    bearerAuth: "<YOUR_BEARER_TOKEN_HERE>"
);

var res = await sdk.BrowsePaymentMethodDefinitionsGetAsync();

// handle response
```
<!-- End SDK Example Usage [usage] -->