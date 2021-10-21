using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    //Bir kişinin claimlerini ararken .NET bizi biraz uğraştırıyor.
    //ClaimsPrincipal: Bir kişinin o anki jwt içindeki claimlerine erişmek için .NET te olan bir class'tır.
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
//ClaimsPrincipal: using System.Security.Claims;