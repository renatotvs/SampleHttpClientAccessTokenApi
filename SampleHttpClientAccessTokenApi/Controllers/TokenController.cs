using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleHttpClientAccessTokenApi.Models;
using SampleHttpClientAccessTokenApi.Clients;

namespace SampleHttpClientAccessTokenApi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private ITokenClient _token;
        public TokenController(ITokenClient token)
        {
            _token = token;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var resultToken = await _token.GetToken();

            return Ok(resultToken);
        }

    }
}