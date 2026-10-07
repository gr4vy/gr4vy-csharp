# CertificateAlgorithm

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = CertificateAlgorithm.Ecdsa;

// Open enum: use .Of() to create instances from custom string values
var custom = CertificateAlgorithm.Of("custom_value");
```


## Values

| Name    | Value   |
| ------- | ------- |
| `Ecdsa` | ECDSA   |
| `Rsa`   | RSA     |