using RumahTuya.Exceptions;
using RumahTuya.Request;
using RumahTuya.Response;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public class BardiSmartLightBulbWW : SmartLightBulb, IDevice, IHasPowerSwitch
    {
        public BardiSmartLightBulbWW(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }

        public Task<CommandResponse> SetTemperature(int temperature)
        {
            if (!ValidateNumber(temperature, 0, 1000))
            {
                throw new NumberOutOfRangeException("Temperature must be between 0 and 1000");
            }

            Commands commands = new Commands("temp_value_v2", temperature);
            return rumahTuya.SendCommands(deviceId, commands);
        }
    }
}
