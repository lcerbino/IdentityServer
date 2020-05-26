using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cliente
{
    public static class Token
    {
        public static async Task<TokenResponse> GetTokenResponseAsync()
        {

            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            if (disco.IsError)
            {
                throw new Exception("error");

            }
            var tokenCliente = new TokenClient(disco.TokenEndpoint, "Cliente1", "secreto");
            var tokenResponse = await tokenCliente.RequestClientCredentialsAsync("resourceApi1");

            if (tokenResponse.IsError)
            {
                throw new Exception("error");
            }

            return tokenResponse;

            //var tokenJson = TokenResponse.Json;
        }

    }
}
