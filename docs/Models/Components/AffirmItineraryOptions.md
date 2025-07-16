# AffirmItineraryOptions


## Fields

| Field                                            | Type                                             | Required                                         | Description                                      | Example                                          |
| ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ | ------------------------------------------------ |
| `Type`                                           | *string*                                         | :heavy_minus_sign:                               | The type of itinerary object.                    | flight                                           |
| `Sku`                                            | *string*                                         | :heavy_minus_sign:                               | The booking/itinerary number (if applicable).    | ABC123                                           |
| `DisplayName`                                    | *string*                                         | :heavy_minus_sign:                               | Readable description of the itinerary item.      | MIA-DCA-2019-12-11T12:07                         |
| `Venue`                                          | *string*                                         | :heavy_minus_sign:                               | The name of the venue where the event is hosted. | Petco Park                                       |
| `Location`                                       | *string*                                         | :heavy_minus_sign:                               | The address object that can be parsed.           | 925 Collins Avenue, Miami Beach, FL, 33140, US   |
| `DateStart`                                      | *string*                                         | :heavy_minus_sign:                               | The start date of this itinerary item.           | 2019-12-05                                       |
| `Management`                                     | *string*                                         | :heavy_minus_sign:                               | The corporation.                                 | Marriott                                         |