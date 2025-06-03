# ReportSummary


## Fields

| Field                                           | Type                                            | Required                                        | Description                                     | Example                                         |
| ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- | ----------------------------------------------- |
| `Type`                                          | *string*                                        | :heavy_minus_sign:                              | Always `report`.                                | report                                          |
| `Id`                                            | *string*                                        | :heavy_check_mark:                              | The unique ID for the report.                   | a1b2c3d4-5678-90ab-cdef-1234567890ab            |
| `MerchantAccountId`                             | *string*                                        | :heavy_check_mark:                              | The merchant account ID this report belongs to. | merchant-account-12345                          |
| `Name`                                          | *string*                                        | :heavy_check_mark:                              | The name of the report.                         | Monthly Transaction Report                      |
| `CreatorId`                                     | *string*                                        | :heavy_minus_sign:                              | The ID of the user who created the report.      | d290f1ee-6c54-4b01-90e6-d701748f0851            |
| `CreatorDisplayName`                            | *string*                                        | :heavy_minus_sign:                              | The display name of the report creator.         | Jane Doe                                        |
| `CreatorType`                                   | *string*                                        | :heavy_minus_sign:                              | The type of the report creator.                 | user                                            |