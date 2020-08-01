using RumahTuya.Response;
using System.Threading.Tasks;

namespace RumahTuya.Devices
{
    public interface IHasPowerSwitch
    {
        Task<CommandResponse> PowerOn();
        Task<CommandResponse> PowerOff();
        Task<CommandResponse> SetPowerCountdownTimer(int minutes);
        Task<int> GetCountdownTimer();
    }
}
