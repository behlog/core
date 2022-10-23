namespace Behlog.Core;

public delegate object ServiceFactoryDelegate(Type type);

public interface IBehlogServiceFactory
{
    object GetInstance(Type T);
}