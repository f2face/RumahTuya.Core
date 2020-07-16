using RumahTuya.Exceptions;
using RumahTuya.Request;
using RumahTuya.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public class SmartLightBulb : BaseDevice, IDevice
    {
        public SmartLightBulb(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }

        public override Task<CommandResponse> PowerOn()
        {
            Commands commands = new Commands(new List<Command>()
                {
                    new Command("switch_led", true)
                });

            return base._rumahTuya.SendCommands(deviceId, commands);
        }

        public override Task<CommandResponse> PowerOff()
        {
            Commands commands = new Commands(new List<Command>()
                {
                    new Command("switch_led", false)
                });

            return base._rumahTuya.SendCommands(deviceId, commands);
        }
    
        public Task<CommandResponse> SetBrightness(int brightness)
        {
            if (!base.ValidateNumber(brightness, 10, 1000))
            {
                throw new NumberOutOfRangeException("Brightness must be between 10 and 1000");
            }

            Commands commands = new Commands(new List<Command>()
                {
                    new Command("bright_value_v2", brightness)
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
