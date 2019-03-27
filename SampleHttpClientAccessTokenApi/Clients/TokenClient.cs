using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SampleHttpClientAccessTokenApi.Models;
using SampleHttpClientAccessTokenApi.Config;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Options;

namespace SampleHttpClientAccessTokenApi.Clients
{
    public class TokenClient : ITokenClient
    {
        private HttpClient _client;
        private EndpointSettings _settings;

        public TokenClient(HttpClient client, IOptions<EndpointSettings> settings)
        {
            _client = client;
            _settings = settings.Value;
        }

        public async Task<AccessToken> GetToken()
        {
            var url = _settings.UrlCredentials;

            string credentials = String.Format("{0}:{1}", _settings.ClientId, _settings.ClientSecret);

            //Define Headers
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials)));

            //Prepare Request Body
            List<KeyValuePair<string, string>> requestData = new List<KeyValuePair<string, string>>();
            requestData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));

            FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);

            //Request Token
            var resultToken = await _client.PostAsync(url, requestBody);
            var content = await resultToken.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AccessToken>(content);
        }
    }
}
