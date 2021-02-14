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

## Development
### Add new device
To add a new type of device, simply create a file in `Devices` directory and make sure it extends `BaseDevice`. If your device has power switch, you will also need to implement `IHasPowerSwitch` interface.

See the following template:

    namespace RumahTuya.Devices
    {
        public class MyNewDevice : BaseDevice, IHasPowerSwitch
        {
            public MyNewDevice(RumahTuya context, string deviceId) : base(context, deviceId)
            {
                // No need to do anything here
            }

            public Task<CommandResponse> PowerOn()
            {
                // Switch the device on
            }

            public Task<CommandResponse> PowerOff()
            {
                // Switch the device off
            }

            public Task<CommandResponse> SetPowerCountdownTimer(int minutes)
            {
                //
            }

            public async Task<int> GetCountdownTimer()
            {
                //
            }
        }
    }
