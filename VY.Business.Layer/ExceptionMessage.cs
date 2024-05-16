namespace VY.Business.Layer
{
    public static class ExceptionMessage
    {
        public static Dictionary<int, string> dublicateMail = new Dictionary<int, string>
       {
           {1,"this mail was used" },
           {2,"bu mail daha önce kullanılmış" }
       };
        public static Dictionary<int, string> systemException = new Dictionary<int, string>
        {
            {1,"unfounded error" },
           {2,"sistemde bilinmeyen bir hata oluştu" }
        };
        public static Dictionary<int, string> AccountNotFoundException = new Dictionary<int, string>()
        {
            {1,"this account couldnt  found" },
            {2,"bu hesap  bulunamadı" }
        };
        public static Dictionary<int, string> SuccessRegister= new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Kayıt işleminiz başarılı bir şekilde gerçekleşmiştir." +
                "Mail adresinize gönderdiğimiz doğrulama maili ile kaydınızı tamamlayabilirsiniz. " +
                "Eğer doğrulama mailinizi görüntüleyemiyorsanız lütfen spam kutusuna bakınız. " }
        };
        public static Dictionary<int, string> ErrorRegister = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Kayıt işleminiz tamamlanamadı."  }
        };
        public static Dictionary<int, string> NotFoundVerify = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Doğrulama isteği tamamlanamadı.Lütfen yeni doğrulama isteyiniz veya bizimle iletişime geçiniz"  }
        };
        public static Dictionary<int, string> SuccessVerify = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Doğrulama isteği başarılı bir şekilde gerçekleştirildi."  }
        };
        public static Dictionary<int, string> SendPassUppdateMail = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Mail adresinize şifrenizi güncelleyebileceğiniz bir lik gönderilmiştir"  }
        };
        public static Dictionary<int, string> VerifyExpired = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Göndermiş olduğumuz linkin süre dolmuştur"  }
        };
        public static Dictionary<int, string> StoreNotFound = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Bu hesaba ait bir işyeri bulunamamıdı"  }
        };
        public static Dictionary<int, string> StoreDublicated = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Bu hesaba ait bir işletme  bulunmaktadır"  }
        };
        public static Dictionary<int, string> StoreInfoNotSaved= new Dictionary<int, string>()
        {
            {1,"" },
            {2,"işletme bilgileriniz kayıt edilemedi"  }
        };
        public static Dictionary<int, string> StoreSaved = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"işletme bilgileriniz başarılı bir şekilde kayıt edildi." +
                "İşletmenizi aktive edilmesi için lütfen bizimle iletişime geçiniz"  }
        };
        public static Dictionary<int, string> StoreUpdated = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"işletme bilgileriniz başarılı bir şekilde güncellendi"  }
        };
        public static Dictionary<int, string> StoreInfoNotUpdated = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"işletme bilgileriniz güncellenemedi lütfen bizimle iletişime geçiniz"  }
        };
        public static Dictionary<int, string> AddresNotFound = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Herhangi Bir Adres Bilgisine ulaşılamadı"  }
        };
        public static Dictionary<int, string> AddresNotAdded = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Adress bilgisi kayıt edilemedi"  }
        };
        public static Dictionary<int, string> StoreAdressDublicate = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Birden Fazla Adress Kaydı yapılamaz"  }
        };
        public static Dictionary<int, string> StoreAdressNotFoundForUser= new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Girdiğiniz Adress için hizmet veren bir adres bulamadık"  }
        };
        public static Dictionary<int, string> userStoreAdressNotSaved = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Girdiğiniz Adress için hizmet veren bir adres bulamadık"  }
        };
        public static Dictionary<int, string> productIsNotAdded = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Ürün bilgisi kayıt edilemedi"  }
        };
        public static Dictionary<int, string> productIsNotFound= new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Ürün bilgisi bulunamadı"  }
        };
        public static Dictionary<int, string> menuIsNotAdded = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Menü bilgisi kayıt edilemedi"  }
        };
        public static Dictionary<int, string> menuIsNotFounded = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Menü bilgisi bulunamadı"  }
        };
        public static Dictionary<int, string> dataIsNotFounded = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Veri  bulunamadı"  }
        };
        public static Dictionary<int, string> dataIsNotSaved = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"Veri  kayıt edilemedi"  }
        };

    }

    public enum language
    {
        English = 1,
        Turkish= 2,
        Kurdish = 3

    }
}
