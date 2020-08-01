using Refit;
using RumahTuya.Response;
using System.Threading.Tasks;

namespace RumahTuya.Request
{
    internal interface IRequest
    {
        [Get("/v1.0/token?grant_type=1")]
        Task<Response.ApiResponse<Credentials>> GetAccessToken(
            [Header("sign")] string signature,
            [Header("t")] long timestamp);

        [Get("/v1.0/token/{refresh_token}")]
        Task<Response.ApiResponse<Credentials>> RefreshAccessToken(
            [AliasAs("refresh_token")] string refreshToken,
            [Header("sign")] string signature,
            [Header("t")] long timestamp);

        [Get("/v1.0/devices/{device_id}")]
        Task<Response.ApiResponse<DeviceInfo>> GetDeviceInfo(
            [Header("sign")] string signature,
            [Header("t")] long timestamp,
            [Header("access_token")] string accessToken,
            [AliasAs("device_id")] string deviceId);

        [Get("/v1.0/devices/{device_id}/status")]
        Task<Response.ApiResponse<Attributes>> GetDeviceStatus(
            [Header("sign")] string signature,
            [Header("t")] long timestamp,
            [Header("access_token")] string accessToken,
            [AliasAs("device_id")] string deviceId);

        [Get("/v1.0/devices/{device_id}/specifications")]
        Task<Response.ApiResponse<DeviceSpecs>> GetDeviceSpecifications(
            [Header("sign")] string signature,
            [Header("t")] long timestamp,
            [Header("access_token")] string accessToken,
            [AliasAs("device_id")] string deviceId);

        [Get("/v1.0/devices/{device_id}/functions")]
        Task<Response.ApiResponse<DeviceFunctions>> GetDeviceFunctions(
            [Header("sign")] string signature,
            [Header("t")] long timestamp,
            [Header("access_token")] string accessToken,
            [AliasAs("device_id")] string deviceId);

        [Post("/v1.0/devices/{device_id}/commands")]
        [Headers("Content-Type: application/json")]
        Task<Response.CommandResponse> SendCommands(
            [Header("sign")] string signature,
            [Header("t")] long timestamp,
            [Header("access_token")] string accessToken,
            [AliasAs("device_id")] string deviceId,
            [Body(BodySerializationMethod.Serialized)] Commands commands);
    }
}
