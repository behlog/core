using System.Globalization;

namespace Behlog.Core.Contracts;


public interface ISystemDateTime
{

    DateTime Now { get; }

    DateTime UtcNow { get; }

    string PersianNow();

    string PersianFriendlyNow();
}