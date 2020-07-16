using RumahTuya.Exceptions;
using RumahTuya.Request;
using RumahTuya.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    class SmartSocket : BaseDevice, IDevice
    {
        public SmartSocket(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }

        public override Task<CommandResponse> PowerOn()
        {
            Commands commands = new Commands(new List<Command>()
                {
                    new Command("switch", true)
                });

            return base._rumahTuya.SendCommands(deviceId, commands);
        }

        public override Task<CommandResponse> PowerOff()
        {
            Commands commands = new Commands(new List<Command>()
                {
                    new Command("switch", false)
                });

            return base._rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetPowerCountdownTimer(int minutes)
        {
            if (!base.ValidateNumber(minutes, 0, 1440))
            {
                throw new NumberOutOfRangeException("Timer must be between 1-1440 minutes");
            }

            Commands commands = new Commands(new List<Command>()
                {
                    new Command("countdown_1", minutes*60)
                });

            return base._rumahTuya.SendCommands(deviceId, commands);
        }
    }
}
