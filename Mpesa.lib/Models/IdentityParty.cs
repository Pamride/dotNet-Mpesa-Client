using Mpesa.Lib.Enums;

namespace Mpesa.Lib.Models;

public class IdentityParty
{
    public int Party { get; set; }
    public IdentifierType Type { get; }
}
