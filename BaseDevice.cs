using RumahTuya.Response;
using System.Threading.Tasks;

namespace RumahTuya
{
    public abstract class BaseDevice : IDevice
    {
        protected string deviceId;
        protected RumahTuya _rumahTuya;

        public abstract Task<CommandResponse> PowerOn();
        public abstract Task<CommandResponse> PowerOff();

        public BaseDevice(RumahTuya context, string deviceId)
        {
            _rumahTuya = context;
            this.deviceId = deviceId;
        }

        public string GetDeviceId()
        {
            return this.deviceId;
        }

        public Task<string> GetInfo()
        {
            return this._rumahTuya.GetDeviceInfo(this.deviceId);
        }
        
        public Task<string> GetStatus()
        {
            return this._rumahTuya.GetDeviceInfo(this.deviceId);
        }
        
        public Task<string> GetSpecifications()
        {
            return this._rumahTuya.GetDeviceSpecifications(this.deviceId);
        }
        
        public Task<string> GetFunctions()
        {
            return this._rumahTuya.GetDeviceFunctions(this.deviceId);
        }

        protected bool ValidateNumber(int number, int min, int max)
        {
            return (number >= min && number <= max);
        }
    }
}
