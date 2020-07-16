using RumahTuya.Exceptions;
using RumahTuya.Request;
using RumahTuya.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public class BardiSmartLightBulbWW : SmartLightBulb, IDevice
    {
        public BardiSmartLightBulbWW(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }

        public Task<CommandResponse> SetTemperature(int temperature)
        {
            if (!base.ValidateNumber(temperature, 0, 1000))
            {
                throw new NumberOutOfRangeException("Temperature must be between 0 and 1000");
            }

            Commands commands = new Commands(new List<Command>()
                {
                    new Command("temp_value_v2", temperature)
                });

            return base._rumahTuya.SendCommands(deviceId, commands);
        }
    }
}
