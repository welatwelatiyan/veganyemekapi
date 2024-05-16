namespace VY.Business.Layer.Auth.Static.Auth
{
    public static class MailVerify
    {
        public static Dictionary<string, Dictionary<Guid,DateTime >> authGuid =
            new Dictionary<string, Dictionary<Guid, DateTime>>();
        public static Guid addVerify(string mail)
        {
            bool mailVerifyIsExits = authGuid.ContainsKey(mail);
            if (mailVerifyIsExits) 
                removeVerify(mail);
            Guid id = Guid.NewGuid();
            authGuid.Add(mail, new Dictionary<Guid, DateTime>
            {
                { id,DateTime.Now} 
            });
            return id;

        }
        public static void removeVerify(string mail)
        {
            authGuid.Remove(mail);  
        }
        public static Guid? getVerify(string mail)
        {
            try
            {
                return authGuid[mail].First().Key;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static bool isExitsVerify(string mail,Guid id)
        {
            Dictionary<Guid, DateTime> value;
            bool keyIsExits = authGuid.TryGetValue(mail, out value);
            if (!keyIsExits)
                return false;

            if(id.Equals(value.FirstOrDefault().Key))
            {
                removeVerify(mail);
                return true;
            }
            return false;       
            
        }

        public static void removeRangeVerify(DateTime dateTime)
        {

            Dictionary<string, Dictionary<Guid, DateTime>> deleteDict = authGuid;

            authGuid.Keys.ToList().ForEach(key =>
            {
                if (authGuid[key].First().Value <=dateTime)
                    authGuid.Remove(key);
            });

        }
        public static bool getVerifyByid(Guid guid,out string mail)
        {
            

            try
            {
                KeyValuePair<string, Dictionary<Guid, DateTime>> keyvalue =
                      authGuid.FirstOrDefault(x => x.Value.First().Key == guid);
                if(keyvalue.
                    Equals(default(KeyValuePair<string, Dictionary<Guid, DateTime>>)))
                {
                    mail=string.Empty;
                    return false;
                }
                mail = keyvalue.Key;
                return true;
            }
            catch (Exception e)
            {

                mail = string.Empty;
                return false;
            }
        }
    }
}
 