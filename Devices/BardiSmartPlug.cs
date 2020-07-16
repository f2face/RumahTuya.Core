namespace RumahTuya.Devices
{
    class BardiSmartPlug : SmartSocket, IDevice
    {
        public BardiSmartPlug(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }
    }
}
