# RumahTuya.Core
`RumahTuya.Core` is an implementation of Tuya Cloud API in C#.NET.

## Example

### `Using` Directives

    using RumahTuya;
    using RumahTuya.Devices;
    using RumahTuya.Response;

### Initialize `RumahTuya`

    RumahTuya rt = new RumahTuya("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET");

### Initialize device

    SmartSocket stopKontak = SmartSocket(rt, "DEVICE_ID");

### Authorization
Get access token, refresh token, etc.

    Credentials credentials;
    credentials = await rt.Authorize();

Get a new access token, refresh token, etc after they're expired.

    credentials = await rt.Reauthorize();

### Send commands
Send commands to the device.

    CommandResponse response;

	// Power on
    response = await stopKontak.PowerOn();

	// Power off
    response = await stopKontak.PowerOff();

