namespace Behlog.Core.Models;

public class BehlogOptions
{
    
    public BehlogDbConfig DbConfig { get; set; }
    
    public BehlogFileUploadItemConfig[] FileUploadsConfig { get; set; }
}

public class BehlogDbConfig
{
    public string DbName { get; set; }
    
    public string ConnectionString { get; set; }
    
    public int Timeout { get; set; }
}

public class BehlogFileUploadItemConfig
{
    public string Name { get; set; }
    public string? Extensions { get; set; }
    public double? MaxSize { get; set; }
}
