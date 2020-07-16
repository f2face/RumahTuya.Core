using ColorMine.ColorSpaces;
using RumahTuya.Request;
using RumahTuya.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public enum Mode
    {
        White,
        Color,
        Scene,
        Music
    }

    public class BardiSmartLightBulbRGBWW : BardiSmartLightBulbWW, IDevice
    {
        public BardiSmartLightBulbRGBWW(RumahTuya context, string deviceId) : base(context, deviceId)
        {
        }

        public Task<CommandResponse> ActivateMode(Mode mode)
        {
            string workMode;
            switch (mode)
            {
                case Mode.White:
                    workMode = "white";
                    break;
                case Mode.Color:
                    workMode = "colour";
                    break;
                case Mode.Scene:
                    workMode = "scene";
                    break;
                case Mode.Music:
                    workMode = "music";
                    break;
                default:
                    workMode = "white";
                    break;
            }

            Commands commands = new Commands(new List<Command>()
                {
                    new Command("work_mode", workMode)
                });

            return base._rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetColorFromRGB(Rgb rgb)
        {
            Hsv hsv = rgb.To<Hsv>();

            Commands commands = new Commands(new List<Command>()
                {
                    new Command("work_mode", "colour"),
                    new Command("colour_data_v2", new {
                        h = Math.Round(hsv.H),
                        s = Math.Round(hsv.S * 1000),
                        v = Math.Round(hsv.V * 1000)
                    })
                });

            return base._rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetColorFromHSL(Hsl hsl)
        {
            Hsv hsv = hsl.To<Hsv>();

            Commands commands = new Commands(new List<Command>()
                {
                    new Command("work_mode", "colour"),
                    new Command("colour_data_v2", new {
                        h = Math.Round(hsv.H),
                        s = Math.Round(hsv.S * 1000),
                        v = Math.Round(hsv.V * 1000)
                    })
                });

            return base._rumahTuya.SendCommands(deviceId, commands);
        }

        public Task<CommandResponse> SetColor(System.Drawing.Color color)
        {
            Hsv hsv = new Hsb()
            {
                H = color.GetHue(),
                S = color.GetSaturation(),
                B = color.GetBrightness()
            }.To<Hsv>();

            Commands commands = new Commands(new List<Command>()
                {
                    new Command("work_mode", "colour"),
                    new Command("colour_data_v2", new {
                        h = Math.Round(hsv.H),
                        s = Math.Round(hsv.S * 1000),
                        v = Math.Round(hsv.V * 1000)
                    })
                });

            return base._rumahTuya.SendCommands(deviceId, commands);
        }
    }
}
