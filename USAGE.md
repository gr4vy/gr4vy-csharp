<!-- Start SDK Example Usage [usage] -->
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