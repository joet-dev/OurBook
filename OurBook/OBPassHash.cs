using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OurBook
{
    public class OBPassHash : PassHashInterface
    {
        public OBPassHash()
        {
            HashIter = 10000;
            //Upto 32;
            SaltSize = 24;
        }

        public int HashIter
        { get; set; }

        public int SaltSize
        { get; set; }

        public string PlainText
        { get; set; }

        public string HashedText
        { get; private set; }

        public string Salt
        { get; set; }

        public string Compute()
        {
            if (string.IsNullOrEmpty(PlainText)) throw new InvalidOperationException("PlainText cannot be empty");

            //if there is no salt, generate one
            if (string.IsNullOrEmpty(Salt))
                GenerateSalt();

            HashedText = calculateHash(HashIter);

            return HashedText;
        }

        public string Compute(string textToHash)
        {
            PlainText = textToHash;

            Compute();
            return HashedText;
        }

        public string Compute(string textToHash, int saltSize, int hashIter)
        {
            PlainText = textToHash;
            GenerateSalt(hashIter, saltSize);
            Compute();
            return HashedText;
        }

        public string Compute(string textToHash, string salt)
        {
            PlainText = textToHash;
            Salt = salt;
            //expand the salt
            expandSalt();
            Compute();
            return HashedText;
        }

        public string GenerateSalt()
        {
            if (SaltSize < 1) throw new InvalidOperationException(string.Format("Cannot generate a salt of size {0}, use a value greater than 1, recommended: 16", SaltSize));

            var rand = RandomNumberGenerator.Create();

            var ret = new byte[SaltSize];

            rand.GetBytes(ret);

            //assign the generated salt in the format of {iterations}.{salt}
            Salt = string.Format("{0}.{1}", HashIter, Convert.ToBase64String(ret));

            return Salt;
        }

        public string GenerateSalt(int hashIterations, int saltSize)
        {
            HashIter = hashIterations;
            SaltSize = saltSize;
            return GenerateSalt();
        }

        public int GetElapsedTimeForIteration(int iteration)
        {
            var sw = new Stopwatch();
            sw.Start();
            calculateHash(iteration);
            return (int)sw.ElapsedMilliseconds;
        }


        private string calculateHash(int iteration)
        {
            //convert the salt into a byte array
            byte[] saltBytes = Encoding.UTF8.GetBytes(Salt);

            var pbkdf2 = new Rfc2898DeriveBytes(PlainText, saltBytes, iteration);
            var key = pbkdf2.GetBytes(64);
            return Convert.ToBase64String(key);
        }

        private void expandSalt()
        {
            try
            {
                //get the position of the . that splits the string
                var i = Salt.IndexOf('.');

                //Get the hash iteration from the first index
                HashIter = int.Parse(Salt.Substring(0, i), System.Globalization.NumberStyles.Number);

            }
            catch (Exception)
            {
                throw new FormatException("The salt was not in an expected format of {int}.{string}");
            }
        }

        public bool Compare(string passwordHash1, string passwordHash2)
        {
            if (passwordHash1 == null || passwordHash2 == null)
                return false;

            int min_length = Math.Min(passwordHash1.Length, passwordHash2.Length);
            int result = 0;

            for (int i = 0; i < min_length; i++)
                result |= passwordHash1[i] ^ passwordHash2[i];

            return 0 == result;
        }
    }
}

