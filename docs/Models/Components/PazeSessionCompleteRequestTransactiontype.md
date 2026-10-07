# PazeSessionCompleteRequestTransactiontype

The type of transaction being completed. PURCHASE for a one-off checkout, CARD_ON_FILE to retain the card for future use, or BOTH.

## Example Usage

```csharp
using Gr4vy.Models.Components;

var value = PazeSessionCompleteRequestTransactiontype.Purchase;

// Open enum: use .Of() to create instances from custom string values
var custom = PazeSessionCompleteRequestTransactiontype.Of("custom_value");
```


## Values

| Name         | Value        |
| ------------ | ------------ |
| `Purchase`   | PURCHASE     |
| `CardOnFile` | CARD_ON_FILE |
| `Both`       | BOTH         |