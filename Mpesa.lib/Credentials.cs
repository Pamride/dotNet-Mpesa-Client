using System.Security.Cryptography.X509Certificates;
using System.Text;
using mpesa.lib.settings;

namespace Mpesa.lib;

public class Credentials : ICredentials
{
    /* public string GetSecurityCredentialsAsync(IConfig config) */
    /* { */
    /*     byte[] plainTextBytes = Encoding.UTF8.GetBytes(config.SecurityCredential); */
    /*  */
    /*     var key = GetPublicKey(config.CertPath); */
    /*     Pkcs1Encoding eng = new Pkcs1Encoding(new RsaEngine()); */
    /*     eng.Init(true, key); */
    /*  */
    /*     int length = plainTextBytes.Length; */
    /*     int blockSize = eng.GetInputBlockSize(); */
    /*     List<byte> cipherTextBytes = new List<byte>(); */
    /*     for (int chunkPosition = 0; */
    /*         chunkPosition < length; */
    /*         chunkPosition += blockSize) */
    /*     { */
    /*         int chunkSize = Math.Min(blockSize, length - chunkPosition); */
    /*         cipherTextBytes.AddRange(eng.ProcessBlock( */
    /*             plainTextBytes, chunkPosition, chunkSize */
    /*         )); */
    /*     } */
    /*     return Convert.ToBase64String(cipherTextBytes.ToArray()); */
    /* } */
    /*  */
    /* private RsaKeyParameters GetPublicKey(string path) */
    /* { */
    /*     RsaKeyParameters publicKey; */
    /*     using (var reader = File.OpenText(path)) */
    /*         publicKey = (RsaKeyParameters)new PemReader(reader).ReadObject(); */
    /*     return publicKey; */
    /* } */
    public string GetSecurityCredentialsAsync(IConfig config)
    {
        throw new NotImplementedException();
    }
}

