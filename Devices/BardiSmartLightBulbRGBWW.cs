using ColorMine.ColorSpaces;
using RumahTuya.Request;
using RumahTuya.Response;
using System;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public class BardiSmartLightBulbRGBWW : BardiSmartLightBulbWW, IDevice, IHasPowerSwitch
    {
        public enum WorkMode
        {
            White,
            Color,
            Scene,
            Music
        }

        public BardiSmartLightBulbRGBWW(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }

        public Task<CommandResponse> ActivateMode(WorkMode mode)
        {
            string workMode;
            switch (mode)
            {
                case WorkMode.White:
                    workMode = "white";
                    break;
                case WorkMode.Color:
                    workMode = "colour";
                    break;
                case WorkMode.Scene:
                    workMode = "scene";
                    break;
                case WorkMode.Music:
                    workMode = "music";
                    break;
                default:
                    workMode = "white";
                    break;
            }

            Commands commands = new Commands("work_mode", workMode);

            return rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetColorFromRGB(Rgb rgb)
        {
            Hsv hsv = rgb.To<Hsv>();

            Commands commands = new Commands();
            commands.AddCommand("work_mode", "colour");
            commands.AddCommand("colour_data_v2", new
            {
                h = Math.Round(hsv.H),
                s = Math.Round(hsv.S * 1000),
                v = Math.Round(hsv.V * 1000)
            });

            return rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetColorFromHSL(Hsl hsl)
        {
            Hsv hsv = hsl.To<Hsv>();

            Commands commands = new Commands();
            commands.AddCommand("work_mode", "colour");
            commands.AddCommand("colour_data_v2", new
            {
                h = Math.Round(hsv.H),
                s = Math.Round(hsv.S * 1000),
                v = Math.Round(hsv.V * 1000)
            });

            return rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetColor(System.Drawing.Color color)
        {
            Hsv hsv = new Hsb()
            {
                H = color.GetHue(),
                S = color.GetSaturation(),
                B = color.GetBrightness()
            }.To<Hsv>();

            Commands commands = new Commands();
            commands.AddCommand("work_mode", "colour");
            commands.AddCommand("colour_data_v2", new
            {
                h = Math.Round(hsv.H),
                s = Math.Round(hsv.S * 1000),
                v = Math.Round(hsv.V * 1000)
            });

            return rumahTuya.SendCommands(deviceId, commands);
        }
    }
}
