using Refit;
using RumahTuya.Exceptions;
using RumahTuya.Request;
using RumahTuya.Response;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RumahTuya
{
    public class RumahTuya
    {
        protected string baseUrl = "https://openapi.tuyaus.com";
        protected string signMethod = "HMAC-SHA256";
        protected string userAgent = "RumahTuya-dotNET/0.2.0";
        protected string language = "en";

        private readonly string clientId;
        private readonly string clientSecret;
        private readonly ITuyaCloudAPI api;

        private Credentials credentials;

        private HttpClient HttpClient
        {
            get
            {
                HttpClient httpClient = new HttpClient
                {
                    BaseAddress = new Uri(baseUrl)
                };

                httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
                httpClient.DefaultRequestHeaders.Add("client_id", clientId);
                httpClient.DefaultRequestHeaders.Add("sign_method", signMethod);
                httpClient.DefaultRequestHeaders.Add("lang", language);

                httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
                httpClient.DefaultRequestHeaders.Add("Keep-Alive", "timeout=600");

                return httpClient;
            }
        }

        public RumahTuya(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            api = RestService.For<ITuyaCloudAPI>(HttpClient);
        }

        public async Task<Credentials> Authorize()
        {
            RequestSignature sig = GenerateRequestSignature();
            Response.ApiResponse<Credentials> response = await api.GetAccessToken(
                sig.Signature,
                sig.Timestamp)
                .ConfigureAwait(false);

            if (!response.IsSuccess)
            {
                throw new ResponseException(response.ResponseMessage, response.ResponseCode);
            }

            credentials = response.Result;
            credentials.Timestamp = response.Timestamp;

            return credentials;
        }

        public async Task<Credentials> Reauthorize()
        {
            if (credentials == null || credentials?.RefreshToken.Length == 0)
            {
                return await Authorize().ConfigureAwait(false);
            }

            RequestSignature sig = GenerateRequestSignature();
            Response.ApiResponse<Credentials> response = await api.RefreshAccessToken(
                credentials.RefreshToken,
                sig.Signature,
                sig.Timestamp)
                .ConfigureAwait(false);

            if (!response.IsSuccess)
            {
                throw new ResponseException(response.ResponseMessage, response.ResponseCode);
            }

            credentials = response.Result;
            credentials.Timestamp = response.Timestamp;

            return credentials;
        }

        public async Task<DeviceInfo> GetDeviceInfo(string deviceId)
        {
            if (credentials == null || credentials?.AccessToken.Length == 0)
            {
                throw new UnauthorizedException("Unauthorized");
            }

            RequestSignature sig = GenerateRequestSignature(credentials.AccessToken);
            Response.ApiResponse<DeviceInfo> response = await api.GetDeviceInfo(
                sig.Signature,
                sig.Timestamp,
                credentials.AccessToken,
                deviceId)
                .ConfigureAwait(false);

            if (!response.IsSuccess)
            {
                throw new ResponseException(response.ResponseMessage, response.ResponseCode);
            }

            return response.Result;
        }

        public async Task<Attributes> GetDeviceStatus(string deviceId)
        {
            if (credentials == null || credentials?.AccessToken.Length == 0)
            {
                throw new UnauthorizedException("Unauthorized");
            }

            RequestSignature sig = GenerateRequestSignature(credentials.AccessToken);
            Response.ApiResponse<Attributes> response = await api.GetDeviceStatus(
                sig.Signature,
                sig.Timestamp,
                credentials.AccessToken,
                deviceId)
                .ConfigureAwait(false);

            if (!response.IsSuccess)
            {
                throw new ResponseException(response.ResponseMessage, response.ResponseCode);
            }

            return response.Result;
        }

        public async Task<DeviceSpecs> GetDeviceSpecifications(string deviceId)
        {
            if (credentials == null || credentials?.AccessToken.Length == 0)
            {
                throw new UnauthorizedException("Unauthorized");
            }

            RequestSignature sig = GenerateRequestSignature(credentials.AccessToken);
            Response.ApiResponse<DeviceSpecs> response = await api.GetDeviceSpecifications(
                sig.Signature,
                sig.Timestamp,
                credentials.AccessToken,
                deviceId)
                .ConfigureAwait(false);

            if (!response.IsSuccess)
            {
                throw new ResponseException(response.ResponseMessage, response.ResponseCode);
            }

            return response.Result;
        }

        public async Task<DeviceFunctions> GetDeviceFunctions(string deviceId)
        {
            if (credentials == null || credentials?.AccessToken.Length == 0)
            {
                throw new UnauthorizedException("Unauthorized");
            }

            RequestSignature sig = GenerateRequestSignature(credentials.AccessToken);
            Response.ApiResponse<DeviceFunctions> response = await api.GetDeviceFunctions(
                sig.Signature,
                sig.Timestamp,
                credentials.AccessToken,
                deviceId)
                .ConfigureAwait(false);

            if (!response.IsSuccess)
            {
                throw new ResponseException(response.ResponseMessage, response.ResponseCode);
            }

            return response.Result;
        }

        public async Task<CommandResponse> SendCommands(string deviceId, Commands commands)
        {
            if (credentials == null || credentials?.AccessToken.Length == 0)
            {
                throw new UnauthorizedException("Unauthorized");
            }

            RequestSignature sig = GenerateRequestSignature(credentials.AccessToken);
            CommandResponse response = await api.SendCommands(
                sig.Signature,
                sig.Timestamp,
                credentials.AccessToken,
                deviceId,
                commands)
                .ConfigureAwait(false);

            if (!response.IsSuccess)
            {
                throw new ResponseException(response.ResponseMessage, response.ResponseCode);
            }

            return response;
        }

        protected RequestSignature GenerateRequestSignature()
        {
            return GenerateRequestSignature(null);
        }

        protected RequestSignature GenerateRequestSignature(string accessToken)
        {
            long timestamp = GetTimestamp();
            string str = clientId + (accessToken ?? "") + timestamp.ToString();
            using (HMACSHA256 key = new HMACSHA256(StringEncode(clientSecret)))
            {
                byte[] hashByte = key.ComputeHash(StringEncode(str));
                string signature = BitConverter.ToString(hashByte).Replace("-", "").ToUpper();
                return new RequestSignature(signature, timestamp);
            }
        }

        private byte[] StringEncode(string text)
        {
            return Encoding.ASCII.GetBytes(text);
        }

        private long GetTimestamp()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0))).TotalMilliseconds;
        }
    }
}
