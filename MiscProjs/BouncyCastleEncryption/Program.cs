

namespace ECCurves
{
    using Org.BouncyCastle.Asn1.X500;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Engines;
    using Org.BouncyCastle.Crypto.Modes;
    using Org.BouncyCastle.Crypto.Parameters;
    using Org.BouncyCastle.Security;
    using System.Drawing;
    using System.Security.Cryptography;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            if(false)
            {
                var size = 128;
                //nonce
                var iv = "00112233445566778899AABBCCDDEEFF00";
                byte[] nonce = new byte[8];
                Array.Copy(Convert.FromHexString(iv), nonce, 8);

                CipherKeyGenerator keyGen = new CipherKeyGenerator();
                keyGen.Init(new KeyGenerationParameters(new SecureRandom(), size));
                KeyParameter keyParam = keyGen.GenerateKeyParameter();
                //
                var msg = "Hello";
                var cipherText = Encrypt(msg, keyParam, nonce);
                var decrypt = Decrypt(cipherText, keyParam, nonce);
            }
            else{
              
               
                //nonce
                var iv = "00112233445566778899AABBCCDDEEFF00";
                byte[] nonce = new byte[8];
                byte[] bytes = Encoding.ASCII.GetBytes(iv); 
                Array.Copy(bytes, nonce, 8); // here not using Convert.FromHexString(iv) 

                var keyGen = GeneratorUtilities.GetKeyGenerator("AES128");
                KeyParameter keyParam = new KeyParameter(keyGen.GenerateKey());
                //
                var msg = "Hello";
                var cipherText = Encrypt(msg, keyParam, nonce);
                var decrypt = Decrypt(cipherText, keyParam, nonce);
            }
        }

        //static void Main(string[] args)
        //{



        //    var msg = "Hello";
        //    var add = "";
        //    var iv = "00112233445566778899AABBCCDDEEFF00";
        //    var size = 128;

        //    if (args.Length > 0) msg = args[0];
        //    if (args.Length > 1) add = args[1];
        //    if (args.Length > 2) iv = args[2];
        //    if (args.Length > 3) size = Convert.ToInt32(args[3]);



        //    try
        //    {

        //        var plainTextData = System.Text.Encoding.UTF8.GetBytes(msg);

        //        IBlockCipher cipher = new AesEngine();
        //        int macSize = 8 * cipher.GetBlockSize();
        //        byte[] nonce = new byte[8];
        //        Array.Copy(Convert.FromHexString(iv), nonce, 8);

        //        byte[] associatedText = System.Text.Encoding.UTF8.GetBytes(add);


        //        CipherKeyGenerator keyGen = new CipherKeyGenerator();
        //        keyGen.Init(new KeyGenerationParameters(new SecureRandom(), size));
        //        KeyParameter keyParam = keyGen.GenerateKeyParameter();

        //        AeadParameters keyParamAead = new AeadParameters(keyParam, macSize, nonce, associatedText);
        //        GcmBlockCipher cipherMode = new GcmBlockCipher(cipher);
        //        cipherMode.Init(true, keyParamAead);
        //        int outputSize = cipherMode.GetOutputSize(plainTextData.Length);
        //        byte[] cipherTextData = new byte[outputSize];
        //        int result = cipherMode.ProcessBytes(plainTextData, 0, plainTextData.Length, cipherTextData, 0);
        //        cipherMode.DoFinal(cipherTextData, result);
        //        var rtn = cipherTextData;


        //        // Decrypt
        //        cipherMode.Init(false, keyParamAead);
        //        outputSize = cipherMode.GetOutputSize(cipherTextData.Length);
        //        plainTextData = new byte[outputSize];
        //        result = cipherMode.ProcessBytes(cipherTextData, 0, cipherTextData.Length, plainTextData, 0);
        //        cipherMode.DoFinal(plainTextData, result);
        //        var pln = plainTextData;

        //        Console.WriteLine("=== AES GCM Cipher ==");
        //        Console.WriteLine("Message:\t\t{0}", msg);
        //        Console.WriteLine("IV:\t\t\t{0}", iv);
        //        Console.WriteLine("Key:\t\t\t{0} [{1}]", Convert.ToHexString(keyParam.GetKey()), Convert.ToBase64String(keyParam.GetKey()));

        //        Console.WriteLine("Additional data:\t{0}", add);
        //        Console.WriteLine("\nCipher (hex):\t\t{0}", Convert.ToHexString(rtn));
        //        Console.WriteLine("Cipher (Base64):\t{0}", Convert.ToBase64String(rtn));
        //        Console.WriteLine("\nPlain:\t\t\t{0}", System.Text.Encoding.UTF8.GetString(pln));



        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error: {0}", e.Message);
        //    }
        //}

        static public byte[] Encrypt(string msg, KeyParameter keyParam, byte[] nonce)
        {
           
            var add = "";          
            try
            {
                var plainTextData = System.Text.Encoding.UTF8.GetBytes(msg);
                IBlockCipher cipher = new AesEngine();
                int macSize = 8 * cipher.GetBlockSize();
               

                byte[] associatedText = System.Text.Encoding.UTF8.GetBytes(add);          
                AeadParameters keyParamAead = new AeadParameters(keyParam, macSize, nonce, associatedText);
                GcmBlockCipher cipherMode = new GcmBlockCipher(cipher);
                
                //Encrypt
                cipherMode.Init(true, keyParamAead);
                int outputSize = cipherMode.GetOutputSize(plainTextData.Length);
                byte[] cipherTextData = new byte[outputSize];
                int result = cipherMode.ProcessBytes(plainTextData, 0, plainTextData.Length, cipherTextData, 0);
                cipherMode.DoFinal(cipherTextData, result);
                var rtn = cipherTextData;
                return rtn;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return null;
        }
        static public string Decrypt(byte[] cipherTextData, KeyParameter keyParam, byte[] nonce  )
        {
            try
            {
                byte[] associatedText = System.Text.Encoding.UTF8.GetBytes("");
                IBlockCipher cipher = new AesEngine();
                int macSize = 8 * cipher.GetBlockSize();
                

                AeadParameters keyParamAead = new AeadParameters(keyParam, macSize, nonce, associatedText);
                GcmBlockCipher cipherMode = new GcmBlockCipher(cipher);

                // Decrypt
                cipherMode.Init(false, keyParamAead);
                int outputSize = cipherMode.GetOutputSize(cipherTextData.Length);
                var plainTextData = new byte[outputSize];
                int result = cipherMode.ProcessBytes(cipherTextData, 0, cipherTextData.Length, plainTextData, 0);
                cipherMode.DoFinal(plainTextData, result);
                var pln = plainTextData;
                return System.Text.Encoding.UTF8.GetString(pln);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return null;
        }
    }

}