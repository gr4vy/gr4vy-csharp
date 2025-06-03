# ReportCreate


## Fields

| Field                                     | Type                                      | Required                                  | Description                               | Example                                   |
| ----------------------------------------- | ----------------------------------------- | ----------------------------------------- | ----------------------------------------- | ----------------------------------------- |
| `Name`                                    | *string*                                  | :heavy_check_mark:                        | The name of the report.                   | Monthly Transaction Report                |
| `Description`                             | *string*                                  | :heavy_minus_sign:                        | A description of the report.              | Monthly transaction summary for May 2024. |
| `Schedule`                                | *string*                                  | :heavy_check_mark:                        | N/A                                       |                                           |
| `ScheduleEnabled`                         | *bool*                                    | :heavy_check_mark:                        | Whether the report schedule is enabled.   | true                                      |
| `ScheduleTimezone`                        | *string*                                  | :heavy_minus_sign:                        | The timezone for the report schedule.     | UTC                                       |
| `Spec`                                    | [Spec](../../Models/Components/Spec.md)   | :heavy_check_mark:                        | The report specification.                 |                                           |