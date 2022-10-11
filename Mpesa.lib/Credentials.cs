using Mpesa.Lib.Settings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto;  
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System.Text;
using System.Security.Cryptography;
using SSCX = System.Security.Cryptography.X509Certificates;

namespace Mpesa.Lib;

public class Credentials : ICredentials
{
    public string GetProductioncSecurityCredentialsAsync(IConfig config)
    {
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(config.SecurityCredential);

        var key = GetPublicKey(config.CertPath!);
        Pkcs1Encoding eng = new Pkcs1Encoding(new RsaEngine());
        eng.Init(true, key);

        int length = plainTextBytes.Length;
        int blockSize = eng.GetInputBlockSize();
        List<byte> cipherTextBytes = new List<byte>();
        for (int chunkPosition = 0; chunkPosition < length; chunkPosition += blockSize)
        {
            int chunkSize = Math.Min(blockSize, length - chunkPosition);
            cipherTextBytes.AddRange(eng.ProcessBlock(
                plainTextBytes, chunkPosition, chunkSize
            ));
        }
        return Convert.ToBase64String(cipherTextBytes.ToArray());
    }

    private SSCX.X509Certificate2 PublicKey(string certPath)
    {
        var x509Cert = new SSCX.X509Certificate2(File.ReadAllBytes(certPath));  
        return x509Cert;
    } 
    
    // private OrgBC.X509Certificate PublicKey(string certPath)
    // {
    //     var x509Cert = new X509Certificate2(File.ReadAllBytes(certPath));  
    //     return x509Cert;
    // }

    private AsymmetricKeyParameter GetPublicKey(string certPath)
    {    
         var x509Cert = new SSCX.X509Certificate2(File.ReadAllBytes(certPath));  
        // var publicKey = x509Cert.PublicKey;
        // var privateKey = x509Cert.PrivateKey;
        // RSACryptoServiceProvider key = (RSACryptoServiceProvider)x509Cert.PrivateKey;
        // RSAParameters rsaparam = key.ExportParameters(true);
        // AsymmetricCipherKeyPair keyPair = DotNetUtilities.GetRsaKeyPair(rsaparam);
        
        X509CertificateParser certParser = new X509CertificateParser();
        X509Certificate privateCertBouncy = certParser.ReadCertificate(x509Cert.GetRawCertData());
        AsymmetricKeyParameter pubKey = privateCertBouncy.GetPublicKey();

        // var pemReader = new PemReader(File.OpenText(certPath));
        // var pemObj = pemReader.ReadObject();
        // AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)pemObj;         

        // var pemObject = (Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters)cert;
        // var rsa = DotNetUtilities.ToRSA(pemObject);

        // RsaKeyParameters publicKey; 
        // using (var reader = File.OpenText(certPath)) 
        //     publicKey = (RsaKeyParameters)new PemReader(reader).ReadObject(); 

        return pubKey;
    }

    public string GetSecurityCredentialsAsync(IConfig config)
    {
        throw new NotImplementedException();
    }
}

