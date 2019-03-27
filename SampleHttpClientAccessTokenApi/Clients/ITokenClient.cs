using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleHttpClientAccessTokenApi.Models;

namespace SampleHttpClientAccessTokenApi.Clients
{
    public interface ITokenClient
    {
        Task<AccessToken> GetToken();
    }
}
