﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HachingHelper
    {
        public static void CreatePasswordHacsh(string password, out byte[] passwordHash, out byte[] passwordSalt)//verilan passwordun hashini oluşturuyor
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//stringin byte karşılığını almak için 

            }
        }
        public static bool VerifyPasswordHach(string password,  byte[] passwordHash,  byte[] passwordSalt) // sisteme tekrardan girdiği şifre ile doğrulama yapılacak
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
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
