using System.Text;

namespace Core.Utilities.Security.Hashing
{
    //HashingHelper: Hash oluşturmaya ve onu doğrulamaya yarar.
    public class HashingHelper
    {
        public static void CreatePasswordHash(
            string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            //IDispposible patern. using
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;//Salt.Her kullanıcı için başka bir key oluşturur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
