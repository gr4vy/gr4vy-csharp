# ThreeDSecureData

Pass through 3-D Secure data to support external 3-D Secure authorisation. If using an external 3-D Secure provider, you should not pass a `redirect_url` in the `payment_method` object for a transaction.


## Supported Types

### ThreeDSecureDataV1

```csharp
ThreeDSecureData.CreateThreeDSecureDataV1(/* values here */);
```

### ThreeDSecureDataV2

```csharp
ThreeDSecureData.CreateThreeDSecureDataV2(/* values here */);
```
