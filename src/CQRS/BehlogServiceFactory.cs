namespace Behlog.Core;

public class BehlogServiceFactory : IBehlogServiceFactory
{
    private readonly ServiceFactoryDelegate _serviceFactoryDelegate;

    public BehlogServiceFactory(ServiceFactoryDelegate serviceFactoryDelegate)
    {
        _serviceFactoryDelegate = serviceFactoryDelegate;
    }

    public object GetInstance(Type T)
    {
        return _serviceFactoryDelegate.Invoke(T);
    }
}
