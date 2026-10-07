# AntiFraudDecision

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = AntiFraudDecision.Accept;

// Open enum: use .Of() to create instances from custom string values
var custom = AntiFraudDecision.Of("custom_value");
```


## Values

| Name        | Value       |
| ----------- | ----------- |
| `Accept`    | accept      |
| `Error`     | error       |
| `Exception` | exception   |
| `Reject`    | reject      |
| `Review`    | review      |
| `Skipped`   | skipped     |
| `Pending`   | pending     |