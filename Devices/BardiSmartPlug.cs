using RumahTuya.Response;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public class BardiSmartPlug : SmartSocket, IDevice, IHasPowerSwitch
    {
        public BardiSmartPlug(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }

        public async Task<Attributes> GetStatistics()
        {
            Attributes response = await GetStatus();
            return response;
        }

        public async Task<int> GetCurrent()
        {
            Attributes attr = await GetStatistics();
            return int.Parse(attr.GetAttribute("cur_current"));
        }

        public async Task<float> GetPower()
        {
            Attributes attr = await GetStatistics();
            return float.Parse(attr.GetAttribute("cur_power")) / 10;
        }

        public async Task<float> GetVoltage()
        {
            Attributes attr = await GetStatistics();
            return float.Parse(attr.GetAttribute("cur_voltage")) / 10;
        }
    }
}
