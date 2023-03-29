// <author>shawnmclean (github)</author>
// <summary>Simple cryptography library that wraps complex hashing algorithms for quick and simple usage.</summary>
using System;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;

/// <summary>
/// Generates a hash for an input plaintext password. The hash is encrypted with salt for extra protection. 
/// </summary>
public class PassHash : PassHashInterface
{
    /// <summary>
    /// Initializes variables HashIter & SaltSize with default variables.
    /// </summary>
    public PassHash()
    {
        HashIter = 10000;
        //Upto 32;
        SaltSize = 24;
    }

    // Getters and setters.
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

    /// <summary>
    /// Computes the hash from a PassHash object. 
    /// </summary>
    /// <returns> The computed hashed plaintext. </returns>
    public string Compute()
    {
        if (string.IsNullOrEmpty(PlainText)) throw new InvalidOperationException("PlainText cannot be empty");

        // If there is no salt, generate one
        if (string.IsNullOrEmpty(Salt))
            GenerateSalt();

        HashedText = calculateHash(HashIter);

        return HashedText;
    }

    /// <summary>
    /// Computes the hash from input plaintext.
    /// </summary>
    /// <param name="textToHash"> Input plaintext. </param>
    /// <returns> The computed hashed plaintext. </returns>
    public string Compute(string textToHash)
    {
        PlainText = textToHash;

        Compute();
        return HashedText;
    }

    /// <summary>
    /// Computes the hash from input plaintext, saltsize, & hashiter parameters.
    /// </summary>
    /// <param name="textToHash"> plaintext. </param>
    /// <param name="saltSize"> salt size (upto 32). </param>
    /// <param name="hashIter"> Number of hashing iterations. </param>
    /// <returns> The computed hashed plaintext. </returns>
    public string Compute(string textToHash, int saltSize, int hashIter)
    {
        PlainText = textToHash;
        GenerateSalt(hashIter, saltSize);
        Compute();
        return HashedText;
    }

    /// <summary>
    /// Computes the hash from input plaintext & salt. 
    /// </summary>
    /// <param name="textToHash"> plaintext </param>
    /// <param name="salt"> salt. </param>
    /// <returns> The computed hashed plaintext. </returns>
    public string Compute(string textToHash, string salt)
    {
        PlainText = textToHash;
        Salt = salt;
        //expand the salt
        expandSalt();
        Compute();
        return HashedText;
    }

    /// <summary>
    /// Generates salt from default parameters.
    /// </summary>
    /// <returns> Randomly generated salt. </returns>
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

    /// <summary>
    /// Generates salt from input parameters.
    /// </summary>
    /// <param name="hashIterations"> Number of hashing iterations. </param>
    /// <param name="saltSize"> Salt size (upto 32). </param>
    /// <returns> Randomly generated salt. </returns>
    public string GenerateSalt(int hashIterations, int saltSize)
    {
        HashIter = hashIterations;
        SaltSize = saltSize;
        return GenerateSalt();
    }

    /// <summary>
    /// Gets the elapsed time in milliseconds for the input number of iterations.
    /// </summary>
    /// <param name="iteration"> Number of hashing iterations. </param>
    /// <returns> The time in milliseconds it takes to compute the input number of iterations. </returns>
    public int GetElapsedTimeForIteration(int iteration)
    {
        var sw = new Stopwatch();
        sw.Start();
        calculateHash(iteration);
        return (int)sw.ElapsedMilliseconds;
    }

    /// <summary>
    /// Calculates the hash from Rfc2898DeriveBytes.
    /// </summary>
    /// <param name="iteration"> Number of hashing iterations. </param>
    /// <returns> The hashed plaintext. </returns>
    private string calculateHash(int iteration)
    {
        //convert the salt into a byte array
        byte[] saltBytes = Encoding.UTF8.GetBytes(Salt);

        var pbkdf2 = new Rfc2898DeriveBytes(PlainText, saltBytes, iteration);
        var key = pbkdf2.GetBytes(64);
        return Convert.ToBase64String(key);
    }

    /// <summary>
    /// Splits the salt string into hash iterations and salt. 
    /// </summary>
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

    /// <summary>
    /// Compares two hashed passwords. 
    /// </summary>
    /// <param name="passwordHash1"> First password to compare. </param>
    /// <param name="passwordHash2"> Second password to compare. </param>
    /// <returns> Returns true of both passwords are the same. </returns>
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


