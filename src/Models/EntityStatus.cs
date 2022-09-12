using iman.Domain;

namespace Behlog.Core;

public class EntityStatus : Enumeration
{

    protected EntityStatus(int id, string name, string title = "")
        :base(id, name, title)
    {
    }

    public static EntityStatus Enabled 
        => new EntityStatus(1, nameof(Enabled));

    public static EntityStatus Disabled 
        => new EntityStatus(0, nameof(Disabled));

    public static EntityStatus Deleted
        => new EntityStatus(-1, nameof(Deleted));

}