using System.Buffers.Text;

namespace VY.Business.Layer.Auth.DTO
{
    public class LoginDTO
    {
        public string mailadress { get; set; }
        public string password { get; set; }
    }
}
