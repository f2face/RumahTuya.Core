using RumahTuya.Exceptions;
using RumahTuya.Request;
using RumahTuya.Response;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public class SmartSocket : BaseDevice, IDevice, IHasPowerSwitch
    {
        public SmartSocket(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }

        public Task<CommandResponse> PowerOn()
        {
            Commands commands = new Commands("switch", true);
            return rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> PowerOff()
        {
            Commands commands = new Commands("switch", false);
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
            return int.Parse((await GetStatus()).GetAttribute("countdown_1"));
        }
    }
}
