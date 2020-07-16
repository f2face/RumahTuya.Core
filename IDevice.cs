using RumahTuya.Response;
using System.Threading.Tasks;

namespace RumahTuya
{
    public interface IDevice
    {
        Task<CommandResponse> PowerOn();
        Task<CommandResponse> PowerOff();
    }
}
