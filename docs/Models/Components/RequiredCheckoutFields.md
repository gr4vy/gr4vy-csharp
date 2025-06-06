# RequiredCheckoutFields

A collection of checkout fields and the conditions under which they are required.


## Fields

| Field                                                                                 | Type                                                                                  | Required                                                                              | Description                                                                           | Example                                                                               |
| ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| `RequiredFields`                                                                      | List<*string*>                                                                        | :heavy_check_mark:                                                                    | A list of transaction fields that are required to process a payment for this service. | [<br/>"address.line1",<br/>"address.country",<br/>"address.city",<br/>"address.postal_code"<br/>] |
| `Conditions`                                                                          | Dictionary<String, *object*>                                                          | :heavy_minus_sign:                                                                    | The conditions under which these fields are required                                  | {<br/>"country": [<br/>"IN"<br/>]<br/>}                                               |