using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;
using System.Security.Cryptography;
using VY.Business.Layer.Auth.Abstarct;
using VY.Business.Layer.Auth.DTO;
using VY.Business.Layer.Auth.Static.Auth;
using VY.Core.Layer.Utilities.Results.DataResult;
using VY.Core.Layer.Utilities.Results.Result;
using VY.Core.Layer.Utilities.Security;
using VY.Core.Layer.Utilities.Security.JWT;
using VY.DataAccess.Layer.Auth.Abstract;
using VY.Entity.Layer.Table.authTable;
using VY.Entity.Layer.Table.StoreTable;

namespace VY.Business.Layer.Auth.Concreate
{
    public class AuthService : IAuthService
    {
        private IAuthMAnager authMAnager;
        private ITokenHelper tokenHelper;
        private IMailService mailService;
        private IConfiguration configuration;
        private IStoreManager storeManager;
        public AuthService(IAuthMAnager authMAnager, 
                           ITokenHelper tokenHelper, 
                           IMailService mailService,
                           IConfiguration configuration,
                           IStoreManager storeManager)
        {
            this.authMAnager = authMAnager;
            this.tokenHelper = tokenHelper;
            this.mailService = mailService;
            this.configuration = configuration;
            this.storeManager = storeManager;
        }

        public IResult getPasswordUpdateLink(string email)
        {
            try
            {
                var users = authMAnager.
                     getByFilterOrAll(x => x.
                     emailAdress.
                     Equals(email) && x.IsActive).
                     ToList();
                if (users.Count == 0)
                    return new ErrorDataResult<AccessToken>(null, "0", 
                        ExceptionMessage.AccountNotFoundException[(int)language.Turkish]);

                SendPasUpdateVerifyMail(email);
                return new SuccesResult("1", ExceptionMessage.SendPassUppdateMail[(int)language.Turkish]);
            }
            catch (Exception e) 
            {

                throw;
            }
        }

