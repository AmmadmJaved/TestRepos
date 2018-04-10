using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebSecurity.Identity
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                  new ApiResource("api1", "My API")
             };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
                   {
                     new IdentityServer4.Models.IdentityResources.OpenId(),
                     new IdentityResources.Profile(),
                     new IdentityResources.Email()
                 };
        }



        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
                          {
        new TestUser
        {
            SubjectId = "1",
            Username = "ammad@gmail.com",
            Password = "Qwerty@123",
            Claims = new []
            {
                new Claim("name", "Ammad"),
                new Claim("website", "https://Ammad.com")
            }
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "bob",
            Password = "password"
        }
                     };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
                        {
        new Client
        {
            ClientId = "ro.client",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },
            AccessTokenType = AccessTokenType.Jwt,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AccessTokenLifetime = 3600 * 24 * 7, // 1 week
                    IdentityTokenLifetime = 3600 * 24 * 7, // 1 week
                    AlwaysSendClientClaims = true,
                    Enabled = true,
            AllowedScopes = { "api1" }
        }
                           };
        }


    }
}
