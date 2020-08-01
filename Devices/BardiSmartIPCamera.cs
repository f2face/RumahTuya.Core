using RumahTuya.Commons;
using RumahTuya.Response;
using RumahTuya.Request;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public class BardiSmartIPCamera : BaseDevice, IDevice
    {
        public BardiSmartIPCamera(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }

        // Lampu biru
        public Task<CommandResponse> SetStatusLightIndicator(bool statusLightIndicator)
        {
            Commands commands = new Commands("basic_indicator", statusLightIndicator);
            return rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetNightVision(AutoOffOn nightVision)
        {
            Commands commands = new Commands("basic_nightvision", nightVision);
            return rumahTuya.SendCommands(deviceId, commands);
        }
        
        public Task<CommandResponse> SetFlipDisplay(bool flipDisplay)
        {
            Commands commands = new Commands("basic_flip", flipDisplay);
            return rumahTuya.SendCommands(deviceId, commands);
        }

        // Timestamp
        public Task<CommandResponse> SetOSD(bool osd)
        {
            Commands commands = new Commands("basic_osd", osd);
            return rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetMotionDetectionSwitch(bool motionDetectionSwitch)
        {
            Commands commands = new Commands("motion_switch", motionDetectionSwitch);
            return rumahTuya.SendCommands(deviceId, commands);
        }
        
        public Task<CommandResponse> SetMotionDetectionSensitivity(LowMediumHigh motionDetectionSensitivity)
        {
            Commands commands = new Commands("motion_sensitivity", motionDetectionSensitivity);
            return rumahTuya.SendCommands(deviceId, commands);
        }
        
        public Task<CommandResponse> SetMotionAreaSwitch(bool motionAreaSwitch)
        {
            Commands commands = new Commands("motion_area_switch", motionAreaSwitch);
            return rumahTuya.SendCommands(deviceId, commands);
        }

        // TODO: Masih bingung nih, gan.
        /*public Task<CommandResponse> SetMotionArea(int area)
        {
            Commands commands = new Commands("motion_area", area);
            return rumahTuya.SendCommands(deviceId, commands);
        }*/

        public Task<CommandResponse> SetSoundDetectionSwitch(bool soundDetectionSwitch)
        {
            Commands commands = new Commands("decibel_switch", soundDetectionSwitch);
            return rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetSoundDetectionSensitivity(LowHigh soundDetectionSensitivity)
        {
            Commands commands = new Commands("decibel_sensitivity", soundDetectionSensitivity);
            return rumahTuya.SendCommands(deviceId, commands);
        }
    }
}
