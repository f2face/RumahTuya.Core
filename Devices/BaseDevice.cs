using RumahTuya.Response;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public abstract class BaseDevice : IDevice
    {
        protected string deviceId;
        protected RumahTuya rumahTuya;

        public BaseDevice(RumahTuya context, string deviceId)
        {
            rumahTuya = context;
            this.deviceId = deviceId;
        }

        public string GetDeviceID()
        {
            return deviceId;
        }

        public async Task<string> GetName()
        {
            return (await GetInfo()).Name;
        }

        public async Task<string> GetLocalKey()
        {
            return (await GetInfo()).LocalKey;
        }

        public async Task<string> GetIPAddress()
        {
            return (await GetInfo()).IPAddress;
        }

        public async Task<bool> IsOnline()
        {
            return (await GetInfo()).IsOnline;
        }

        public Task<DeviceInfo> GetInfo()
        {
            return rumahTuya.GetDeviceInfo(deviceId);
        }

        public Task<Attributes> GetStatus()
        {
           return rumahTuya.GetDeviceStatus(deviceId);
        }

        public Task<DeviceSpecs> GetSpecifications()
        {
            return rumahTuya.GetDeviceSpecifications(deviceId);
        }

        public Task<DeviceFunctions> GetFunctions()
        {
            return rumahTuya.GetDeviceFunctions(deviceId);
        }

        protected bool ValidateNumber(int number, int min, int max)
        {
            return number >= min && number <= max;
        }
    }
}
