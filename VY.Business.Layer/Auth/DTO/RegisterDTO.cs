using VY.Core.Layer.Entity;

namespace VY.Business.Layer.Auth.DTO
{
    public class RegisterDTO:IDTO
    {
        public string mailadress { get; set; }
        public string password { get; set; }
    }
}
