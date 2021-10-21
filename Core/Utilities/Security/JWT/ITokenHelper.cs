using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT
{
    //İlgili kullanıcı için, KULLANICININ CLAİMLERİNİ İÇEREN BİR TOKEN OLUŞTURUR.
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
