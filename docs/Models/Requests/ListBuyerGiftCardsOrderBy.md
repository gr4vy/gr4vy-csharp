# ListBuyerGiftCardsOrderBy

The direction to sort the gift cards in.

## Example Usage

```csharp
using Gr4vy.Models.Requests;

var value = ListBuyerGiftCardsOrderBy.Asc;

// Open enum: use .Of() to create instances from custom string values
var custom = ListBuyerGiftCardsOrderBy.Of("custom_value");
```


## Values

| Name   | Value  |
| ------ | ------ |
| `Asc`  | asc    |
| `Desc` | desc   |