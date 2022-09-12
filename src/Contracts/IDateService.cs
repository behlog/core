using System;

namespace Behlog.Core;

public interface IDateService 
{
    DateTime Now { get; }

    DateTime UtcNow { get; }
}

public class DateService : IDateService 
{

    public DateTime Now => DateTime.Now;

    public DateTime UtcNow => DateTime.UtcNow;
}