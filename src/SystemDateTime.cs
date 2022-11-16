using Behlog.Core.Contracts;

namespace Behlog.Core;

public class SystemDateTime : ISystemDateTime
{
    
    public DateTime Now => DateTime.Now;
    
    public DateTime UtcNow => DateTime.UtcNow;
    
    
    public string PersianNow()
    {
        throw new NotImplementedException();
    }

    public string PersianFriendlyNow()
    {
        throw new NotImplementedException();
    }
}