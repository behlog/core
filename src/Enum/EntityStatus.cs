namespace Behlog.Core;

public enum EntityStatusEnum
{
    Deleted = -1,
    Disabled = 0,
    Enabled = 1
}

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