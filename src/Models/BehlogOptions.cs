namespace Behlog.Core.Models;

public class BehlogOptions
{
    
    public BehlogDbConfig DbConfig { get; set; }
}

public class BehlogDbConfig
{
    public string DbName { get; set; }
    
    public string ConnectionString { get; set; }
    
    public int Timeout { get; set; }
}