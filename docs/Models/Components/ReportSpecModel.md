# ReportSpecModel

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = ReportSpecModel.Transactions;

// Open enum: use .Of() to create instances from custom string values
var custom = ReportSpecModel.Of("custom_value");
```


## Values

| Name                  | Value                 |
| --------------------- | --------------------- |
| `Transactions`        | transactions          |
| `TransactionRetries`  | transaction_retries   |
| `DetailedSettlement`  | detailed_settlement   |
| `AccountsReceivables` | accounts_receivables  |
| `AiInsights`          | ai_insights           |