﻿using System.Text;

namespace VY.Core.Layer.Utilities.Security
{
    public static  class HashingHelper
    {
        public static void CreateHash(string password,
                                      out byte[] passwordHash,
                                      out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

        }
        public static bool VerifityPasswordHash(string password,
                                                byte[] passwordHash,
                                                byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(buffer: Encoding.
                                                    UTF8.GetBytes(password));
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

