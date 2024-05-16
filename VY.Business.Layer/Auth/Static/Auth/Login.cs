using System.Security.Cryptography;

namespace VY.Business.Layer.Auth.Static.Auth
{
    public static class Login
    {
        private static List<loginModel> loginList = new List<loginModel>();

        private static void createNewKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
        }
         
    }
    class loginModel
    {
        public string mail { get; set;}
        public string publickey { get; set; }
        public DateTime lastlogin  { get; set; }
        public DateTime lastActivity { get; set; }

    }

}
