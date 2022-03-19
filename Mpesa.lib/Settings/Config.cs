namespace mpesa.lib.settings;

public interface IConfig
{
    public string? BusinessShortCode { get; set; }
    public string? Initiator { get; set; }
    public int LNMShortCode { get; set; }
    public string? Password { get; set; }
    public string? SecurityCredential { get; set; }
    public string? CertPath { get; set; }

    public string? ConsumerKey { get; set; }
    public string? ConsumerSecret { get; set; }

    public string? Env { get; set; }
    public string? UserName {get; set;}
    public string? APIPassword {get; set;}
    public string? CallBackURL {get; set;}
    public string? AccountReference {get; set;}
}

public class Config : IConfig
{
    public string? BusinessShortCode { get; set; }
    public string? Initiator { get; set; }
    public int LNMShortCode { get; set; }
    public string? Password { get; set; }
    public string? SecurityCredential { get; set; }
    public string? CertPath { get; set; }

    public string? ConsumerKey { get; set; }
    public string? ConsumerSecret { get; set; }

    public string? Env { get; set; }
    public string? UserName {get; set;}
    public string? APIPassword {get; set;}
    public string? CallBackURL {get; set;}
    public string? AccountReference {get; set;}
}


