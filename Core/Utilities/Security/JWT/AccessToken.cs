using System;

namespace Core.Utilities.Security.JWT
{
    //AccessToken anlamsız karekterlerden oluşan bir anahtar değeridir.
    //Token: JWT nin ta kendisi yani değeri
    //Expiration: bitiş zamanı
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
