using System;

namespace Behlog.Core;

public interface IIdentity<T>
{

    T Value { get; }
}
