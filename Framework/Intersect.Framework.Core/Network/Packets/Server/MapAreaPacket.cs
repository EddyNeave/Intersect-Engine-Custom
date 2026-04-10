using MessagePack;

namespace Intersect.Network.Packets.Server;

[MessagePackObject(AllowPrivate = true)]
public partial class MapAreaPacket : IntersectPacket
{
    //Parameterless Constructor for MessagePack
    public MapAreaPacket()
    {
    }

    public MapAreaPacket(MapPacket[] maps)
    {
        Maps = maps;
    }

    [Key(0)]
    public MapPacket[] Maps { get; set; }

}

[MessagePackObject(AllowPrivate = true)]
public partial class MapAreaIdsPacket : IntersectPacket
{
    //Parameterless Constructor for MessagePack
    public MapAreaIdsPacket()
    {
    }

    public MapAreaIdsPacket(params Guid[] mapIds)
    {
        MapIds = mapIds;
    }

    [Key(0)]
    public Guid[] MapIds { get; set; }

}
