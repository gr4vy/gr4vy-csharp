# PurposeCode

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = PurposeCode.Mortgage;

// Open enum: use .Of() to create instances from custom string values
var custom = PurposeCode.Of("custom_value");
```


## Values

| Name               | Value              |
| ------------------ | ------------------ |
| `Mortgage`         | mortgage           |
| `Utility`          | utility            |
| `Loan`             | loan               |
| `DependantSupport` | dependant_support  |
| `Gambling`         | gambling           |
| `Retail`           | retail             |
| `Salary`           | salary             |
| `Personal`         | personal           |
| `Government`       | government         |
| `Pension`          | pension            |
| `Tax`              | tax                |
| `Other`            | other              |