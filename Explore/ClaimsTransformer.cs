using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Explore
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)principal.Identity;
            // flatten resource_access because Microsoft identity model doesn't support nested claims
            // by map it to Microsoft identity model, because automatic JWT bearer token mapping already processed here
           // if (claimsIdentity.IsAuthenticated && claimsIdentity.HasClaim((claim) => claim.Type == "realm_access"))
            {
                var email = claimsIdentity.FindFirst((claim)=> claim.Type == "hehe");
                var cntent = email.Value;
               // var userRole = claimsIdentity.FindFirst((claim) => claim.Type == "realm_access");
                //var content = Newtonsoft.Json.JObject.Parse(email.ToString());
                //foreach (var role in content["roles"])
                //{
                 claimsIdentity.AddClaim(new Claim(ClaimTypes.Role,cntent));
                //}
            }
            return Task.FromResult(principal);
        }

    }
}
