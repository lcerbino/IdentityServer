using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public static class Config
    {

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Cliente1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret ("secreto".Sha256())
                    },

                    AllowedScopes = { "resourceApi1"}
                },
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {

            return new List<ApiResource>
            {

                new ApiResource ("resourceApi1", "Mi recurso")

            };

        }
    }
}
