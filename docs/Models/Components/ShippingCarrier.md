# ShippingCarrier

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = ShippingCarrier.Amazon;

// Open enum: use .Of() to create instances from custom string values
var custom = ShippingCarrier.Of("custom_value");
```


## Values

| Name             | Value            |
| ---------------- | ---------------- |
| `Amazon`         | amazon           |
| `Bpost`          | bpost            |
| `Brt`            | brt              |
| `CanadaPost`     | canada_post      |
| `CeskaPosta`     | ceska_posta      |
| `Dhl`            | dhl              |
| `Doordash`       | doordash         |
| `Dpd`            | dpd              |
| `Evri`           | evri             |
| `Fedex`          | fedex            |
| `Gls`            | gls              |
| `Inpost`         | inpost           |
| `JtExpress`      | jt_express       |
| `LandmarkGlobal` | landmark_global  |
| `Lasership`      | lasership        |
| `Packeta`        | packeta          |
| `Ppl`            | ppl              |
| `Purolator`      | purolator        |
| `RrDonnelley`    | rr_donnelley     |
| `Sda`            | sda              |
| `Ups`            | ups              |
| `Usps`           | usps             |
| `Veho`           | veho             |
| `Other`          | other            |