namespace VY.Business.Layer.Auth.Abstarct
{
    public interface IMailService
    {
        Task sendMail(string mail, string content, string title);
    }
}