        public IDataResult<AccessToken> Login(LoginDTO login)
        {
            try
            {
                List<VyUserTable> users = new List<VyUserTable>();
                List<VyStoreTable> stores = new List<VyStoreTable>();

                users = authMAnager.
                    getByFilterOrAll(x => x.
                    emailAdress.
                    Equals(login.mailadress) && x.IsActive).
                    ToList();

                if (users.Count == 0)
                    return new ErrorDataResult<AccessToken>(null, "0", 
                        ExceptionMessage.AccountNotFoundException[(int)language.English]);
                VyUserTable user = users[0];
                
                bool passVerify = HashingHelper.VerifityPasswordHash(login.password, 
                                                                     user.PasswordHash, 
                                                                     user.PasswordSalt);
                if (passVerify && users[0].IsSeller)
                    stores = storeManager.
                        getByFilterOrAll(t => t.
                        userId.Equals(users[0].Id)).
                        ToList();

                List<Claim> claims = passVerify ? user.IsSeller ? new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, "seller"),
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim(ClaimTypes.Email,users[0].emailAdress),
                    new Claim(ClaimTypes.NameIdentifier,users[0].Id.ToString()),
                    new Claim(ClaimTypes.UserData,stores[0].Id.ToString())

                } :
                new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, "user"),
                    new Claim(ClaimTypes.Email,users[0].emailAdress),
                    new Claim(ClaimTypes.NameIdentifier,users[0].Id.ToString())

                } : new List<Claim>();
               
                
                return claims.Count==0 ?
                    new ErrorDataResult<AccessToken>(null, "0", 
                    ExceptionMessage.AccountNotFoundException[(int)language.English]) :
                    new SuccessDataResult<AccessToken>(tokenHelper.CreateToken(claims),"1");

            }
            catch (Exception e)
            {

                return
                    new ErrorDataResult<AccessToken>(null, "0",
                    ExceptionMessage.systemException[(int)language.English]);
            }
        }

        public IResult passwordUpdate(string password,Guid verifyId)
        {
            try
            {
                string mail;
                bool isexitsVerify = MailVerify.getVerifyByid(verifyId, out mail);

                var users = authMAnager.
                    getByFilterOrAll(x => x.
                    emailAdress.
                    Equals(mail) && x.IsActive).
                    ToList();
                if (users.Count == 0)
                    return new ErrorDataResult<AccessToken>(null, "0",
                        ExceptionMessage.AccountNotFoundException[(int)language.Turkish]);

                VyUserTable user = users[0];

               
                bool updateIsSuccess = false;

                if (!isexitsVerify)
                    return new ErrorDataResult<AccessToken>(null, "0",
                        ExceptionMessage.VerifyExpired[(int)language.Turkish]);

                byte[] ph, ps;
                HashingHelper.CreateHash(password, out ph, out ps);

                user.UpdateTime = DateTime.UtcNow;
                user.PasswordHash = ph; 
                user.PasswordSalt = ps;

                updateIsSuccess = authMAnager.update(user);

                return updateIsSuccess ? new SuccesResult() : new ErrorResult();
            }
            catch (Exception e)
            {

                throw;
            }




        }

        public IResult Register(RegisterDTO register)
        {
            try
            {
                var users = authMAnager.getByFilterOrAll(x => x.emailAdress.Equals(register.mailadress));
                List<VyUserTable> vyUserTables = users.ToList();
                if (vyUserTables.Count > 0)
                    return new ErrorResult("0", ExceptionMessage.dublicateMail[(int)language.Turkish]);
                byte[] ph, ps;
                HashingHelper.CreateHash(register.password, out ph, out ps);

                bool isAdded = authMAnager.add(new VyUserTable
                {
                    PasswordHash = ph,
                    PasswordSalt = ps,
                    IsSeller = false,
                    IsActive = false,
                    emailAdress = register.mailadress
                });
                if (isAdded)
                    SendVerifyMail(register.mailadress);


                return isAdded ?
                new SuccesResult("1", ExceptionMessage.SuccessRegister[(int)language.Turkish]) :
                new ErrorResult("0", ExceptionMessage.ErrorRegister[(int)language.Turkish]);
            }
            catch (Exception e)
            {
               return new ErrorResult("0", ExceptionMessage.systemException[(int)language.Turkish]);
            }
        }
        public async Task<IResult> sendVerify(string email)
        {
            var users = authMAnager.getByFilterOrAll(x => x.emailAdress.Equals(email));
            List<VyUserTable> vyUserTables = users.ToList();
            if (vyUserTables.Count == 0)
                return new ErrorResult("0", ExceptionMessage.AccountNotFoundException[(int)language.Turkish]);
            SendVerifyMail(email);
            return new SuccesResult("1", ExceptionMessage.SuccessRegister[(int)language.Turkish]);

        }
        public IResult verifyEmail(Guid id)
        {
            string mail;
            bool isexitsVerify = MailVerify.getVerifyByid(id, out mail);
            if (!isexitsVerify)
                return new ErrorResult(ExceptionMessage.NotFoundVerify[(int)language.Turkish]);
            var que = authMAnager.getByFilterOrAll(x => x.emailAdress.Equals(mail));
            List<VyUserTable> user = que.ToList();
            if (user.Count == 0)
                return new ErrorResult(ExceptionMessage.AccountNotFoundException[(int)language.Turkish]);

            MailVerify.removeVerify(mail);
            user[0].IsActive = true;
            user[0].UpdateTime = DateTime.UtcNow;

            return authMAnager.update(user[0]) ?
                new SuccesResult(ExceptionMessage.SuccessVerify[(int)language.Turkish]):
                new ErrorResult(ExceptionMessage.NotFoundVerify[(int)language.Turkish]);

        }
        private async Task SendVerifyMail(string mail)
        {
            Guid verify = MailVerify.addVerify(mail);

            string mailhtmlbody = $@"<body>
                                    <center><img src=""https://bisuperis.com/img/logo.png"" height=""50px""></center>
                                    <hr>
                                    <center><h2>VEGAN FODDİE YE HOŞ GELDİN DÜNYALI</h2></center>
                                    <p>Merhaba değerli kullanıcımız </p>                                   
                                    <br>
                                    <p>aşağıda göndermiş bulunduğumuz linkten mail adresinizi doğrulayabilirsiniz</p>
                                    <br>
                                    <p>Bu link sadece 6 saat aktif olacaktır</p>
                                    <a href=""{configuration.GetSection("MailVerifyInfo:addres").Get<string>() + "/auth/verify/verifyid=" + MailVerify.getVerify(mail)}"" target=""_blank"">aktivasyon linki</a>
                                    <br>
                                    <hr>
                                    <center><a href=""https://www.bisuperis.com"">www.softveg.com</a>-<a href=""mailto:info@bisuperis.com"">info@bisuperis.com</a></center>
                                    
                                    </body>";


            mailService.sendMail(mail, mailhtmlbody, "Verify Account");
        }
        private async Task SendPasUpdateVerifyMail(string mail)
        {
            Guid verify = MailVerify.addVerify(mail);

            string mailhtmlbody = $@"<body>
                                    <p>Merhaba değerli kullanıcımız </p>                                   
                                    <br>
                                    <p>aşağıda göndermiş bulunduğumuz linkten şifrenizi güncelleyebilirsiniz</p>
                                    <br>
                                    <p>Bu link sadece 6 saat aktif olacaktır</p>
                                    <a href=""{configuration.GetSection("MailVerifyInfo:addres").Get<string>() + "/auth/verify/verifyid=" + MailVerify.getVerify(mail)}"" target=""_blank"">aktivasyon linki</a>
                                    <br>
                                    <hr>
                                    <center><a href=""https://www.softveg.com"">www.softveg.com</a>-<a href=""mailto:info@bisuperis.com"">info@bisuperis.com</a></center>
                                    
                                    </body>";


            mailService.sendMail(mail, mailhtmlbody, "Mail Update");
        }


    }
}
