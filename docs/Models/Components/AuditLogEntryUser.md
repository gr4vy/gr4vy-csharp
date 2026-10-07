# AuditLogEntryUser


## Fields

| Field                                               | Type                                                | Required                                            | Description                                         | Example                                             |
| --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- | --------------------------------------------------- |
| `Type`                                              | *string*                                            | :heavy_minus_sign:                                  | Always `user`.                                      | user                                                |
| `Id`                                                | *string*                                            | :heavy_minus_sign:                                  | The ID of the user.                                 | 14b7b8c5-a6ba-4fb6-bbab-52d43c7f37ef                |
| `Name`                                              | *string*                                            | :heavy_check_mark:                                  | The name of the user.                               | John Doe                                            |
| `EmailAddress`                                      | *string*                                            | :heavy_minus_sign:                                  | The email address for this user.                    | john@example.com                                    |
| `IsStaff`                                           | *bool*                                              | :heavy_check_mark:                                  | Whether this is a Gr4vy staff user.                 | false                                               |
| `Status`                                            | [UserStatus](../../Models/Components/UserStatus.md) | :heavy_check_mark:                                  | N/A                                                 |                                                     |