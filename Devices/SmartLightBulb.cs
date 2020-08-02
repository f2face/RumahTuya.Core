using RumahTuya.Exceptions;
using RumahTuya.Request;
using RumahTuya.Response;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public class SmartLightBulb : BaseDevice, IDevice, IHasPowerSwitch
    {
        public SmartLightBulb(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }

        public Task<CommandResponse> PowerOn()
        {
            Commands commands = new Commands("switch_led", true);
            return rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> PowerOff()
        {
            Commands commands = new Commands("switch_led", false);
            return rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetBrightness(int brightness)
        {
            if (!ValidateNumber(brightness, 10, 1000))
            {
                throw new NumberOutOfRangeException("Brightness must be between 10 and 1000");
            }

            Commands commands = new Commands("bright_value_v2", brightness);
            return rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetPowerCountdownTimer(int minutes)
        {
            if (!ValidateNumber(minutes, 0, 1440))
            {
                throw new NumberOutOfRangeException("Timer must be between 1-1440 minutes");
            }

            Commands commands = new Commands("countdown_1", minutes * 60);
            return rumahTuya.SendCommands(deviceId, commands);
        }

        public async Task<int> GetCountdownTimer()
        {
            return int.Parse((await GetStatus().ConfigureAwait(false)).GetAttribute("countdown_1"));
        }
    }
}
