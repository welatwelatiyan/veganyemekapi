using System.Linq;

namespace VY.Business.Layer.Auth.Static.Auth
{
    public static class AccountVerify
    {
        public static Dictionary<Guid, DateTime> verifyGuid { get; } = new Dictionary<Guid, DateTime>();       

        public static bool isVerifyExitst(Guid guid)
        {
            bool keyisexits = verifyGuid.ContainsKey(guid);
            if (keyisexits)
                removeVerify(guid);
            return keyisexits;
        }
        public  static Guid addVerify()
        {        
            Guid guid = Guid.NewGuid();
            verifyGuid.Add(guid,DateTime.Now);
            return guid;
        }
        public static void removeVerify(Guid guid)
        {
            verifyGuid.Remove(guid);
        }
        public static void removeRangeVerify(DateTime dateTime)
        {
            Dictionary<Guid, DateTime> keyValuePairs =
                   (Dictionary<Guid, DateTime>)verifyGuid.Where(x => x.Value <= dateTime);
            foreach (var item in keyValuePairs)
            {
                verifyGuid.Remove(item.Key);
            }
        }
    }
}
