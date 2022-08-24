using System.ComponentModel;

namespace Mpesa.Lib.Enums;

/// <summary>
/// Enum type for available enviroments
/// </summary>
public enum Env : byte
{
    [Description("https://sandbox.safaricom.co.ke")]
    Sandbox,
    
    [Description("https://api.safaricom.co.ke")]
    Production
}
