using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Refit;
using RumahTuya.Request;
using RumahTuya.Response;
using System.Net.Http;

namespace RumahTuya
{
    public class RumahTuya
    {
        protected string baseUrl = "https://openapi.tuyaus.com";
        protected string signMethod = "HMAC-SHA256";
        protected string userAgent = "RumahTuya-dotNET/0.1.0";
        protected string language = "en";

        private readonly string clientId;
        private readonly string clientSecret;
        private readonly IRequest api;

        private Credentials credentials;

        private HttpClient HttpClient()
        {
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri(this.baseUrl)
            };

            httpClient.DefaultRequestHeaders.Add("User-Agent", this.userAgent);
            httpClient.DefaultRequestHeaders.Add("client_id", this.clientId);
            httpClient.DefaultRequestHeaders.Add("sign_method", this.signMethod);
            httpClient.DefaultRequestHeaders.Add("lang", this.language);

            httpClient.DefaultRequestHeaders.Add("Connection", "Keep-Alive");
            httpClient.DefaultRequestHeaders.Add("Keep-Alive", "timeout=600");

            return httpClient;
        }

        public RumahTuya(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.api = RestService.For<IRequest>(this.HttpClient());
        }

        public Task<Response.ApiResponse<Credentials>> Authorize()
        {
            RequestSignature sig = this.GenerateRequestSignature();
            Task<Response.ApiResponse<Credentials>> task = this.api.GetAccessToken(
                sig.Signature,
                sig.Timestamp);
            task.ContinueWith(action =>
            {
                Response.ApiResponse<Credentials> response = action.Result;
                if (response.success)
                {
                    credentials = response.result;
                    credentials.timestamp = response.t;
                }
            });

            return task;
        }

        public Task<Response.ApiResponse<Credentials>> Reauthorize()
        {
            if (this.credentials == null || this.credentials?.refresh_token.Length == 0)
            {
                return this.Authorize();
            }

            RequestSignature sig = this.GenerateRequestSignature();
            Task<Response.ApiResponse<Credentials>> task = this.api.RefreshAccessToken(
                this.credentials.refresh_token,
                sig.Signature,
                sig.Timestamp);
            task.ContinueWith(action =>
            {
                Response.ApiResponse<Credentials> response = action.Result;
                if (response.success)
                {
                    credentials = response.result;
                    credentials.timestamp = response.t;
                }
            });

            return task;
        }

        public Task<string> GetDeviceInfo(string deviceId)
        {
            if (this.credentials == null || this.credentials?.access_token.Length == 0)
            {
                throw new Exceptions.UnauthorizedException("Unauthorized");
            }

            RequestSignature sig = this.GenerateRequestSignature(this.credentials.access_token);
            Task<string> task = this.api.GetDeviceInfo(
                sig.Signature,
                sig.Timestamp,
                this.credentials.access_token,
                deviceId);
            return task;
        }
        
        public Task<string> GetDeviceStatus(string deviceId)
        {
            if (this.credentials == null || this.credentials?.access_token.Length == 0)
            {
                throw new Exceptions.UnauthorizedException("Unauthorized");
            }

            RequestSignature sig = this.GenerateRequestSignature(this.credentials.access_token);
            Task<string> task = this.api.GetDeviceStatus(
                sig.Signature,
                sig.Timestamp,
                this.credentials.access_token,
                deviceId);
            return task;
        }
        
        public Task<string> GetDeviceSpecifications(string deviceId)
        {
            if (this.credentials == null || this.credentials?.access_token.Length == 0)
            {
                throw new Exceptions.UnauthorizedException("Unauthorized");
            }

            RequestSignature sig = this.GenerateRequestSignature(this.credentials.access_token);
            Task<string> task = this.api.GetDeviceSpecifications(
                sig.Signature,
                sig.Timestamp,
                this.credentials.access_token,
                deviceId);
            return task;
        }
        
        public Task<string> GetDeviceFunctions(string deviceId)
        {
            if (this.credentials == null || this.credentials?.access_token.Length == 0)
            {
                throw new Exceptions.UnauthorizedException("Unauthorized");
            }

            RequestSignature sig = this.GenerateRequestSignature(this.credentials.access_token);
            Task<string> task = this.api.GetDeviceFunctions(
                sig.Signature,
                sig.Timestamp,
                this.credentials.access_token,
                deviceId);
            return task;
        }

        public Task<CommandResponse> SendCommands(string deviceId, Commands commands)
        {
            if (this.credentials == null || this.credentials?.access_token.Length == 0)
            {
                throw new Exceptions.UnauthorizedException("Unauthorized");
            }

            RequestSignature sig = this.GenerateRequestSignature(this.credentials.access_token);
            Task<CommandResponse> task = this.api.SendCommands(
                sig.Signature,
                sig.Timestamp,
                this.credentials.access_token,
                deviceId,
                commands);
            return task;
        }

        protected RequestSignature GenerateRequestSignature()
        {
            return this.GenerateRequestSignature(null);
        }

        protected RequestSignature GenerateRequestSignature(string accessToken)
        {
            long timestamp = this.GetTimestamp();
            string str = this.clientId + (accessToken ?? "") + timestamp.ToString();
            using (HMACSHA256 key = new HMACSHA256(this.StringEncode(this.clientSecret)))
            {
                byte[] hashByte = key.ComputeHash(this.StringEncode(str));
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
