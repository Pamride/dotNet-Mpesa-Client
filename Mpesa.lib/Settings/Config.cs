namespace mpesa.lib.settings;

public interface IConfig
{
    int ShortCode { get; set; }
    string Initiator { get; set; }
    int LNMShortCode { get; set; }
    string LNMPassWord { get; set; }
    string SecurityCredential { get; set; }
    string CertPath { get; set; }
    string ConsumerKey { get; set; }
    string ConsumerSecret { get; set; }
}

public class Config : IConfig
{
    public int ShortCode { get; set; }
    public string Initiator { get; set; }
    public int LNMShortCode { get; set; }
    public string LNMPassWord { get; set; }
    public string SecurityCredential { get; set; }
    public string CertPath { get; set; }

    public string ConsumerKey { get; set; }
    public string ConsumerSecret { get; set; }
}


